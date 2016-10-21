using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Sports.FitnessImportExport.DAO;
using System.Xml.Linq;
using System.Data;
using System.Windows.Forms;

//2016/10/21 穎驊新增社團資料
namespace StudentTransferCoreImpl.Processors
{
    class AssociationRecord : ProcessorBase
    {


        public AssociationRecord()
        {
            Optional = true;
            TransferInAdjustSupport = false;
        }

        /// <summary>
        /// 標題
        /// </summary>
        public override string Title
        {
            get { return "社團成績資料"; }
        }

        /// <summary>
        /// 轉出
        /// </summary>
        /// <returns></returns>
        public override XElement TransferOut()
        {
            XElement StudentAssociationRecordElm = new XElement("StudentAssociationRecord");

            string query = "select * from $jhschool.association.udt where studentid='" + StudentId + "'";
            DataTable dt = new DataTable();
            try
            {
                dt = Query.Select(query);

                foreach (DataRow dr in dt.Rows)
                {
                    XElement record = new XElement("Record");
                    record.SetElementValue("StudentID", GetCellValue(dr, "studentid"));
                    record.SetElementValue("SchoolYear", GetCellValue(dr, "schoolyear"));
                    record.SetElementValue("Semester", GetCellValue(dr, "semester"));
                    record.SetElementValue("Scores", GetCellValue(dr, "scores"));


                    StudentAssociationRecordElm.Add(record);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }


            return StudentAssociationRecordElm;
        }

        private string GetCellValue(DataRow dr, string name)
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
            List<StudentAssociationRecord> StudentAssociationRecordList = new List<StudentAssociationRecord>();

            try
            {
                StudentAssociationRecord NewRec = new StudentAssociationRecord();

                // 讀取資料
                foreach (XElement elm in data.Elements())
                {
                    
                    NewRec.StudentID = StudentId;                    
                    NewRec.SchoolYear = elm.Element("SchoolYear").Value;
                    NewRec.Semester = elm.Element("Semester").Value;
                    NewRec.Scores = elm.Element("Scores").Value;
                    
                    StudentAssociationRecordList.Add(NewRec);
                }

                // 先刪除舊資料
                string delquery = "delete from $jhschool.association.udt where studentid='" + StudentId + "'";
                Update.Execute(delquery);

                // 儲存資料
                StudentAssociationRecordList.SaveAll();


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
