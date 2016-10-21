using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA;
using FISCA.DSAClient;
using System.Xml.Linq;
using FISCA.UDT;

namespace StudentTransferCoreImpl
{
    public partial class TransferInRequire : BaseForm
    {
        private FullTransferToken Token { get; set; }

        public TransferInRequire()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTransferCode, string.Empty);

            try
            {
                if (txtTransferCode.Text.IndexOf('@') < 0)
                    errorProvider1.SetError(txtTransferCode, "請輸入正確的代碼格式，例：fee38eu0@test.hcc.edu.tw");

                Token = new FullTransferToken(txtTransferCode.Text);
                string acceptToken = TokenGenerator.Random();

                Connection conn = new Connection();
                conn.EnableSession = false;
                conn.Connect(Token.AccessPoint, "StudentTransferRequire", Token.TransferToken, "1234");

                XmlHelper req = new XmlHelper();
                req.AddElement("TransferOut");
                req.AddElement("TransferOut", "TransferTarget", FISCA.Authentication.DSAServices.AccessPoint);
                req.AddElement("TransferOut", "AcceptToken", acceptToken);

                XmlHelper schoolInfo = GetSchoolInfo(conn);
                string schoolName = schoolInfo.GetText("Content/ChineseName");

                Envelope rspenv = conn.SendRequest("_.RequireTransfer", new Envelope(req));
                XmlHelper rsp = new XmlHelper(rspenv.Body);
                if (int.Parse(rsp.GetText("@EffectRows")) >= 1)
                {
                    TransferInRecord record = new TransferInRecord();
                    record.TransferToken = Token.TransferToken;
                    record.TransferSource = Token.AccessPoint;
                    record.AcceptToken = acceptToken;
                    record.StudentName = GetStudentName(conn);
                    record.Status = 1;

                    AccessHelper access = new AccessHelper();
                    access.InsertValues(new TransferInRecord[] { record });

                    MessageBox.Show(string.Format("向「{0}」提出資料轉移要求成功，您現在可以透過「轉入/轉出確認」功能檢視資料轉移狀態，當轉出校確認後，即可將資料線上轉入系統中。", schoolName));

                    Close();
                }
                else
                    MessageBox.Show(string.Format("該資料已經被其他人要求轉移。", schoolName));
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ErrorReport.Generate(ex));
            }
        }

        private string GetStudentName(Connection conn)
        {
            Envelope rspenv = conn.SendRequest("_.GetBaseInfo", new Envelope());
            return new XmlHelper(rspenv.Body.XmlString).GetText("StudentName");
        }

        private XmlHelper GetSchoolInfo(Connection conn)
        {
            Connection c = conn.AsContract("StudentTransferPublic");
            Envelope rspenv = c.SendRequest("_.GetSchoolInfo", new Envelope());
            return new XmlHelper(rspenv.Body.XmlString);
        }

        private class FullTransferToken
        {
            public FullTransferToken(string tokenString)
            {
                TransferToken = string.Empty;
                AccessPoint = string.Empty;

                string[] parts = tokenString.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 1)
                {
                    TransferToken = parts[0].Trim();
                    AccessPoint = parts[1].Trim();
                }
            }

            public string TransferToken { get; set; }

            public string AccessPoint { get; set; }
        }

        private void TransferInRequire_Load(object sender, EventArgs e)
        {

        }
    }
}
