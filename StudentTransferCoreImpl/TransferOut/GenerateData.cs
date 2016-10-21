using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FISCA;
using System.Xml.Linq;
using FISCA.Data;
using FISCA.UDT;
using System.Threading.Tasks;
using StudentTransferAPI;
using K12.Data;

namespace StudentTransferCoreImpl.TransferOut
{
    public partial class GenerateData : WizardForm
    {
        private XElement XmlData = new XElement("DataExchange");

        public GenerateData(ArgDictionary args)
            : base(args)
        {
            InitializeComponent();
        }

        private void ConfirmReport_Load(object sender, EventArgs e)
        {
            NextButtonEnabled = false;
            cp1.IsRunning = true;
            Task task = Task.Factory.StartNew(() =>
            {
                //儲存異動記錄。
                if (Arguments.ContainsKey(Consts.UpdateRecordRecord))
                    K12.Data.UpdateRecord.Insert(Arguments[Consts.UpdateRecordRecord] as UpdateRecordRecord);

                GenerateXmlData();
            });

            task.ContinueWith(x =>
            {
                if (x.Exception != null)
                {
                    foreach (Exception ex in x.Exception.InnerExceptions)
                        MessageBox.Show(ErrorReport.Generate(ex));
                }

                cp1.IsRunning = false;
                cp1.Value = 100;
                lblMsg.Text = "資料產生完成。";

                //RTOut.WriteXml(XmlData.ToString());
                NextButtonEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void GenerateXmlData()
        {
            string stuId = Arguments[Consts.StudentID].ToString();
            List<TransferProcessor> processors = Arguments[Consts.SelectedProcessor] as List<TransferProcessor>;

            QueryHelper query = new QueryHelper();

            string cmd = string.Format("select * from student where id={0}", stuId);

            DataTable dt = query.Select(cmd);
            if (dt.Rows.Count <= 0)
                throw new Exception("學生已被刪除？");

            string stuName = dt.Rows[0]["Name"].ToString();

            foreach (TransferProcessor processor in processors)
            {
                processor.SetStudentId(stuId);
                XElement result = processor.TransferOut();

                if (result != null)
                {
                    result.SetAttributeValue("Processor", processor.Identify);
                    XmlData.Add(result);
                }
            }

            XmlData.Add(Arguments[Consts.StudentRemark] as XElement);

            Arguments[Consts.XmlData] = XmlData;

            AccessHelper access = new AccessHelper();

            string condition = string.Format("RefStudentID='{0}' and Status < '4'", stuId);
            List<TransferOutRecord> records = access.Select<TransferOutRecord>(condition);

            if (records.Count <= 0)
            {
                TransferOutRecord record = new TransferOutRecord();
                record.RefStudentID = stuId;
                record.StudentName = stuName;
                record.Status = 1;
                record.TransferAccept = false;
                record.TransferToken = CalcTransferToken();
                record.Content = XmlData.ToString();
                records.Add(record);
            }
            else if (records.Count == 1)
                records[0].Content = XmlData.ToString();
            else
                throw new ArgumentException("嚴重的資料錯誤!!!");

            Arguments[Consts.TransferOutRecord] = records[0];
            records.SaveAll();
        }

        private string CalcTransferToken()
        {
            return TokenGenerator.Random();
        }

        private XElement GenerateXmlField(string name, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return new XElement(name);
            else
                return new XElement(name, XElement.Parse(content));
        }
    }
}
