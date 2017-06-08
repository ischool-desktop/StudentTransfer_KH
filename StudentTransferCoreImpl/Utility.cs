using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FISCA.Data;
using System.Xml.Linq;
using FISCA.DSAClient;
using System.Net;
using System.IO;

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


        //2016/10/20 穎驊註解，下面SendData()方法是自專案"KH_HighConcern" Copy過來直接用

        /// <summary>
        /// 將高關懷的學生資料傳回去給局端
        /// </summary>
        /// <returns></returns>

        public static string SendData(string action, string IDNumber, string StudentNumber, string StudentName, string ClassName, string SeatNo, string DocNo, string NumberReduce, string EDoc)
        {



            string DSNS = FISCA.Authentication.DSAServices.AccessPoint;

            string AccessPoint = @"j.kh.edu.tw";

            if (FISCA.RTContext.IsDiagMode)
            {
                string accPoint = FISCA.RTContext.GetConstant("KH_AccessPoint");
                if (!string.IsNullOrEmpty(accPoint))
                    AccessPoint = accPoint;
            }

            string Contract = "log";
            string ServiceName = "_.InsertLog";

            string errMsg = "";
            try
            {
                {
                    XElement xmlRoot = new XElement("Request");
                    XElement s1 = new XElement("SchoolLog");
                    XElement s2 = new XElement("Field");

                    s2.SetElementValue("DSNS", DSNS);
                    s2.SetElementValue("Action", action);
                    XElement Content = new XElement("Content");
                    Content.SetElementValue("IDNumber", IDNumber);
                    Content.SetElementValue("StudentNumber", StudentNumber);
                    Content.SetElementValue("StudentName", StudentName);
                    Content.SetElementValue("ClassName", ClassName);
                    Content.SetElementValue("SeatNo", SeatNo);
                    Content.SetElementValue("NumberReduce", NumberReduce);
                    Content.SetElementValue("DocNo", DocNo);
                    Content.SetElementValue("EDoc", EDoc);
                    s2.Add(Content);
                    s1.Add(s2);
                    xmlRoot.Add(s1);
                    XmlHelper reqXML = new XmlHelper(xmlRoot.ToString());
                    FISCA.DSAClient.Connection cn = new FISCA.DSAClient.Connection();
                    cn.Connect(AccessPoint, Contract, DSNS, DSNS);
                    Envelope rsp = cn.SendRequest(ServiceName, new Envelope(reqXML));
                    XElement rspXML = XElement.Parse(rsp.XmlString);                
                }

                //2017/6/7 穎驊新增 高雄項目 [03-01][03] 巨耀局端介接學生資料欄位 巨耀自動編班 更新Service                
                try
                {
                    string urlString = "http://163.32.129.9/khdc/ito";
                    // 準備 Http request
                    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(urlString);
                    req.Method = "POST";

                    // 呼叫並取得結果
                    HttpWebResponse rsp;
                    rsp = (HttpWebResponse)req.GetResponse();

                    Stream dataStream = rsp.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);

                    string response = reader.ReadToEnd(); //檢查使用，若成功回傳，response 值為 "00"

                    reader.Close();
                    dataStream.Close();
                    rsp.Close();
                }
                catch (Exception e)
                {

                }
            }
            catch (Exception ex) { errMsg = ex.Message; }
            {
                return errMsg;
            
            }

            

           
        }



    }
}
