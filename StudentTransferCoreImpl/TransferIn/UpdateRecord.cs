using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using FISCA;
using K12.Data;
using K12.Data.Configuration;
using StudentTransferAPI;

namespace StudentTransferCoreImpl.TransferIn
{
    //轉出異動代碼：3
    /// <summary>
    /// 
    /// </summary>
    public partial class UpdateRecord : WizardForm
    {
        private ConfigData cd;          //異動原因的組態物件
        private string updateConfigKey = "UpdateReasons";   //紀錄異動原因清單的組態值的Key
        private string transferOutConfigKey = "TransferInReason";    //紀錄轉入原因清單的組態值的Key

        private TransferInRecord Record { get; set; }

        private XElement XmlData { get; set; }

        public UpdateRecord(ArgDictionary args)
            : base(args)
        {
            InitializeComponent();
        }

        private void UpdateRecord_Load(object sender, EventArgs e)
        {
            try
            {
                intSchoolYear.Text = School.DefaultSchoolYear;
                intSemester.Text = School.DefaultSemester;

                InitUpdateDescriptionItems();

                StatusForm.TransferInItem item = Arguments[Consts.TransferInGridItem] as StatusForm.TransferInItem;
                txtExportSchool.Text = item.TransferSource;

                string stuid = Arguments[Consts.StudentID] + "";
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
            }
        }

        protected override ContinueDirection? OnNextButtonClick()
        {
            try
            {
                string stuid = Arguments[Consts.StudentID] + "";

                UpdateRecordRecord r = new UpdateRecordRecord();
                StudentRecord stu = Student.SelectByID(stuid);
                AddressRecord add = Address.SelectByStudentID(stuid);

                r.StudentID = stuid;
                r.Gender = stu.Gender;
                r.Birthdate = stu.Birthday == null ? string.Empty : stu.Birthday.Value.ToString("yyyy/MM/dd");
                r.GradeYear = stu.Class!=null? stu.Class.GradeYear + "":string.Empty;
                r.IDNumber = stu.IDNumber;
                r.StudentName = stu.Name;
                r.StudentNumber = stu.StudentNumber;
                r.UpdateDate = dtUpdateDate.Text;
                r.UpdateDescription = cboUpdateDescription.Text;
                r.Comment = txtComment.Text;
                r.UpdateCode = "3";
                r.SchoolYear = intSchoolYear.Value;
                r.Semester = intSemester.Value;
                r.Attributes["ImportExportSchool"] = txtExportSchool.Text;
                r.Attributes["OriginAddress"] = add.PermanentAddress;
                r.Attributes["OriginClassName"] = stu.Class!=null? stu.Class.Name : string.Empty;
                r.Attributes["SeatNo"] = K12.Data.Int.GetString(stu.SeatNo);

                //if (dgvLastUpdate.SelectedRows.Count > 0)
                //{
                //    UpdateRecordRecord previousr = dgvLastUpdate.SelectedRows[0].DataBoundItem as UpdateRecordRecord;
                //    r.LastADDate = previousr.ADDate;
                //    r.LastADNumber = previousr.ADNumber;
                //}

                string newid = K12.Data.UpdateRecord.Insert(r);

                Arguments[Consts.UpdateRecordRecord] = r;

                //如果下次進入這個畫面，就直接跳過，因為已經新增過異動了。
                Arguments[Consts.UpdateRecordAction] = ContinueDirection.Skip;
                XmlData.Element("Student").SetAttributeValue("UpdateRecordAction", ContinueDirection.Skip.ToString());
                XmlData.Element("Student").SetAttributeValue("UpdateRecordSID", newid);
                Record.ModifiedContent = XmlData.ToString();
                Record.Save();

                return ContinueDirection.Next;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void InitUpdateDescriptionItems()
        {
            //將轉入紀錄清單的key輸入至list cd中
            cd = School.Configuration[updateConfigKey];
            if (!cd.Contains(transferOutConfigKey))
            {
                cd[transferOutConfigKey] = "遷居;安置;其他";
                cd.Save();
            }
            string[] reasons = cd[transferOutConfigKey].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> reasonList = new List<string>(reasons);
            foreach (string reason in reasons)
            {
                this.cboUpdateDescription.Items.Add(reason);
            }
            foreach (string defaultreason in new string[] { "遷居", "安置", "其他" })
            {
                if (!reasonList.Contains(defaultreason))
                    this.cboUpdateDescription.Items.Add(defaultreason);
            }
        }

        private void UpdateRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            //判斷是否輸入任何數值
            if (!string.IsNullOrEmpty(cboUpdateDescription.Text))
            {
                string reasonlist = cd[transferOutConfigKey];

                string newReasonList = "";

                //判斷是否有寫入新的轉出原因
                if (reasonlist.IndexOf(cboUpdateDescription.Text + ";") == -1)
                {
                    string[] reasons = reasonlist.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < reasons.Length; i++)
                    {
                        newReasonList += reasons[i] + ";";
                    }
                    newReasonList += cboUpdateDescription.Text + ";";
                    //newReasonList += reasons[reasons.Length];
                }
                //把新的原因自串寫回Config裡
                cd[transferOutConfigKey] = newReasonList;
                cd.Save();
            }
        }

        private void btnGetSchoolList_Click(object sender, EventArgs e)
        {
            GetJHSchoolNames form = new GetJHSchoolNames();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtExportSchool.Text = form.SchoolName;
        }

        public override ContinueDirection ShowWizardDialog()
        {
            Record = Arguments[Consts.TransferInRecord] as TransferInRecord;
            XmlData = Arguments[Consts.XmlData] as XElement;

            if (Arguments.ContainsKey(Consts.UpdateRecordAction))
                return (ContinueDirection)Arguments[Consts.UpdateRecordAction];
            else
                return base.ShowWizardDialog();
        }

        private void btnGetSchoolList_Click_1(object sender, EventArgs e)
        {
            GetJHSchoolNames form = new GetJHSchoolNames();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtExportSchool.Text = form.SchoolName;
        }
    }
}
