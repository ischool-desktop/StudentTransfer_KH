using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using FISCA;
using FISCA.Data;
using FISCA.DSAClient;
using FISCA.UDT;
using System.Xml.Linq;
using StudentTransferAPI;
using System.Threading.Tasks;

namespace StudentTransferCoreImpl.TransferIn
{
    public partial class Welcome : WizardForm
    {
        private TransferInRecord Record { get; set; }

        public Welcome()
        {
            InitializeComponent();
        }

        public Welcome(ArgDictionary args)
            : base(args)
        {
            InitializeComponent();
            PreviousButtonEnabled = false;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            try
            {
                Running = true;
                Task task = Task.Factory.StartNew((t) =>
                {
                    InitData();
                }, TaskScheduler.Default);

                task.ContinueWith((t) =>
                {
                    if (t.IsFaulted)
                    {
                        RTOut.WriteError(t.Exception);
                        MessageBox.Show(t.Exception.Message);
                        Close();
                    }

                    Record = Arguments[Consts.TransferInRecord] as TransferInRecord;

                    //更新畫面上的資料。
                    StatusForm.TransferInItem item = Arguments[Consts.TransferInGridItem] as StatusForm.TransferInItem;
                    item.Status = Record.Status;
                    item.RefreshStatusString();

                    Running = false;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                RTOut.WriteError(ex);
                WizardResult = ContinueDirection.Cancel;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void InitData()
        {
            Console.Write(Arguments[Consts.TransferInRecordUID].ToString());
            //Arguments[Consts.QueryHelper] = new QueryHelper();
            //Arguments[Consts.AccessHelper] = new AccessHelper();

            string uid = Arguments[Consts.TransferInRecordUID].ToString();
            //AccessHelper Access = Arguments[Consts.AccessHelper] as AccessHelper;

            List<TransferInRecord> records = Access.Select<TransferInRecord>(new string[] { uid });
            if (records.Count <= 0)
                throw new ArgumentException(string.Format("無法查詢到轉入資料({0})。", uid));

            TransferInRecord rec = records[0];

            if (string.IsNullOrWhiteSpace(rec.ModifiedContent))
            {
                Connection conn = new Connection();
                conn.EnableSession = false;

                conn.Connect(rec.TransferSource, "StudentTransferDownload", GetAccessToken(rec), "1234");

                Envelope rsp = conn.SendRequest("_.GetStudentData", new Envelope());
                conn.SendRequest("_.CommitTransfer", new Envelope(new XmlStringHolder("<Request><TransferOut/></Request>"))); //將狀態設為 4。
                XmlHelper xh = new XmlHelper(rsp.Body);

                XmlElement content = xh.GetElement("TransferOutRecord/Content/DataExchange");
                rec.OriginContent = content.OuterXml;
                rec.ModifiedContent = rec.OriginContent;
                rec.Status = 3;
                rec.Save();
            }

            Arguments[Consts.TransferInRecord] = rec;
            Arguments[Consts.XmlData] = XElement.Parse(rec.ModifiedContent);
        }

        private static string GetAccessToken(TransferInRecord rec)
        {
            return string.Format("{0}-{1}", rec.TransferToken, rec.AcceptToken);
        }

        protected override void OnRunningChanged()
        {
            NextButtonEnabled = !Running;
        }
    }
}
