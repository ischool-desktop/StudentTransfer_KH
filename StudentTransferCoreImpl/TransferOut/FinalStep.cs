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
using Aspose.Words;
using System.IO;
using System.Diagnostics;
using FISCA.Authentication;
using StudentTransferAPI;
using K12.Data;

namespace StudentTransferCoreImpl.TransferOut
{
    public partial class FinalStep : WizardForm
    {
        public FinalStep(ArgDictionary args)
            : base(args)
        {
            InitializeComponent();
        }

        private void labelX2_MarkupLinkClick(object sender, DevComponents.DotNetBar.MarkupLinkClickEventArgs e)
        {
            new TransferOutReport().Generate(Arguments[Consts.TransferOutRecord] as TransferOutRecord);
        }

         protected override ContinueDirection? OnNextButtonClick()
        {
            string msg = "是否要將學生變更為「畢業或離校」狀態？\n\n如果您要手動變更學生狀態，請按「否」。";

            if (MessageBox.Show(msg, "ischool", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                StudentRecord sr = Student.SelectByID(Arguments[Consts.StudentID] + "");
                sr.Status = StudentRecord.StudentStatus.畢業或離校;
                Student.Update(sr);
            }

            return base.OnNextButtonClick();
        }
    }
}
