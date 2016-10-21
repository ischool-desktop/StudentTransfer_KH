using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.Windows.Forms;

//2016/10/21 穎驊新增高關懷資料
namespace StudentTransferCoreImpl.Processors
{
    class HighConcernRecord :ProcessorBase
    {

        String IDNumber;
        String StudentNumber;
        String StudentName;
        String ClassName;
        String SeatNo;
        String DocNo;
        String NumberReduce;
        String EDoc;


           public HighConcernRecord()
        {
            Optional = true;
            TransferInAdjustSupport = false;
        }

        /// <summary>
        /// 標題
        /// </summary>
        public override string Title
        {
            get { return "高關懷特殊身分資料"; }
        }

        /// <summary>
        /// 轉出
        /// </summary>
        /// <returns></returns>
        public override XElement TransferOut()
        {
            XElement StudentHighConcernRecordElm = new XElement("StudentHighConcernRecord");

            string query = "select * from $kh.automatic.placement.high.concern where ref_student_id='" + StudentId + "'";
            DataTable dt = new DataTable();
            try
            {
                dt = Query.Select(query);

                foreach (DataRow dr in dt.Rows)
                {
                    XElement record = new XElement("Record");
                    record.SetElementValue("RefStudentID", GetCellValue(dr, "ref_student_id"));
                    record.SetElementValue("ClassName", GetCellValue(dr, "class_name"));
                    record.SetElementValue("SeatNo", GetCellValue(dr, "seat_no"));
                    record.SetElementValue("StudentNumber", GetCellValue(dr, "student_number"));
                    record.SetElementValue("HighConcern", GetCellValue(dr, "high_concern"));
                    record.SetElementValue("NumberReduce", GetCellValue(dr, "number_reduce"));
                    record.SetElementValue("DocNo", GetCellValue(dr, "doc_no"));
                    record.SetElementValue("EDoc", GetCellValue(dr, "e_doc"));

                    StudentHighConcernRecordElm.Add(record);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }


            return StudentHighConcernRecordElm;
        }

        private string GetCellValue(DataRow dr,string name)
        {
            string retVal = "";
            if (dr[name] != null)
                retVal = dr[name].ToString();

            return retVal;
        }

        /// <summary>
        /// 轉入
        /// </summary>
        /// <param name="data"></param>
        public override void TransferIn(XElement data)
        {
            List<UDT_HighConcern> StudentHighConcernRecordList = new List<UDT_HighConcern>();

            try
            {
                UDT_HighConcern NewRec = new UDT_HighConcern();

                // 讀取資料
                foreach (XElement elm in data.Elements())
                {
                    
                    //NewRec.RefStudentID = elm.Element("RefStudentID").Value;
                    NewRec.RefStudentID = StudentId;
                    //NewRec.ClassName = elm.Element("ClassName").Value;
                    //NewRec.SeatNo = elm.Element("SeatNo").Value;
                    //NewRec.StudentNumber = elm.Element("StudentNumber").Value;
                    NewRec.HighConcern = Convert.ToBoolean(elm.Element("HighConcern").Value);
                    NewRec.NumberReduce = int.Parse(elm.Element("NumberReduce").Value);
                    NewRec.DocNo = elm.Element("DocNo").Value;
                    NewRec.EDoc = elm.Element("EDoc").Value;


                    StudentHighConcernRecordList.Add(NewRec);
                }

                // 先刪除舊資料
                string delquery = "delete from $kh.automatic.placement.high.concern where ref_student_id='" + StudentId + "'";
                Update.Execute(delquery);

                // 儲存資料
                StudentHighConcernRecordList.SaveAll();

                if (StudentHighConcernRecordList.Count > 0)                 
                {
                    #region 傳送變更高關懷給局端

                    K12.Data.StudentRecord TranInstudent = K12.Data.Student.SelectByID(StudentId);

                    if (TranInstudent != null)
                    {
                        IDNumber = TranInstudent.IDNumber;
                        StudentNumber = TranInstudent.StudentNumber;
                        StudentName = TranInstudent.Name;

                        if (TranInstudent.Class != null)
                        {
                            ClassName = TranInstudent.Class.Name;
                        }
                        else
                        {
                            ClassName = "";
                        }
                        SeatNo = TranInstudent.SeatNo + "";
                    }
                    else
                    {
                        IDNumber = "";
                        StudentNumber = "";
                        StudentName = "";
                        ClassName = "";
                        SeatNo = "";
                    }
                    DocNo = NewRec.DocNo;
                    NumberReduce = NewRec.NumberReduce + "";
                    EDoc = NewRec.EDoc;

                    // 傳送至局端回報此生為高關懷學生
                    string errMsg = Utility.SendData("變更特殊身分", IDNumber, StudentNumber, StudentName, ClassName, SeatNo, DocNo, NumberReduce, EDoc);
                    if (errMsg != "")
                    {
                        FISCA.Presentation.Controls.MsgBox.Show(errMsg);
                    }
                    #endregion                
                }                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
