using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using K12.Service.Learning.Modules;

namespace StudentTransferCoreImpl.Processors
{
    /// <summary>
    /// 服務學習時數
    /// </summary>
    class ServiceLearningRecord : ProcessorBase
    {
        /// <summary>
        /// 無參數建構式
        /// </summary>
        public ServiceLearningRecord()
        {
            Optional = true;
            TransferInAdjustSupport = false;
        }

        /// <summary>
        /// 標題
        /// </summary>
        public override string Title
        {
            get { return "服務學習時數"; }
        }

        /// <summary>
        /// 轉出
        /// </summary>
        /// <returns></returns>
        public override XElement TransferOut()
        {
            string cmd = string.Format(
                           @"select * from $k12.service.learning.record where ref_student_id='{0}'", StudentId);

            DataTable dt = new DataTable();

            try
            {
                dt = Query.Select(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }

            XElement result = new XElement("ServiceLearningRecord");

            foreach (DataRow row in dt.Rows)
            {
                XElement record = new XElement("Record");

                record.Add(new XElement("SchoolYear", row["school_year"]));
                record.Add(new XElement("Semester", row["semester"]));
                record.Add(new XElement("OccurDate", row["occur_date"]));
                record.Add(new XElement("Reason", row["reason"]));
                record.Add(new XElement("Hours", row["hours"]));
                record.Add(new XElement("Organizers",row["organizers"]));
                record.Add(new XElement("RegisterDate",row["register_date"]));
                record.Add(new XElement("Remark", row["remark"]));

                result.Add(record);
            }

            return result;
        }

        /// <summary>
        /// 轉入
        /// </summary>
        /// <param name="data"></param>
        public override void TransferIn(XElement data)
        {
            List<SLRecord> SLRecords = new List<SLRecord>();

            StringBuilder sb = new StringBuilder();

            foreach (XElement each in data.Elements())
            {
                SLRecord NewSLRecord = new SLRecord();

                NewSLRecord.RefStudentID = StudentId;
                NewSLRecord.SchoolYear = K12.Data.Int.Parse(each.Element("SchoolYear").Value);
                NewSLRecord.Semester = K12.Data.Int.Parse(each.Element("Semester").Value);
                NewSLRecord.OccurDate = K12.Data.DateTimeHelper.ParseDirect(each.Element("OccurDate").Value);
                NewSLRecord.Reason = each.Element("Reason").Value;
                NewSLRecord.Hours = K12.Data.Decimal.Parse(each.Element("Hours").Value);
                NewSLRecord.Organizers = each.Element("Organizers").Value;
                NewSLRecord.RegisterDate = K12.Data.DateTimeHelper.ParseDirect(each.Element("RegisterDate").Value);
                NewSLRecord.Remark = each.Element("Remark").Value;

                SLRecords.Add(NewSLRecord);
            }
            try
            {
                string cmd = string.Format(@"delete from $k12.service.learning.record where ref_student_id='{0}'", StudentId);
                Update.Execute(cmd);

                List<string> result = SLRecords.SaveAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}