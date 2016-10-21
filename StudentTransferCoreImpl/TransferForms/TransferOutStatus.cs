using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.Authentication;
using FISCA.UDT;
using DevComponents.DotNetBar;
using FISCA.DSAClient;
using FISCA;
using System.Xml.Linq;
using System.Xml.XPath;

namespace StudentTransferCoreImpl
{
    internal partial class TransferOutStatus : BaseForm
    {
        private StatusForm.TransferOutItem Item { get; set; }

        private StatusUIController StatusUI { get; set; }

        public TransferOutStatus(StatusForm.TransferOutItem item)
        {
            InitializeComponent();
            Item = item;

            StatusUI = new StatusUIController(new PanelEx[] { state1, state2, state3, state4 });
        }

        private void TransferOutStatus_Load(object sender, EventArgs e)
        {
            txtName.Text = string.Format("{0} {1}", Item.ClassName, Item.Name);
            txtTransferCode.Text = string.Format("{0}@{1}", Item.TransferToken, DSAServices.AccessPoint);
            txtTransferTarget.Text = Item.TransferTarget;

            if (Item.Status <= 1)
                btnConfirm.Enabled = false;

            if (Item.Status >= 3)
                ButtonToConfirmedStatus();

            RefreshGridData();
        }

        private void RefreshGridData()
        {
            foreach (string status in new string[] { "待轉出", "待確認", "已確認", "資料已轉出" })
            {
                if (status == Item.StatusString)
                    StatusUI.Status = Item.Status;
            }
        }

        private void ButtonToConfirmedStatus()
        {
            btnConfirm.Enabled = false;
            btnConfirm.Text = "已確認";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Format("確認之後「{0}」即可下載該學生資料，您確定嗎？", txtTransferTarget.Text);

                if (MessageBox.Show(msg, "ischool", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                AccessHelper helper = new AccessHelper();

                List<TransferOutRecord> records = helper.Select<TransferOutRecord>(string.Format("uid='{0}'", Item.UID));

                if (records.Count > 0)
                {
                    TransferOutRecord record = records[0];
                    record.Status = 3;
                    record.Save();

                    Item.StatusString = "已確認";
                    Item.Status = 3;
                    RefreshGridData();
                    ButtonToConfirmedStatus();

                    if (Program.CurrentMode == Program.Hsinchu)
                        CallTransferOutWS(record);
                }
                else
                    throw new ArgumentException("爆炸!");
            }
            catch (Exception ex)
            {
                FISCA.RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void CallTransferOutWS(TransferOutRecord record)
        {
            try
            {
                string contract = "StudentTransferHsinchuSpecial";
                string service = "SyncTrasnferOut";

                SecurityToken token = (DSAServices.DefaultDataSource.SecurityToken as SessionToken).OriginToken;
                Connection conn = DSAServices.DefaultDataSource.AsContract(contract, token);
                XElement econtent = XElement.Parse(record.Content);

                XmlHelper req = new XmlHelper("<Request/>");
                req.AddElement(".", "Name", econtent.XPathSelectElement("Student/Name").Value);
                req.AddElement(".", "StudentID", econtent.XPathSelectElement("Student").ElementText("IDNumber"));
                req.AddElement(".", "TargetSchool", GetSchoolCode(record));
                req.AddElement(".", "Writer", string.Format("{0}:{1}", DSAServices.AccessPoint, DSAServices.UserAccount));
                req.AddElement(".", "Birthday", FormatBirthday(econtent));

                RTOut.WriteLine(req.XmlString);
                RTOut.WriteLine(conn.SendRequest(service, new Envelope(req)).XmlString);
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
            }
        }

        private string FormatBirthday(XElement econtent)
        {
            string strBirthday = econtent.XPathSelectElement("Student").ElementText("Birthdate");
            string formatedBirthday = "";
            DateTime birthday;

            if (DateTime.TryParse(strBirthday, out birthday))
                formatedBirthday = string.Format("{0:0000}{1:00}{2:00}", birthday.Year, birthday.Month, birthday.Day);

            return formatedBirthday;
        }

        private string GetSchoolCode(TransferOutRecord record)
        {
            string code = "000000";

            XElement schools = XElement.Parse(Properties.Resources.jh);

            var result = from school in schools.Elements()
                         where school.AttributeText("DSNS") == record.TransferTarget
                         select school.AttributeText("Code");

            foreach (string school in result)
                code = school;


            return code;
        }
    }
}
