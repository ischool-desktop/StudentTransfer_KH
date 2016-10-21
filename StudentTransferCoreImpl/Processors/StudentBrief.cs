using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentTransferAPI;
using FISCA.Data;
using System.Data;
using System.Xml.Linq;
using System.Windows.Forms;
using FISCA;

namespace StudentTransferCoreImpl.Processors
{
    class StudentBrief : ProcessorBase
    {
        public StudentBrief()
        {
            Optional = false;
        }

        public override string Title
        {
            get { return "學生基本資料"; }
        }

        public override XElement TransferOut()
        {
            string cmd = string.Format(
                    @"select name,id_number,birthdate,gender 
                    from student where id={0}", StudentId);

            DataTable dt = Query.Select(cmd);
            if (dt.Rows.Count <= 0)
                throw new Exception("學生已被刪除？");

            string stuName = dt.Rows[0]["Name"].ToString();

            XElement student = new XElement("Student");
            foreach (DataRow row in dt.Rows)
            {
                stuName = row["name"].ToString();
                student.Add(new XElement("Name", row["name"]));
                //student.Add(new XElement("EnglishName", row["english_name"]));
                student.Add(new XElement("IDNumber", row["id_number"]));
                student.Add(new XElement("Birthdate", row["birthdate"]));
                student.Add(new XElement("Gender", GenderCharacter(row["gender"] + "")));
                //student.Add(GenerateXmlField("PermanentAddress", row["permanent_address"].ToString()));
            }

            return student;
        }

        private static string GenderCharacter(string gender)
        {
            return gender == "0" ? "女" : "男";
        }

        private XElement GenerateXmlField(string name, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return new XElement(name);
            else
                return new XElement(name, XElement.Parse(content));
        }

        public override void TransferIn(XElement data)
        {
            RTOut.WriteXml(data.ToString());
        }
    }
}
