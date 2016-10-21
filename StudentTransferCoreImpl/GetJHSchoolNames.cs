using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using FISCA;

namespace StudentTransferCoreImpl
{
    public partial class GetJHSchoolNames : FISCA.Presentation.Controls.BaseForm
    {
        Dictionary<string, List<SchoolListEntity>> JuniroList = new Dictionary<string, List<SchoolListEntity>>();
        Dictionary<string, List<SchoolListEntity>> ElementaryList = new Dictionary<string, List<SchoolListEntity>>();
        Dictionary<string, List<SchoolListEntity>> AllList = new Dictionary<string, List<SchoolListEntity>>();
        Dictionary<string, List<SchoolListEntity>> otherList = new Dictionary<string, List<SchoolListEntity>>();
        private string _County;
        //private string _SchoolCode;
        private string _SchoolName;

        public string County
        { get { return _County; } }

        //public string SchoolCode
        //{ get { return _SchoolCode; } }
        public string SchoolName
        { get { return _SchoolName; } }

        public GetJHSchoolNames()
        {
            InitializeComponent();
            List<SchoolListEntity> schoolLists = new List<SchoolListEntity>();

            // 讀取國中小資料
            //ConfigData cd = Global.Configuration["SchoolListJunior"];
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(StudentTransferCoreImpl.Properties.Resources.jh);
            //doc.LoadXml(cd["XmlData"]);
            XmlElement docelm = doc.DocumentElement;
            foreach (XmlElement xe in docelm.SelectNodes("School"))
            {
                SchoolListEntity sle = new SchoolListEntity();
                sle.Name = xe.GetAttribute("Name");
                sle.code = xe.GetAttribute("Code");
                sle.county = xe.GetAttribute("County");
                schoolLists.Add(sle);
            }

            // 國中
            foreach (SchoolListEntity sle in schoolLists)
            {
                if (sle.Name.LastIndexOf("附設國") > 0)
                {
                    if (otherList.ContainsKey(sle.county))
                        otherList[sle.county].Add(sle);
                    else
                    {
                        List<SchoolListEntity> tmpSle = new List<SchoolListEntity>();
                        tmpSle.Add(sle);
                        otherList.Add(sle.county, tmpSle);
                    }
                }
                else
                {
                    if (JuniroList.ContainsKey(sle.county))
                        JuniroList[sle.county].Add(sle);
                    else
                    {
                        List<SchoolListEntity> tmpSle = new List<SchoolListEntity>();
                        tmpSle.Add(sle);
                        JuniroList.Add(sle.county, tmpSle);
                    }
                }

                // 放入全部
                if (AllList.ContainsKey(sle.county))
                    AllList[sle.county].Add(sle);
                else
                {
                    List<SchoolListEntity> tmpSle = new List<SchoolListEntity>();
                    tmpSle.Add(sle);
                    AllList.Add(sle.county, tmpSle);
                }

            }

            schoolLists.Clear();
            //ConfigData cd1 = Global.Configuration["SchoolListElementary"];
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(StudentTransferCoreImpl.Properties.Resources.eh);
            //doc1.LoadXml(cd1["XmlData"]);
            foreach (XmlElement xe in doc1.SelectSingleNode("SchoolList"))
            {
                SchoolListEntity sle = new SchoolListEntity();
                sle.Name = xe.GetAttribute("Name");
                sle.code = xe.GetAttribute("Code");
                sle.county = xe.GetAttribute("County");
                schoolLists.Add(sle);
            }

            //國小
            foreach (SchoolListEntity sle in schoolLists)
            {
                if (ElementaryList.ContainsKey(sle.county))
                    ElementaryList[sle.county].Add(sle);
                else
                {
                    List<SchoolListEntity> tmpSle = new List<SchoolListEntity>();
                    tmpSle.Add(sle);
                    ElementaryList.Add(sle.county, tmpSle);
                }

                if (AllList.ContainsKey(sle.county))
                    AllList[sle.county].Add(sle);
                else
                {
                    List<SchoolListEntity> tmpSle = new List<SchoolListEntity>();
                    tmpSle.Add(sle);
                    AllList.Add(sle.county, tmpSle);
                }
            }

            // 放入 List View
            foreach (KeyValuePair<string, List<SchoolListEntity>> lst in AllList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems[0].Text = lst.Key;
                lstCounty.Items.Add(lvi);
                lvi = null;
            }
            lstCounty.Sorting = SortOrder.Ascending;
            lstCounty.Sort();
            chkJH1.Checked = true;
        }

        private void setCountySchool(string county)
        {
            lstSchool.Items.Clear();
            if (chkAll.Checked == true)
            {
                if (AllList.ContainsKey(county))
                {
                    setLstSchoolSubItemData(AllList[county]);

                }

            }

            if (chkElm.Checked == true)
            {
                if (ElementaryList.ContainsKey(county))
                {
                    setLstSchoolSubItemData(ElementaryList[county]);

                }
            }

            if (chkJH1.Checked == true)
            {

                if (JuniroList.ContainsKey(county))
                {
                    setLstSchoolSubItemData(JuniroList[county]);

                }
            }

            if (chkJh2.Checked == true)
            {
                if (otherList.ContainsKey(county))
                {
                    setLstSchoolSubItemData(otherList[county]);

                }
            }
        }

        // 設定 lstSchool subitem data
        private void setLstSchoolSubItemData(List<SchoolListEntity> SLES)
        {
            lstSchool.Columns[2].Width = 320;
            foreach (SchoolListEntity sle in SLES)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems[0].Text = sle.county;
                lvi.SubItems.Add(sle.code);
                lvi.SubItems.Add(sle.Name);
                lstSchool.Items.Add(lvi);
                lvi = null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lstSchool.SelectedItems.Count > 0)
            {
                this._County = lstSchool.SelectedItems[0].SubItems[0].Text;
                this._SchoolName = lstSchool.SelectedItems[0].SubItems[2].Text;
            }
            this.DialogResult = DialogResult.OK;

            //XmlDocument doc = new XmlDocument();
            //XmlDocument doc1 = new XmlDocument();


            //doc.Load(@"c:\國中學校代碼.xml");
            //ConfigData cd = Global.ConfigurationWritable ["SchoolListJunior"];
            //cd["XmlData"] = doc.OuterXml;
            //cd.Save();

            //doc1.Load(@"c:\國小學校代碼.xml");
            //ConfigData cd1 = Global.ConfigurationWritable ["SchoolListElementary"];
            //cd1["XmlData"] = doc1.OuterXml;
            //cd1.Save();

        }

        private class SchoolListEntity
        {
            public string county { get; set; }
            public string code { get; set; }
            public string Name { get; set; }
        }

        private void lstCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            setCountySchool1();
        }

        private void setCountySchool1()
        {
            if (lstCounty.SelectedItems.Count > 0)
                setCountySchool(lstCounty.SelectedItems[0].Text);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            lstSchool.Items.Clear();
            setCountySchool1();
            lstCounty.Focus();
        }

        private void GetJHSchoolNames_Load(object sender, EventArgs e)
        {
            try
            {
                string index = Application.UserAppDataRegistry.GetValue("SelectedCountyIndex", "0").ToString();
                lstCounty.Items[int.Parse(index)].Selected = true;
                lstCounty.EnsureVisible(int.Parse(index));
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
            }

            //foreach (ListViewItem lvi in lstCounty.Items)
            //{
            //    if(JHSchool.Permrec.Program.ModuleType == JHSchool.Permrec.Program.ModuleFlag.KaoHsiung )
            //        if (lvi.Text == "高雄市")
            //            lvi.Selected = true;

            //    if (JHSchool.Permrec.Program.ModuleType == JHSchool.Permrec.Program.ModuleFlag.HsinChu)
            //        if (lvi.Text == "新竹市")
            //            lvi.Selected = true;

            //    if (JHSchool.Permrec.Program.ModuleType == JHSchool.Permrec.Program.ModuleFlag.TaiChung)
            //        if (lvi.Text == "台中縣")
            //            lvi.Selected = true;            
            //}
        }

        private void GetJHSchoolNames_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("SelectedCountyIndex", lstCounty.SelectedIndices[0]);
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
            }
        }
    }
}
