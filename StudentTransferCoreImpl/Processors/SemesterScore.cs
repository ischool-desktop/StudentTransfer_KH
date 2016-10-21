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
using K12.Data;

namespace StudentTransferCoreImpl.Processors
{
    class SemesterScore : ProcessorBase
    {
        public SemesterScore()
        {
            Optional = true;
        }

        public override string Title
        {
            get { return "學期成績"; }
        }

        public override XElement TransferOut()
        {
            string cmd = string.Format(
                    @"select *
                        from sems_subj_score
                        where ref_student_id='{0}'
                        order by school_year,semester", StudentId);

            DataTable dt = Query.Select(cmd);

            XElement semesters = new XElement("SemesterScore");
            foreach (DataRow row in dt.Rows)
            {
                XElement scoreRecord = new XElement("Record");
                scoreRecord.Add(new XElement("SchoolYear", row["school_year"]));
                scoreRecord.Add(new XElement("Semester", row["semester"]));
                scoreRecord.Add(new XElement("GradeYear", row["grade_year"]));

                string xml = string.Format("<Content>{0}</Content>", row["score_info"]);
                XElement score = XElement.Parse(xml);
                XElement scoreInfo = new XElement("ScoreInfo");

                if (score.HasElements)
                    scoreInfo.ReplaceAll(score.Elements());

                scoreRecord.Add(scoreInfo);

                semesters.Add(scoreRecord);
            }

            return semesters;
        }

        public override void TransferIn(XElement data)
        {
            List<SemesterScoreRecord> ms = K12.Data.SemesterScore.SelectByStudentID(StudentId);
            List<ReplaceRecord> replaces = new List<ReplaceRecord>();
            Dictionary<SemesterData, XElement> xmlrecords = new Dictionary<SemesterData, XElement>();

            //建立資料庫中已有資料的清單。
            foreach (SemesterScoreRecord each in ms)
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
                @"insert into sems_subj_score(ref_student_id,school_year,semester,grade_year,score_info) values('{0}','{1}','{2}','{3}','{4}');";

            string schoolYear = each.Element("SchoolYear").Value;
            string semester = each.Element("Semester").Value;
            string gradeYear = each.Element("GradeYear").Value;

            StringBuilder scoreInfo = new StringBuilder();
            if (each.Element("ScoreInfo") != null)
            {
                foreach (XElement score in each.Element("ScoreInfo").Elements())
                    scoreInfo.AppendLine(score.ToString().Replace("'","''"));
            }

            return string.Format(cmd, StudentId, schoolYear, semester, gradeYear, scoreInfo);
        }

        private string GenerateUpdateSql(ReplaceRecord each)
        {
            string cmd = "update sems_subj_score set score_info='{0}' where id='{1}'";

            StringBuilder scoreInfo = new StringBuilder();
            if (each.NewDataRecord.Element("ScoreInfo") != null)
            {
                foreach (XElement score in each.NewDataRecord.Element("ScoreInfo").Elements())
                    scoreInfo.AppendLine(score.ToString().Replace("'","''"));
            }

            return string.Format(cmd, scoreInfo, each.SID);
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
