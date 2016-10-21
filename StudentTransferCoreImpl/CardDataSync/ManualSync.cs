using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA;
using K12.Data;

namespace StudentTransferCoreImpl.CardDataSync
{
    public partial class ManualSync : FISCA.Presentation.Controls.BaseForm
    {
        private StudentRecord SRecord { get; set; }

        public ManualSync()
        {
            InitializeComponent();
        }

        private void ManualSync_Load(object sender, EventArgs e)
        {
            try
            {
                string sid = K12.Presentation.NLDPanels.Student.SelectedSource[0];
                SRecord = Student.SelectByID(sid);

                txtName.Text = SRecord.Name;
                txtClassName.Text = SRecord.Class != null ? SRecord.Class.Name : "";
                txtSeatNo.Text = SRecord.SeatNo + "";
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                Close();
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
        }
    }
}
