using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentTransferAPI;
using System.Xml.Linq;
using System.Data;
using System.Windows.Forms;
using FISCA;
using K12.Data;

namespace StudentTransferCoreImpl.Processors
{
    class SemesterMoralScore : ProcessorBase
    {
        public SemesterMoralScore()
        {
            Optional = true;
        }

        public override string Title
        {
            get { return "缺曠獎懲統計"; }
        }

        public override XElement TransferOut()
        {
            string cmd = string.Format(
                     @"select *
                        from sems_moral_score
                        where ref_student_id='{0}'
                        order by school_year,semester", StudentId);

            DataTable dt = Query.Select(cmd);

            XElement semesters = new XElement("SemesterMoralScore");
            foreach (DataRow row in dt.Rows)
            {
                XElement scoreRecord = new XElement("Record");
                scoreRecord.Add(new XElement("SchoolYear", row["school_year"]));
                scoreRecord.Add(new XElement("Semester", row["semester"]));
                scoreRecord.Add(GenerateFieldData(row["text_score"] + "", "TextScore"));
                scoreRecord.Add(GenerateFieldData(row["initial_summary"] + "", "InitialSummary"));
                scoreRecord.Add(GenerateFieldData(row["summary"] + "", "Summary"));

                semesters.Add(scoreRecord);
            }

            return semesters;
        }

        private static XElement GenerateFieldData(string content, string fieldName)
        {
            string xml = string.Format("<Content>{0}</Content>", content);
            XElement objContent = XElement.Parse(xml);
            XElement result = new XElement(fieldName);

            if (objContent.HasElements)
                result.ReplaceAll(objContent.Elements());
            return result;
        }

        public override void TransferIn(XElement data)
        {
            List<MoralScoreRecord> ms = MoralScore.SelectByStudentIDs(new string[] { StudentId });
            List<ReplaceRecord> replaces = new List<ReplaceRecord>();
            Dictionary<SemesterData, XElement> xmlrecords = new Dictionary<SemesterData, XElement>();

            //建立資料庫中已有資料的清單。
            foreach (MoralScoreRecord each in ms)
                replaces.Add(new ReplaceRecord(each.ID, new SemesterData(each.SchoolYear, each.Semester)));

            //將轉入資料轉換成集合，而不是一團資料。
            foreach (XElement each in data.Elements())
            {
                int schoolYear = int.Parse(each.Element("SchoolYear").Value);
                int semester = int.Parse(each.Element("Semester").Value);

                xmlrecords.Add(new SemesterData(schoolYear, semester), each);
            }

            //尋找是否有「轉入資料」要直接取代「現有資料」的。
            foreach (ReplaceRecord each in replaces)
            {
                if (xmlrecords.ContainsKey(each.Semester))
                {
                    each.NewDataRecord = xmlrecords[each.Semester];
                    xmlrecords.Remove(each.Semester);
                }
            }

            //處理取代資料。
            List<string> updateCmds = new List<string>();
            foreach (ReplaceRecord each in replaces)
            {
                if (each.NewDataRecord == null) continue;

                string cmd = GenerateUpdateSql(each);
                updateCmds.Add(cmd);
            }
            Update.Execute(updateCmds);

            if (Program.Debug)
                foreach (string each in updateCmds)
                    RTOut.WriteSql(each);

            //處理新增資料。
            List<string> insertCmds = new List<string>();
            foreach (XElement each in xmlrecords.Values)
            {
                string cmd = GenerateInsertSql(each);
                insertCmds.Add(cmd);
            }

            Update.Execute(insertCmds);

            if (Program.Debug)
                foreach (string each in insertCmds)
                    RTOut.WriteSql(each);
        }

        private string GenerateInsertSql(XElement each)
        {
            string cmd =
                @"insert into sems_moral_score(ref_student_id,school_year,semester,text_score,initial_summary,summary)
                values('{0}','{1}','{2}','{3}','{4}','{5}')";

            string schoolYear = each.Element("SchoolYear").Value;
            string semester = each.Element("Semester").Value;

            string textScore = "";
            if (each.Element("TextScore").FirstNode != null)
                textScore = each.Element("TextScore").FirstNode.ToString().Replace("'", "''");

            string initSummary = "";
            if (each.Element("InitialSummary").FirstNode != null)
                initSummary = each.Element("InitialSummary").FirstNode.ToString().Replace("'", "''");

            string summary = "";
            if (each.Element("Summary").FirstNode != null)
                summary = each.Element("Summary").FirstNode.ToString().Replace("'", "''");

            return string.Format(cmd, StudentId, schoolYear, semester, textScore, initSummary, summary);
        }

        private string GenerateUpdateSql(ReplaceRecord each)
        {
            string cmd = "update sems_moral_score set text_score='{0}',initial_summary='{1}',summary='{2}' where id='{3}'";

            string textScore = "";
            if (each.NewDataRecord.Element("TextScore").FirstNode != null)
                textScore = each.NewDataRecord.Element("TextScore").FirstNode.ToString().Replace("'", "''");

            string initSummary = "";
            if (each.NewDataRecord.Element("InitialSummary").FirstNode != null)
                initSummary = each.NewDataRecord.Element("InitialSummary").FirstNode.ToString().Replace("'", "''");

            string summary = "";
            if (each.NewDataRecord.Element("Summary").FirstNode != null)
                summary = each.NewDataRecord.Element("Summary").FirstNode.ToString().Replace("'", "''"); 

            return string.Format(cmd, textScore, initSummary, summary, each.SID);
        }

        private class ReplaceRecord
        {
            public ReplaceRecord(string sid, SemesterData semester)
            {
                SID = sid;
                Semester = semester;
                NewDataRecord = null;
            }

            public string SID { get; set; }

            /// <summary>
            /// 將被取代資料的學期資訊。
            /// </summary>
            public SemesterData Semester { get; set; }

            /// <summary>
            /// 要取代現有資料的新資料。
            /// </summary>
            public XElement NewDataRecord { get; set; }
        }
    }
}
