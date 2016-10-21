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
    class MoralScoreDetail : ProcessorBase
    {
        public MoralScoreDetail()
        {
            Optional = true;
        }

        public override string Title
        {
            get { return "缺曠獎懲明細"; }
        }

        public override XElement TransferOut()
        {
            string cmd = string.Format(
                     @"select *
                        from discipline
                        where ref_student_id='{0}'
                        order by school_year,semester", StudentId);

            DataTable dt = Query.Select(cmd);

            XElement moralDetails = new XElement("MoralDetails");
            XElement discipline = new XElement("Discipline");
            moralDetails.Add(discipline);

            foreach (DataRow row in dt.Rows)
            {
                XElement record = new XElement("Record");
                record.Add(new XElement("SchoolYear", row["school_year"]));
                record.Add(new XElement("Semester", row["semester"]));
                record.Add(new XElement("OccurDate", row["occur_date"]));
                record.Add(new XElement("Reason", row["reason"]));
                record.Add(GenerateFieldData(row["detail"] + "", "Detail"));
                record.Add(new XElement("Type", row["type"]));
                record.Add(new XElement("MeritFlag", row["merit_flag"]));
                record.Add(new XElement("RegisterDate", row["register_date"]));
                discipline.Add(record);
            }

            XElement attendance = new XElement("Attendance");

            //節次對照表
            cmd = "select content from list where name='節次對照表'";
            dt = Query.Select(cmd);

            if (dt.Rows.Count > 0)
                attendance.Add(XElement.Parse(dt.Rows[0]["content"].ToString()));

            cmd = string.Format(
            @"select *
                        from attendance
                        where ref_student_id='{0}'
                        order by school_year,semester", StudentId);

            dt = Query.Select(cmd);

            moralDetails.Add(attendance);

            foreach (DataRow row in dt.Rows)
            {
                XElement record = new XElement("Record");
                record.Add(new XElement("SchoolYear", row["school_year"]));
                record.Add(new XElement("Semester", row["semester"]));
                record.Add(new XElement("OccurDate", row["occur_date"]));
                record.Add(GenerateFieldData(row["detail"] + "", "Detail"));
                attendance.Add(record);
            }

            return moralDetails;
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
            List<string> cmds = new List<string>();
            cmds.Add(string.Format("delete from discipline where ref_student_id={0};", StudentId));
            cmds.Add(string.Format("delete from attendance where ref_student_id={0};", StudentId));

            foreach (XElement each in data.Element("Discipline").Elements("Record"))
                cmds.Add(GenDisciplineInsertSql(each));

            foreach (XElement each in data.Element("Attendance").Elements("Record"))
                cmds.Add(GenAttendanceInsertSql(each));

            StringBuilder sb = new StringBuilder();
            foreach (string each in cmds)
                sb.AppendLine(each);
            RTOut.WriteSql(sb.ToString());

            Update.Execute(cmds);

            #region 檢查缺曠轉入後資料是否存在
            bool AttendanceTypeError = false;
            bool AttendancePeriodError = false;

            // 取得系統內缺曠名稱
            List<string> SysAttendanceTypeList = Utility.GetSysAttendanceTypeNameList();
            // 取得系統內節次名稱
            List<string> SysAttendancePeriodList = Utility.GetSysAttendancePeriodNameList();
            
            // 取得 學生缺曠資料
            string query = "select detail from attendance where ref_student_id=" + StudentId;
            FISCA.Data.QueryHelper qh = new FISCA.Data.QueryHelper();
            DataTable dt = qh.Select(query);

            if(dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    string detail = dr[0].ToString();
                    XElement elmDetail = null;
                    try
                    {
                        elmDetail = XElement.Parse(detail);

                        foreach(XElement elm in elmDetail.Elements("Period"))
                        {
                            string period = elm.Value;
                            string Atype = elm.Attribute("AbsenceType").Value;

                            if(!SysAttendancePeriodList.Contains(period))
                                AttendancePeriodError = true;

                            if (!SysAttendanceTypeList.Contains(Atype))
                                AttendanceTypeError = true;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            
            if(AttendanceTypeError)
            {
                string msg = "學生缺曠假別與系統內假別設定不同，請使用系統功能[資料合理性檢查]->[學務]->[學生缺曠資料與系統假別]來調整。";
                FISCA.Presentation.Controls.MsgBox.Show(msg, "缺曠假別不同", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

            if(AttendancePeriodError)
            {
                string msg = "學生缺曠節次與系統內節次設定不同，請使用系統功能[資料合理性檢查]->[學務]->[學生缺曠資料與系統節次]來調整。";
                FISCA.Presentation.Controls.MsgBox.Show(msg, "缺曠節次不同", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

            #endregion
        }

        private string GenDisciplineInsertSql(XElement each)
        {
            string cmd =
                @"insert into discipline(school_year,semester,occur_date,reason,detail,ref_student_id,type,merit_flag,register_date)
                values('{0}','{1}',{2},'{3}','{4}','{5}',{6},'{7}',{8});";

            string schoolYear = each.Element("SchoolYear").Value;
            string semester = each.Element("Semester").Value;
            string occurDate = each.Element("OccurDate").Value;
            if (string.IsNullOrWhiteSpace(occurDate))
                occurDate = "null";
            else
                occurDate = string.Format("'{0}'", occurDate);

            string reason = each.Element("Reason").Value.Replace("'", "''");
            string type = each.Element("Type").Value;
            if (string.IsNullOrWhiteSpace(type))
                type = "null";
            else
                type = string.Format("'{0}'", type);

            string meritFlag = each.Element("MeritFlag").Value;
            string registerDate = each.Element("RegisterDate").Value;
            if (string.IsNullOrWhiteSpace(registerDate))
                registerDate = "null";
            else
                registerDate = string.Format("'{0}'", registerDate);

            string detail = "";
            if (each.Element("Detail").FirstNode != null)
                detail = each.Element("Detail").FirstNode.ToString().Replace("'", "''");

            return string.Format(cmd, schoolYear, semester, occurDate, reason, detail, StudentId, type, meritFlag, registerDate);
        }

        private string GenAttendanceInsertSql(XElement each)
        {
            string cmd =
                @"insert into attendance(ref_student_id,school_year,semester,occur_date,detail)
                    values('{0}','{1}','{2}',{3},'{4}');";

            string schoolYear = each.Element("SchoolYear").Value;
            string semester = each.Element("Semester").Value;
            string occurDate = each.Element("OccurDate").Value;
            if (string.IsNullOrWhiteSpace(occurDate))
                occurDate = "null";
            else
                occurDate = string.Format("'{0}'", occurDate);

            string detail = "";
            if (each.Element("Detail").FirstNode != null)
                detail = each.Element("Detail").FirstNode.ToString().Replace("'","''");

            return string.Format(cmd, StudentId, schoolYear, semester, occurDate, detail);
        }
    }
}
