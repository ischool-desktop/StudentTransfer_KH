using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentTransferAPI;
using System.Xml.Linq;
using System.Data;
using System.Windows.Forms;
using K12.Data;

namespace StudentTransferCoreImpl.Processors
{
    class SemesterHistory : ProcessorBase
    {
        public SemesterHistory()
        {
            Optional = false;
            TransferInAdjustSupport = false;
        }

        public override string Title
        {
            get { return "學期歷程"; }
        }

        public override XElement TransferOut()
        {
            string cmd = string.Format(
                           @"select sems_history
                    from student where id={0}", StudentId);

            DataTable dt = Query.Select(cmd);
            if (dt.Rows.Count <= 0)
                throw new Exception("學生已被刪除？");

            XElement result = new XElement("SemesterHistory");
            foreach (DataRow row in dt.Rows)
            {
                string xml = string.Format("<Content>{0}</Content>", row["sems_history"] + "");
                XElement histories = XElement.Parse(xml);
                if (histories.HasElements)
                    result.ReplaceAll(histories.Elements());
            }

            return result;
        }

        public override void TransferIn(XElement data)
        {
            string cmd = "update student set sems_history='{0}' where id='{1}'";

            StringBuilder sb = new StringBuilder();
            foreach (XElement each in data.Elements())
                sb.AppendLine(each.ToString());

            Update.Execute(string.Format(cmd, sb.ToString(), StudentId));
        }
    }
}
