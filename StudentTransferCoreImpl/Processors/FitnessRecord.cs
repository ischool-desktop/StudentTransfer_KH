using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Sports.FitnessImportExport.DAO;
using System.Xml.Linq;
using System.Data;

namespace StudentTransferCoreImpl.Processors
{
    class FitnessRecord:ProcessorBase
    {
        public FitnessRecord()
        {
            Optional = true;
            TransferInAdjustSupport = false;
        }

        /// <summary>
        /// 標題
        /// </summary>
        public override string Title
        {
            get { return "體適能"; }
        }

        /// <summary>
        /// 轉出
        /// </summary>
        /// <returns></returns>
        public override XElement TransferOut()
        {
            XElement StudentFitnessRecordElm = new XElement("StudentFitnessRecord");

            string query = "select * from $ischool_student_fitness where ref_student_id='"+StudentId+"'";
            DataTable dt = new DataTable();
            try
            {
                dt = Query.Select(query);

                foreach (DataRow dr in dt.Rows)
                {
                    XElement record = new XElement("Record");
                    record.SetElementValue("SchoolYear", GetCellValue(dr, "school_year"));
                    record.SetElementValue("TestDate", GetCellValue(dr, "test_date"));
                    record.SetElementValue("SchoolCategory", GetCellValue(dr, "school_category"));
                    record.SetElementValue("Height", GetCellValue(dr, "height"));
                    record.SetElementValue("HeightDegree", GetCellValue(dr, "height_degree"));
                    record.SetElementValue("Weight", GetCellValue(dr, "weight"));
                    record.SetElementValue("WeightDegree", GetCellValue(dr, "weight_degree"));
                    record.SetElementValue("SitAndReach", GetCellValue(dr, "sit_and_reach"));
                    record.SetElementValue("SitAndReachDegree", GetCellValue(dr, "sit_and_reach_degree"));
                    record.SetElementValue("StandingLongJump", GetCellValue(dr, "standing_long_jump"));
                    record.SetElementValue("StandingLongJumpDegree", GetCellValue(dr, "standing_long_jump_degree"));
                    record.SetElementValue("SitUp", GetCellValue(dr, "sit_up"));
                    record.SetElementValue("SitUpDegree", GetCellValue(dr, "sit_up_degree"));
                    record.SetElementValue("Cardiorespiratory", GetCellValue(dr, "cardiorespiratory"));
                    record.SetElementValue("CardiorespiratoryDegree", GetCellValue(dr, "cardiorespiratory_degree"));
                    StudentFitnessRecordElm.Add(record);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return StudentFitnessRecordElm;
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
            List<StudentFitnessRecord> StudentFitnessRecordList = new List<StudentFitnessRecord>();

            try
            {
                // 讀取資料
                foreach (XElement elm in data.Elements())
                {
                    StudentFitnessRecord NewRec = new StudentFitnessRecord();
                    NewRec.StudentID = StudentId;
                    NewRec.SchoolYear = int.Parse(elm.Element("SchoolYear").Value);
                    NewRec.TestDate = DateTime.Parse(elm.Element("TestDate").Value);
                    NewRec.SchoolCategory = elm.Element("SchoolCategory").Value;
                    NewRec.Height = elm.Element("Height").Value;
                    NewRec.HeightDegree = elm.Element("HeightDegree").Value;
                    NewRec.Weight = elm.Element("Weight").Value;
                    NewRec.WeightDegree = elm.Element("WeightDegree").Value;
                    NewRec.SitAndReach = elm.Element("SitAndReach").Value;
                    NewRec.SitAndReachDegree = elm.Element("SitAndReachDegree").Value;
                    NewRec.StandingLongJump = elm.Element("StandingLongJump").Value;
                    NewRec.StandingLongJumpDegree = elm.Element("StandingLongJumpDegree").Value;
                    NewRec.SitUp = elm.Element("SitUp").Value;
                    NewRec.SitUpDegree = elm.Element("SitUpDegree").Value;
                    NewRec.Cardiorespiratory = elm.Element("Cardiorespiratory").Value;
                    NewRec.CardiorespiratoryDegree = elm.Element("CardiorespiratoryDegree").Value;
                    StudentFitnessRecordList.Add(NewRec);
                }

                // 先刪除舊資料
                string delquery = "delete from $ischool_student_fitness where ref_student_id='"+StudentId+"'";
                Update.Execute(delquery);

                // 儲存資料
                StudentFitnessRecordList.SaveAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
