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
using System.Xml.Linq;
using System.Xml.XPath;
using Campus;
using StudentTransferAPI;

namespace StudentTransferCoreImpl.TransferOut
{
    public partial class StudentTag : WizardForm
    {
        public StudentTag(ArgDictionary args)
            : base(args)
        {
            InitializeComponent();
        }

        private void StudentTag_Load(object sender, EventArgs e)
        {
            try
            {
                XElement options = XElement.Parse(Properties.Resources.Options);
                foreach (XElement each in options.XPathSelectElements("Options[@Name='學生身份註記']/Item"))
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvStuTag, false, each.Value);
                    dgvStuTag.Rows.Add(row);
                }

                foreach (XElement each in options.XPathSelectElements("Options[@Name='原住民族別']/Item"))
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvEthnicGroup, each.Value);
                    dgvEthnicGroup.Rows.Add(row);
                }

                foreach (string each in new string[] { "無", "平地", "山地" })
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvPlace, each);
                    dgvPlace.Rows.Add(row);
                }
                PreviousButtonEnabled = false;

                RestoreSelection();
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
            }
        }

        private void RestoreSelection()
        {
            XElement remark = Arguments[Consts.StudentRemark] as XElement;

            if (remark != null)
            {
                foreach (XElement each in remark.XPathSelectElements("Status/Item"))
                {
                    foreach (DataGridViewRow row in dgvStuTag.Rows)
                    {
                        if ((row.Cells[1].Value + "") == each.Value)
                            row.Cells[0].Value = true;
                    }
                }
                dynamic ethnicgroup = (DynamicXmlObject)remark.Element("EthnicGroup");
                foreach (DataGridViewRow row in dgvEthnicGroup.Rows)
                {
                    if ((row.Cells[0].Value + "") == ethnicgroup)
                        row.Selected = true;
                }
                dynamic ethnicplace = (DynamicXmlObject)remark.Element("EthnicPlace");
                foreach (DataGridViewRow row in dgvPlace.Rows)
                {
                    if ((row.Cells[0].Value + "") == ethnicplace)
                        row.Selected = true;
                }
            }
        }

        protected override ContinueDirection? OnNextButtonClick()
        {
            try
            {
                XElement remarks = new XElement("StudentRemark");

                XElement status = new XElement("Status");
                remarks.Add(new XComment("學生身份註記"));
                remarks.Add(status);
                foreach (DataGridViewRow row in dgvStuTag.Rows)
                {
                    if ((bool)row.Cells[0].Value)
                        status.Add(new XElement("Item", row.Cells[1].Value + ""));
                }

                remarks.Add(new XComment("原住民族別"));
                remarks.Add(new XElement("EthnicGroup", GetEthnicGroup()));
                remarks.Add(new XComment("原住民居住地"));
                remarks.Add(new XElement("EthnicPlace", GetEthnicPlace()));

                Arguments[Consts.StudentRemark] = remarks;

                XElement xmldata = Arguments[Consts.XmlData] as XElement;
                if (xmldata != null)
                    xmldata.Element("StudentRemark").ReplaceWith(remarks);

                return ContinueDirection.Next;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                RTOut.WriteError(ex);
                return null;
            }
        }

        private string GetEthnicPlace()
        {
            foreach (DataGridViewRow row in dgvPlace.Rows)
            {
                if (row.Selected)
                    return row.Cells[0].Value + "";
            }
            return string.Empty;
        }

        private string GetEthnicGroup()
        {
            foreach (DataGridViewRow row in dgvEthnicGroup.Rows)
            {
                if (row.Selected)
                    return row.Cells[0].Value + "";
            }
            return string.Empty;
        }

        private void dgvStuTag_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStuTag.Rows)
                row.Selected = false;
        }
    }
}
