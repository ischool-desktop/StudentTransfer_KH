using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FISCA.Data;
using System.Xml.Linq;

namespace StudentTransferCoreImpl
{
    class Utility
    {
        /// <summary>
        /// 取得系統內假別對照
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSysAttendanceTypeNameList()
        {
            List<string> AttendanceTypeList = new List<string>();
            // query
            string query = "select content from list where name='假別對照表'";
            QueryHelper qh = new QueryHelper();
            DataTable dt = qh.Select(query);
            if(dt.Rows.Count >0)
            {
                // parse xml
                string content = dt.Rows[0][0].ToString();
                XElement elmContent = null;
                try
                {
                    elmContent = XElement.Parse(content);
                }
                catch (Exception ex) { }

                if(elmContent != null)
                {
                    foreach (XElement elm in elmContent.Elements("Absence"))
                    {
                        string name = elm.Attribute("Name").Value;

                        if (!AttendanceTypeList.Contains(name))
                            AttendanceTypeList.Add(name);
                    }
                }

            }

            return AttendanceTypeList;
        }

        /// <summary>
        /// 取得系統內節次對照
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSysAttendancePeriodNameList()
        {
            List<string> AttendancePeriodList = new List<string>();
            // query
            string query = "select content from list where name='節次對照表'";
            QueryHelper qh = new QueryHelper();
            DataTable dt = qh.Select(query);
            if (dt.Rows.Count > 0)
            {
                // parse xml
                string content = dt.Rows[0][0].ToString();
                XElement elmContent = null;
                try
                {
                    elmContent = XElement.Parse(content);
                }
                catch (Exception ex) { }

                if (elmContent != null)
                {
                    foreach (XElement elm in elmContent.Elements("Period"))
                    {
                        string name = elm.Attribute("Name").Value;

                        if (!AttendancePeriodList.Contains(name))
                            AttendancePeriodList.Add(name);
                    }
                }

            }

            return AttendancePeriodList;
        }
    }
}
