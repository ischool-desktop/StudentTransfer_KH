using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FISCA;
using FISCA.Data;
using FISCA.DSAClient;
using FISCA.LogAgent;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using Aspose.Cells;
using System.IO;

namespace StudentTransferCoreImpl
{
    public partial class StatusForm : BaseForm
    {
        private string TitleString = "轉入/轉出狀態確認";

        public StatusForm()
        {
            InitializeComponent();
            dgvTransferOut.AutoGenerateColumns = false;
            dgvTransferIn.AutoGenerateColumns = false;
        }

        private void StatusForm_Load(object sender, EventArgs e)
        {
            ReloadGrid();
        }

        private void ReloadGrid()
        {
            try
            {
                Text = TitleString + " (讀取資料中...)";

                string outCmd = string.Format(@"
select student.name,class.class_name,
    $st_transferout.uid,
    $st_transferout.transfertarget,
    $st_transferout.transfertoken,
    $st_transferout.accepttoken,
    $st_transferout.status,cast(createtime as character varying)
from $st_transferout left join student on cast ($st_transferout.refstudentid as int)=student.id
left join class on student.ref_class_id=class.id
{0}
order by $st_transferout.uid desc", chkAllOut.Checked ? "" : "where $st_transferout.status<4");

                string inCmd = string.Format(@"
select class.class_name,
    $st_transferin.uid,
    $st_transferin.studentname,
    $st_transferin.transfersource,
    $st_transferin.transfertoken,
    $st_transferin.accepttoken,
    $st_transferin.status,
    cast(createtime as character varying)
from $st_transferin left join student on cast ($st_transferin.refstudentid as int)=student.id
left join class on student.ref_class_id=class.id
{0}
order by $st_transferin.uid desc", chkAllIn.Checked ? "" : "where $st_transferin.status<4");

                DataTable outTable = null, inTable = null;
                Task task = Task.Factory.StartNew(() =>
                {
                    QueryHelper query = new QueryHelper();
                    outTable = query.Select(outCmd);
                    inTable = query.Select(inCmd);
                });

                task.ContinueWith((t) =>
                {
                    Text = TitleString;
                    if (t.IsFaulted)
                    {
                        RTOut.WriteError(t.Exception);
                        MessageBox.Show(t.Exception.Message);
                        return;
                    }

                    List<TransferOutItem> items = new List<TransferOutItem>();
                    foreach (DataRow row in outTable.Rows)
                        items.Add(new TransferOutItem(row));

                    dgvTransferOut.DataSource = new BindingList<TransferOutItem>(items);

                    List<TransferInItem> inItems = new List<TransferInItem>();
                    foreach (DataRow row in inTable.Rows)
                        inItems.Add(new TransferInItem(row));

                    dgvTransferIn.DataSource = new BindingList<TransferInItem>(inItems);

                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                FISCA.RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTransferOut_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == dgvTransferOut.Columns["chStatus"].Index) && e.Value != null)
            {
                DataGridViewCell cell = dgvTransferOut.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (e.Value.Equals("待轉出"))
                    cell.ToolTipText = "等待轉入校提出資料轉移要求。";
                else if (e.Value.Equals("待確認"))
                    cell.ToolTipText = "轉入校正在等待您確認資料轉移要求。";
                else if (e.Value.Equals("已確認"))
                    cell.ToolTipText = "您已經確認了資料轉移的要求。";
                else if (e.Value.Equals("資料已轉出"))
                    cell.ToolTipText = "已經將資料轉移到轉入校的資料庫中。";
            }
        }

        #region TransferOutItem
        internal class TransferOutItem : INotifyPropertyChanged
        {
            public TransferOutItem(DataRow row)
            {
                UID = row["uid"].ToString();
                ClassName = row["class_name"].ToString();
                Name = row["name"].ToString();
                TransferTarget = row["transfertarget"].ToString();
                TransferToken = row["transfertoken"].ToString();
                AcceptToken = row["accepttoken"].ToString();

                if (string.IsNullOrWhiteSpace(TransferTarget))
                    TransferTarget = "<未確定>";
                else
                {
                    Task task = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            Connection conn = new Connection();
                            conn.Connect(TransferTarget, "StudentTransferPublic", "", "");
                            Envelope rspenv = conn.SendRequest("_.GetSchoolInfo", new Envelope());
                            TransferTarget = new XmlHelper(rspenv.Body.XmlString).GetText("Content/ChineseName");
                        }
                        catch
                        {
                            TransferTarget = "無法取得資訊";
                        }
                    }, new System.Threading.CancellationToken(), TaskCreationOptions.None, TaskScheduler.Default);

                    task.ContinueWith(x =>
                    {
                        if (PropertyChanged != null)
                            PropertyChanged(this, new PropertyChangedEventArgs("TransferTarget"));
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }

                Status = int.Parse(row["status"].ToString());
                if (Status == 1)
                    StatusString = "待轉出";
                else if (Status == 2)
                    StatusString = "待確認";
                else if (Status == 3)
                    StatusString = "已確認";
                else if (Status == 4)
                    StatusString = "資料已轉出";
                else if (Status == 99)
                    StatusString = "已封存";
                else
                    StatusString = "狀態不明!";

                DateTime lastUpdate = DateTime.Parse(row["createtime"].ToString());
                //TimeSpan length = DateTime.Now - create;
                Trace = lastUpdate.ToString("MM/dd HH:mm"); //string.Format("{0} 天 {1} 小時 {2} 分", length.Days, length.Hours, length.Minutes);
            }

            public string UID { get; private set; }

            public string ClassName { get; set; }

            public string Name { get; set; }

            public string TransferTarget { get; set; }

            public string TransferToken { get; set; }

            public string AcceptToken { get; set; }

            public int Status { get; set; }

            public string StatusString { get; set; }

            public string Trace { get; set; }

            #region INotifyPropertyChanged 成員

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion
        }
        #endregion

        #region TransferInItem
        public class TransferInItem : INotifyPropertyChanged
        {
            public TransferInItem(DataRow row)
            {
                UID = row["uid"].ToString();
                ClassName = row["class_name"].ToString();
                Name = row["studentname"].ToString();
                TransferSourceUrl = row["transfersource"].ToString();
                TransferToken = row["transfertoken"].ToString();
                AcceptToken = row["accepttoken"].ToString();

                TransferSource = TransferSourceUrl; //先預設一個資料。

                if (string.IsNullOrWhiteSpace(TransferSourceUrl))
                    TransferSource = "<未確定>";
                else
                {
                    Task task = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            Connection conn = new Connection();
                            conn.Connect(TransferSourceUrl, "StudentTransferPublic", "", "");
                            Envelope rspenv = conn.SendRequest("_.GetSchoolInfo", new Envelope());
                            TransferSource = new XmlHelper(rspenv.Body.XmlString).GetText("Content/ChineseName");
                        }
                        catch
                        {
                            TransferSource = "無法取得資訊";
                        }
                    }, new CancellationToken(), TaskCreationOptions.None, TaskScheduler.Default);

                    task.ContinueWith(x =>
                    {
                        if (PropertyChanged != null)
                            PropertyChanged(this, new PropertyChangedEventArgs("TransferSource"));
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }

                Status = int.Parse(row["status"].ToString());
                RefreshStatusString();

                DateTime lastUpdate = DateTime.Parse(row["createtime"].ToString());
                //TimeSpan length = DateTime.Now - create;
                Trace = lastUpdate.ToString("MM/dd HH:mm"); //string.Format("{0} 天 {1} 小時 {2} 分", length.Days, length.Hours, length.Minutes);

                if (Status == 1) //1 代表等待確認，所以進行檢查。
                    TrySwitch2();

                if (Status == 2) //2 代表已經確認。
                    TrySwitch3();
            }

            private void TrySwitch3()
            {
                try
                {
                    Task task = Task.Factory.StartNew(() =>
                    {
                        //將最新狀態寫回資料庫。
                        AccessHelper access = new AccessHelper();
                        List<TransferInRecord> records = access.Select<TransferInRecord>(string.Format("uid='{0}'", UID));

                        //如果 ModifyedContent 有資料代表已經到 Status 3。
                        if (!string.IsNullOrWhiteSpace(records[0].ModifiedContent))
                        {
                            records[0].Status = 3;
                            records[0].Save();
                        }
                    }, new CancellationToken(), TaskCreationOptions.None, TaskScheduler.Default);

                    task.ContinueWith((t) =>
                    {
                        if (t.Exception != null)
                        {
                            FISCA.RTOut.WriteError(t.Exception);
                            return;
                        }
                        Status = 3;
                        RefreshStatusString();
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch (Exception ex)
                {
                    FISCA.RTOut.WriteError(ex);
                }
            }

            private void TrySwitch2()
            {
                try
                {
                    Task task = Task.Factory.StartNew(() =>
                    {
                        Connection conn = new Connection();
                        //可以登入代表已經 Accept。
                        conn.Connect(TransferSourceUrl, "StudentTransferDownload", TransferToken + "-" + AcceptToken, "1234");

                        //將最新狀態寫回資料庫。
                        AccessHelper access = new AccessHelper();
                        List<TransferInRecord> records = access.Select<TransferInRecord>(string.Format("uid='{0}'", UID));
                        if (records.Count > 0)
                        {
                            records[0].Status = 2;
                            records[0].Save();
                        }
                    }, new CancellationToken(), TaskCreationOptions.None, TaskScheduler.Default);

                    task.ContinueWith((t) =>
                    {
                        if (t.Exception != null)
                        {
                            FISCA.RTOut.WriteError(t.Exception);
                            return;
                        }
                        Status = 2;
                        RefreshStatusString();
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch (Exception ex)
                {
                    FISCA.RTOut.WriteError(ex);
                }
            }

            public void RefreshStatusString()
            {
                if (Status == 1)
                    StatusString = "待確認";
                else if (Status == 2)
                    StatusString = "已確認";
                else if (Status == 3)
                    StatusString = "已轉移";
                else if (Status == 4)
                    StatusString = "已轉入";
                else if (Status == 99)
                    StatusString = "已封存";
                else
                    StatusString = "狀態不明!";

                RaiseChanged("StatusString");
            }

            private void RaiseChanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }

            public string UID { get; private set; }

            public string Name { get; set; }

            private string _class_name;
            public string ClassName
            {
                get { return _class_name; }
                set
                {
                    _class_name = value;
                    RaiseChanged("ClassName");
                }
            }

            public string TransferSourceUrl { get; set; }

            public string TransferSource { get; set; }

            public string TransferToken { get; set; }

            public string AcceptToken { get; set; }

            public int Status { get; set; }

            public string StatusString { get; set; }

            public string Trace { get; set; }

            #region INotifyPropertyChanged 成員

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion
        }
        #endregion

        private void dgvTransferOut_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvTransferOut.Rows[e.RowIndex];

            new TransferOutStatus(row.DataBoundItem as TransferOutItem).ShowDialog();
        }

        private void btnOutExportXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferOut.SelectedRows.Count > 0)
                {
                    TransferOutItem item = dgvTransferOut.SelectedRows[0].DataBoundItem as TransferOutItem;

                    List<TransferOutRecord> records = new AccessHelper().Select<TransferOutRecord>(new string[] { item.UID });
                    if (records.Count > 0)
                        new ExportToXml().Generate(records[0].StudentName, records[0].Content);
                    else
                        MessageBox.Show("沒有資料!", "ischool");
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTransferIn_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvTransferIn.Rows[e.RowIndex];

            new TransferInStatus(row.DataBoundItem as TransferInItem).ShowDialog();
        }

        private void chkAllIn_CheckedChanged(object sender, EventArgs e)
        {
            ReloadGrid();
        }

        private void chkAllOut_CheckedChanged(object sender, EventArgs e)
        {
            ReloadGrid();
        }

        private void btnTransferReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferOut.SelectedRows.Count < 0) return;

                DataGridViewRow row = dgvTransferOut.SelectedRows[0];

                string uid = (row.DataBoundItem as TransferOutItem).UID;

                AccessHelper access = new AccessHelper();
                List<TransferOutRecord> records = access.Select<TransferOutRecord>(new string[] { uid });

                new TransferOutReport().Generate(records[0]);
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 解除封存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnArchive_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferOut.SelectedRows.Count > 0)
                {
                    List<TransferOutItem> TransferOuts = new List<TransferOutItem>();

                    foreach (DataGridViewRow Row in dgvTransferOut.SelectedRows)
                    {
                        TransferOutItem item = Row.DataBoundItem as TransferOutItem;

                        //只有封存狀態才可以解除封存
                        if (item.Status == 99)
                            TransferOuts.Add(item);
                    }

                    string Message = "您是否要解除封存以下轉出記錄『" + string.Join(",", TransferOuts.Select(x => x.Name).ToArray()) + "』？";

                    if (TransferOuts.Count == 0)
                    {
                        MessageBox.Show("沒有資料可以解除封存，只有封存狀態學生才可以進行解除封存", "線上轉學功能提醒");
                    }
                    else if (MessageBox.Show(Message, "線上轉學功能提醒", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        List<TransferOutRecord> records = new List<TransferOutRecord>();

                        records = new AccessHelper()
                            .Select<TransferOutRecord>("uid in (" + string.Join(",", TransferOuts.Select(x => x.UID).ToArray()) + ")");

                        if (records.Count > 0)
                        {
                            records.ForEach(x => x.Status = 1);
                            records.SaveAll();

                            StringBuilder strLog = new StringBuilder();

                            strLog.AppendLine("班級,姓名,轉入校,處理進度,最後更新時間");

                            foreach (TransferOutItem TransferOut in TransferOuts)
                                strLog.AppendLine(TransferOut.ClassName + "," + TransferOut.Name + "," + TransferOut.TransferTarget + "," + TransferOut.StatusString + "," + TransferOut.Trace);

                            ApplicationLog.Log("線上轉學模組", "解除封存", strLog.ToString());

                            ReloadGrid();
                        }
                        else
                            MessageBox.Show("沒有資料!", "線上轉學功能提醒");
                    }
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 封存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArchive_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferOut.SelectedRows.Count > 0)
                {
                    List<TransferOutItem> TransferOuts = new List<TransferOutItem>();

                    foreach (DataGridViewRow Row in dgvTransferOut.SelectedRows)
                    {
                        TransferOutItem item = Row.DataBoundItem as TransferOutItem;

                        //只有待轉出狀態才可以進行封存
                        if (item.Status == 1)
                            TransferOuts.Add(item);
                    }

                    string Message = "您是否要封存以下轉出記錄『" + string.Join(",",TransferOuts.Select(x => x.Name).ToArray())+ "』？" + System.Environment.NewLine + "若您要檢視已封存記錄，請勾選「顯示所有歷程」";

                    if (TransferOuts.Count == 0)
                    {
                        MessageBox.Show("沒有資料可以封存，只有待轉出狀態學生才可以進行封存","線上轉學功能提醒");
                    }
                    else if (MessageBox.Show(Message , "線上轉學功能提醒", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        List<TransferOutRecord> records = new List<TransferOutRecord>();

                        records = new AccessHelper()
                            .Select<TransferOutRecord>("uid in (" + string.Join(",", TransferOuts.Select(x => x.UID).ToArray()) + ")");

                        if (records.Count > 0)
                        {
                            records.ForEach(x => x.Status = 99);
                            records.SaveAll();

                            StringBuilder strLog = new StringBuilder();

                            strLog.AppendLine("班級,姓名,轉入校,處理進度,最後更新時間");

                            foreach (TransferOutItem TransferOut in TransferOuts)
                                strLog.AppendLine(TransferOut.ClassName +"," +  TransferOut.Name + "," +TransferOut.TransferTarget + "," + TransferOut.StatusString + "," +TransferOut.Trace);

                            ApplicationLog.Log("線上轉學模組", "封存", strLog.ToString());

                            ReloadGrid();
                        }
                        else
                            MessageBox.Show("沒有資料!", "線上轉學功能提醒"); 
                    }
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportInXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferIn.SelectedRows.Count > 0)
                {
                    TransferInItem item = dgvTransferIn.SelectedRows[0].DataBoundItem as TransferInItem;
                    if (item.Status < 3)
                    {
                        MessageBox.Show("沒有資料可以列印!!");
                        return;
                    }

                    List<TransferInRecord> records = new AccessHelper().Select<TransferInRecord>(new string[] { item.UID });
                    if (records.Count > 0)
                        new ExportToXml().Generate(records[0].StudentName, records[0].ModifiedContent);
                    else
                        MessageBox.Show("沒有資料!", "線上轉學功能提醒");
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTransferInReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferIn.SelectedRows.Count > 0)
                {
                    TransferInItem item = dgvTransferIn.SelectedRows[0].DataBoundItem as TransferInItem;
                    if (item.Status < 3)
                    {
                        MessageBox.Show("沒有資料可以列印!!");
                        return;
                    }

                    List<TransferInRecord> records = new AccessHelper().Select<TransferInRecord>(new string[] { item.UID });
                    if (records.Count > 0)
                    {
                        Workbook wb = new ExportToExcel(XElement.Parse(records[0].ModifiedContent)).Export();
                        string reportName = "資料轉移總表";
                        string path = System.Windows.Forms.Application.StartupPath + "\\Reports\\" + reportName + ".xls";
                        int i = 1;
                        while (File.Exists(path))
                        {
                            path = System.Windows.Forms.Application.StartupPath + "\\Reports\\" + reportName + i + ".xls";
                            i++;
                        }
                        wb.Save(path, FileFormatType.Excel2003);
                        System.Diagnostics.Process.Start(path);
                    }
                    else
                    {
                        MessageBox.Show("沒有資料!", "線上轉學功能提醒");
                    }
                        
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 開啟選單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutMenu_PopupOpen(object sender, DevComponents.DotNetBar.PopupOpenEventArgs e)
        {
            btnArchive.Enabled = false;
            btnUnArchive.Enabled = false;
            btnStatus_1.Enabled = false;

            if (dgvTransferOut.SelectedRows.Count > 0)
            {
                List<TransferOutItem> TransferOuts = new List<TransferOutItem>();

                foreach (DataGridViewRow Row in dgvTransferOut.SelectedRows)
                {
                    TransferOutItem item = Row.DataBoundItem as TransferOutItem;

                    //只有待轉出狀態才可以進行封存
                    if (item.Status == 1)
                       btnArchive.Enabled = true;

                    //只有封存狀態才可以解除封存
                    if (item.Status == 99)
                       btnUnArchive.Enabled = true;

                    // 只有在待確認才能恢復成待轉出
                    if (item.Status == 2 || item.Status == 3)
                        btnStatus_1.Enabled = true;
                }
            }
        }

        private void OutMenu_Click(object sender, EventArgs e)
        {
        
        }

        private void btnStatus_1_Click(object sender, EventArgs e)
        {
            // 功能主要將Status 2 的 轉成 Status 1
            if(dgvTransferOut.SelectedRows.Count == 1)
            {
                TransferOutItem item = dgvTransferOut.SelectedRows[0].DataBoundItem as TransferOutItem;
                if(item != null)
                {
                    // 待確認
                    if (item.Status == 2 || item.Status == 3)
                    {
                        // 取得 UDT 資料
                        AccessHelper accHelper = new AccessHelper();
                        string qry="uid='"+item.UID+"'";
                        List<TransferOutRecord> RecList = accHelper.Select<TransferOutRecord>(qry);
                        if(RecList.Count ==1)
                        {
                            if (MsgBox.Show("當按「是」將"+item.StatusString+"狀態恢復成待轉出。", "恢復成待轉出", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                            {
                                TransferOutRecord Rec = RecList[0];
                                Rec.Status = 1;
                                Rec.TransferTarget = null;
                                Rec.AcceptToken = null;
                                Rec.Save();

                                StringBuilder strLog = new StringBuilder();

                                strLog.AppendLine("班級,姓名,轉入校,處理進度,最後更新時間");
                                strLog.AppendLine(item.ClassName + "," + item.Name + "," + item.TransferTarget + "," + item.StatusString + "," + item.Trace);

                                ApplicationLog.Log("線上轉學模組", "轉出學生清單-恢復成待轉出", strLog.ToString());
                                ReloadGrid();
                            }
                        }                        
                    }
                }
            }
        }

        private void btnInDel_Click(object sender, EventArgs e)
        {
            // 可以刪除待確認資料
            if(dgvTransferIn.SelectedRows.Count ==1)
            {
                TransferInItem item = dgvTransferIn.SelectedRows[0].DataBoundItem as TransferInItem;
                if(item !=null)
                {
                    // 待確認，在轉入狀態待確認 status =1
                    if(item.Status == 1)
                    {
                        // 取得 UDT 資料
                        AccessHelper accHelper = new AccessHelper();
                        string qry = "uid='" + item.UID + "'";
                        List<TransferInRecord> RecList = accHelper.Select<TransferInRecord>(qry);
                        if (RecList.Count == 1)
                        {
                            if (MsgBox.Show("當按「是」將刪除此筆待確認資料。", "刪除待確認資料", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                            {
                                TransferInRecord Rec = RecList[0];
                                Rec.Deleted = true;
                                Rec.Save();

                                StringBuilder strLog = new StringBuilder();

                                strLog.AppendLine("班級,姓名,來源,處理進度,最後更新時間");
                                strLog.AppendLine(item.ClassName + "," + item.Name + "," + item.TransferSource + "," + item.StatusString + "," + item.Trace);

                                ApplicationLog.Log("線上轉學模組", "轉入學生清單-刪除待確認資料", strLog.ToString());
                                ReloadGrid();
                            }
                        }
                    }
                }
            }
        }

        private void InMenu_PopupOpen(object sender, DevComponents.DotNetBar.PopupOpenEventArgs e)
        {
            btnInDel.Enabled = false;
            if (dgvTransferIn.SelectedRows.Count > 0)
            {
                List<TransferInItem> TransferIns = new List<TransferInItem>();

                foreach (DataGridViewRow Row in dgvTransferIn.SelectedRows)
                {
                    TransferInItem item = Row.DataBoundItem as TransferInItem;

                    //只有在待確認才能刪除
                    if (item.Status == 1)
                        btnInDel.Enabled = true;
                }
            }
        }
    }
}
