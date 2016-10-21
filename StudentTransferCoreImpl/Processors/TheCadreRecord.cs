using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;
using K12.Behavior.TheCadre;

namespace StudentTransferCoreImpl.Processors
{
    /// <summary>
    /// 幹部記錄
    /// </summary>
    class TheCadreRecord : ProcessorBase
    {
        /// <summary>
        /// 無參數建構式
        /// </summary>
        public TheCadreRecord()
        {
            Optional = true;
            TransferInAdjustSupport = false;
        }

        /// <summary>
        /// 標題
        /// </summary>
        public override string Title
        {
            get { return "幹部記錄"; }
        }

        /// <summary>
        /// 轉出
        /// </summary>
        /// <returns></returns>
        public override XElement TransferOut()
        {
            string cmd = string.Format(@"select * from $behavior.thecadre where StudentID='{0}'", StudentId);

            DataTable dt = new DataTable();

            try
            {
                dt = Query.Select(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }

            XElement result = new XElement("TheCadre");

            foreach (DataRow row in dt.Rows)
            {           
                XElement record = new XElement("Record");
                record.Add(new XElement("SchoolYear", row["SchoolYear"]));
                record.Add(new XElement("Semester", row["Semester"]));
                record.Add(new XElement("ReferenceType", row["ReferenceType"]));
                record.Add(new XElement("CadreName", row["CadreName"]));
                record.Add(new XElement("Text", row["Text"]));

                result.Add(record);
            }

            return result;
        }

        /// <summary>
        /// 轉入
        /// </summary>
        /// <param name="data"></param>
        public override void TransferIn(XElement data)
        {
            SchoolObject School = new SchoolObject();

            List<SchoolObject> NewSchools = new List<SchoolObject>();

            StringBuilder sb = new StringBuilder();

            foreach (XElement each in data.Elements())
            {
                SchoolObject NewSchool = new SchoolObject();

                NewSchool.StudentID = StudentId;
                NewSchool.SchoolYear = each.Element("SchoolYear").Value;
                NewSchool.Semester = each.Element("Semester").Value;
                NewSchool.ReferenceType = each.Element("ReferenceType").Value;
                NewSchool.CadreName = each.Element("CadreName").Value;
                NewSchool.Text = each.Element("Text").Value;

                NewSchools.Add(NewSchool);
            }

            try
            {
                string cmd = string.Format(@"delete from $behavior.thecadre where StudentID='{0}'", StudentId);
                Update.Execute(cmd);

                List<string> result = NewSchools.SaveAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}