using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using FISCA;

namespace StudentTransferCoreImpl.CardDataSync
{
    public partial class JHSchoolSelector : FISCA.Presentation.Controls.BaseForm
    {
        private XElement xmlschools = null;

        public JHSchoolSelector()
        {
            InitializeComponent();

            dgvCounties.AutoGenerateColumns = false;
            dgvSchools.AutoGenerateColumns = false;
        }

        private void JHSchoolSelector_Load(object sender, EventArgs e)
        {
            try
            {
                XElement xmlschools = XElement.Parse(StudentTransferCoreImpl.Properties.Resources.jh);

                var counties = from school in xmlschools.Elements("School") select school.AttributeText("County");

                foreach (var each in counties.Distinct())
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvCounties, each);
                    dgvCounties.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                Close();
            }
        }
    }
}
