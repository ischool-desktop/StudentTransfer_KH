using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentTransferAPI;
using System.Xml.Linq;
using FISCA.Data;
using System.Data;
using System.Windows.Forms;
using FISCA;

namespace StudentTransferCoreImpl.Processors
{
    class StudentComplete : ProcessorBase
    {
        public StudentComplete()
        {
            Optional = true;
            TransferInAdjustSupport = true;
        }

        public override string Title
        {
            get { return "完整基本資料"; }
        }

        public override XElement TransferOut()
        {
            QueryHelper query = new QueryHelper();

            string cmd = string.Format(
                    @"select * from student where id={0}", StudentId);

            DataTable dt = query.Select(cmd);
            if (dt.Rows.Count <= 0)
                throw new Exception("學生已被刪除？");

            XElement fields = XElement.Parse(Properties.Resources.StudentFields);

            XElement student = new XElement("StudentComplete");
            foreach (DataRow row in dt.Rows)
            {
                foreach (XElement field in fields.Elements())
                {
                    string physical = field.AttributeText("PhysicalName");
                    string english = field.AttributeText("EnglishName");
                    bool isxmlcontent = bool.Parse(field.AttributeText("IsXmlContent"));

                    if (isxmlcontent)
                        student.Add(GenerateXmlField(english, row[physical] + ""));
                    else
                        student.Add(new XElement(english, row[physical]));
                }
            }

            return student;
        }

        public override void TransferIn(XElement data)
        {
            string cmd = "update student set {0} where id={1}";

            XElement fields = XElement.Parse(Properties.Resources.StudentFields);

            List<string> fieldList = new List<string>();
            foreach (XElement field in fields.Elements())
            {
                string physical = field.AttributeText("PhysicalName");
                string english = field.AttributeText("EnglishName");
                bool isxmlcontent = bool.Parse(field.AttributeText("IsXmlContent"));
                XElement fieldData = data.Element(english);

                if (fieldData == null) continue;

                if (isxmlcontent)
                    fieldList.Add(string.Format("{0}='{1}'", physical, ReadXmlValue(fieldData)));
                else
                {
                    if (string.IsNullOrWhiteSpace(fieldData.Value))
                        fieldList.Add(string.Format("{0}=null", physical));
                    else
                        fieldList.Add(string.Format("{0}='{1}'", physical, fieldData.Value.Replace("'", "''")));
                }
            }

            if (fieldList.Count <= 0)
            {
                RTOut.Write("沒有資料可以更新!");
                return;
            }

            Update.Execute(string.Format(cmd, string.Join(",", fieldList.ToArray()), StudentId));

            if (Program.Debug)
                RTOut.WriteSql(string.Format(cmd, string.Join(",", fieldList.ToArray()), StudentId));
        }

        private XElement GenerateXmlField(string name, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return new XElement(name);
            else
                return new XElement(name, XElement.Parse(content));
        }

        private string ReadXmlValue(XElement field)
        {
            StringBuilder sb = new StringBuilder();
            foreach (XElement each in field.Elements())
                sb.AppendLine(each.ToString());

            return sb.ToString().Replace("'", "''");
        }
    }
}
