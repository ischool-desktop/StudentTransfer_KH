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
using FISCA.UDT;
using FISCA.Data;
using System.Xml.Linq;
using StudentTransferAPI;

namespace StudentTransferCoreImpl.TransferOut
{
    public partial class Welcome : WizardForm
    {
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
                AccessHelper access = new AccessHelper();

                string stuid = Arguments[Consts.StudentID] + "";

                List<TransferOutRecord> records = access.Select<TransferOutRecord>(string.Format("refstudentid='{0}' and status<'4'", stuid));

                if (records.Count > 0)
                {
                    string msg = string.Format("學生「{0}」已經在待轉學清單中，再執行一次轉學精靈將取代現有資料。", records[0].StudentName);

                    try
                    {
                        Arguments[Consts.XmlData] = XElement.Parse(records[0].Content);

                        //已經有資料，代表異動已經新增好了。
                        Arguments[Consts.UpdateRecordAction] = ContinueDirection.Skip;
                    }
                    catch { }

                    MessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
            }
        }
    }
}
