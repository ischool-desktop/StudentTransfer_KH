using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Aspose.Cells;
using System.Xml.XPath;

namespace StudentTransferCoreImpl
{
    class ExportToExcel
    {
        private XElement Data { get; set; }

        private Workbook Book { get; set; }

        private XElement Student { get { return Data.Element("Student"); } }
        private XElement StudentComplete { get { return Data.Element("StudentComplete"); } }

        public ExportToExcel(XElement data)
        {
            Data = data;
        }

        public Workbook Export()
        {
            Book = new Workbook();
            Book.Worksheets.Clear();

            ExportBasicData(Book.Worksheets[Book.Worksheets.Add()]); //匯出基本資料
            ExportSemesterHistory(Book.Worksheets[Book.Worksheets.Add()]); //匯出學期歷程
            ExportSemesterScore(Book.Worksheets[Book.Worksheets.Add()]); //匯出學期科目成績
            ExportDomainScore(Book.Worksheets[Book.Worksheets.Add()]); //匯出學期領域成績
            ExportDisciplineMeritScore(Book.Worksheets[Book.Worksheets.Add()]); //匯出獎勵明細
            ExportDisciplineDemeritScore(Book.Worksheets[Book.Worksheets.Add()]); //匯出懲戒明細
            ExportAttendanceScore(Book.Worksheets[Book.Worksheets.Add()]); //匯出懲戒明細
            Book.Worksheets[0].AutoFitColumns();
            return Book;
        }

        private void ExportAttendanceScore(Worksheet sheet)
        {
            sheet.Name = "缺曠明細";

            int headerFieldIndex = 0;

            sheet.Cells[0, headerFieldIndex++].PutValue("學年度");
            sheet.Cells[0, headerFieldIndex++].PutValue("學期");
            sheet.Cells[0, headerFieldIndex++].PutValue("日期");

            XElement records = Data.XPathSelectElement("MoralDetails/Attendance");

            if (records == null) return;

            List<PeriodData> periods = new List<PeriodData>();
            foreach (XElement each in records.XPathSelectElements("Periods/Period"))
                periods.Add(new PeriodData(each));

            //排序
            periods.Sort((x, y) => x.Sort.CompareTo(y.Sort));

            foreach (PeriodData each in periods)
            {
                each.Index = headerFieldIndex;
                sheet.Cells[0, headerFieldIndex++].PutValue(each.Title);
            }

            Dictionary<string, PeriodData> periodMap = periods.ToDictionary(x => x.Title);

            int rowIndex = 1;
            foreach (XElement record in records.Elements("Record"))
            {
                int fieldIndex = 0;

                string sy = record.Element("SchoolYear").String();
                string ss = record.Element("Semester").String();

                sheet.Cells[rowIndex, fieldIndex++].PutValue(sy);
                sheet.Cells[rowIndex, fieldIndex++].PutValue(ss);
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.Element("OccurDate").DateString());

                foreach (XElement period in record.XPathSelectElements("Detail/Attendance/Period"))
                {
                    string title = period.String();

                    if (!periodMap.ContainsKey(title))
                    {
                        PeriodData p = new PeriodData();
                        p.Title = title;
                        p.Index = headerFieldIndex++;
                    }

                    sheet.Cells[rowIndex, periodMap[title].Index].PutValue(period.Attribute("AbsenceType").String());
                }

                rowIndex++;
            }
        }

        private class PeriodData
        {
            private static int DefaultSort = 0;

            public PeriodData()
            {
            }

            public PeriodData(XElement data)
            {
                DefaultSort++;

                Sort = data.Attribute("Sort").Int(DefaultSort);
                Title = data.Attribute("Name").String();
                Index = 100;
            }

            public string Title { get; set; }

            public int Sort { get; set; }

            public int Index { get; set; }
        }

        private void ExportDisciplineDemeritScore(Worksheet sheet)
        {
            sheet.Name = "懲戒明細";

            sheet.Cells[0, 0].PutValue("學年度");
            sheet.Cells[0, 1].PutValue("學期");
            sheet.Cells[0, 2].PutValue("日期");
            sheet.Cells[0, 3].PutValue("事由");
            sheet.Cells[0, 4].PutValue("大過");
            sheet.Cells[0, 5].PutValue("小過");
            sheet.Cells[0, 6].PutValue("警告");

            XElement records = Data.Element("MoralDetails");

            if (records == null) return;

            int rowIndex = 1;
            foreach (XElement record in records.XPathSelectElements("Discipline/Record[MeritFlag='0']"))
            {
                int fieldIndex = 0;

                string sy = record.Element("SchoolYear").String();
                string ss = record.Element("Semester").String();

                sheet.Cells[rowIndex, fieldIndex++].PutValue(sy);
                sheet.Cells[rowIndex, fieldIndex++].PutValue(ss);
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.Element("OccurDate").DateString());
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.Element("Reason").String());
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.XPathSelectElement("Detail/Discipline/Demerit").Attribute("A").String());
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.XPathSelectElement("Detail/Discipline/Demerit").Attribute("B").String());
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.XPathSelectElement("Detail/Discipline/Demerit").Attribute("C").String());

                rowIndex++;
            }
        }

        private void ExportDisciplineMeritScore(Worksheet sheet)
        {
            sheet.Name = "獎勵明細";

            sheet.Cells[0, 0].PutValue("學年度");
            sheet.Cells[0, 1].PutValue("學期");
            sheet.Cells[0, 2].PutValue("日期");
            sheet.Cells[0, 3].PutValue("事由");
            sheet.Cells[0, 4].PutValue("大功");
            sheet.Cells[0, 5].PutValue("小功");
            sheet.Cells[0, 6].PutValue("嘉獎");

            XElement records = Data.Element("MoralDetails");

            if (records == null) return;

            int rowIndex = 1;
            foreach (XElement record in records.XPathSelectElements("Discipline/Record[MeritFlag='1']"))
            {
                int fieldIndex = 0;

                string sy = record.Element("SchoolYear").String();
                string ss = record.Element("Semester").String();

                sheet.Cells[rowIndex, fieldIndex++].PutValue(sy);
                sheet.Cells[rowIndex, fieldIndex++].PutValue(ss);
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.Element("OccurDate").DateString());
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.Element("Reason").String());
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.XPathSelectElement("Detail/Discipline/Merit").Attribute("A").String());
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.XPathSelectElement("Detail/Discipline/Merit").Attribute("B").String());
                sheet.Cells[rowIndex, fieldIndex++].PutValue(record.XPathSelectElement("Detail/Discipline/Merit").Attribute("C").String());

                rowIndex++;
            }
        }

        private void ExportDomainScore(Worksheet sheet)
        {
            sheet.Name = "學期領域成績";

            sheet.Cells[0, 0].PutValue("學年度");
            sheet.Cells[0, 1].PutValue("學期");
            sheet.Cells[0, 2].PutValue("領域");
            sheet.Cells[0, 3].PutValue("節數");
            sheet.Cells[0, 4].PutValue("權數");
            sheet.Cells[0, 5].PutValue("成績");
            sheet.Cells[0, 6].PutValue("文字描述");
            sheet.Cells[0, 7].PutValue("努力程度");

            XElement semsScore = Data.Element("SemesterScore");

            if (semsScore == null) return;

            int rowIndex = 1;
            foreach (XElement record in semsScore.Elements("Record"))
            {
                string sy = record.Element("SchoolYear").String();
                string ss = record.Element("Semester").String();

                foreach (XElement subject in record.XPathSelectElements("ScoreInfo/Domains/Domain"))
                {
                    int fieldIndex = 0;

                    sheet.Cells[rowIndex, fieldIndex++].PutValue(sy);
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(ss);
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("領域").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("節數").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("權數").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("成績").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("文字描述").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("努力程度").String());

                    rowIndex++;
                }
            }
        }

        private void ExportSemesterScore(Worksheet sheet)
        {
            sheet.Name = "學期科目成績";

            sheet.Cells[0, 0].PutValue("學年度");
            sheet.Cells[0, 1].PutValue("學期");
            sheet.Cells[0, 2].PutValue("領域");
            sheet.Cells[0, 3].PutValue("科目");
            sheet.Cells[0, 4].PutValue("節數");
            sheet.Cells[0, 5].PutValue("權數");
            sheet.Cells[0, 6].PutValue("成績");
            sheet.Cells[0, 7].PutValue("文字描述");
            sheet.Cells[0, 8].PutValue("努力程度");

            XElement semsScore = Data.Element("SemesterScore");

            if (semsScore == null) return;

            int rowIndex = 1;
            foreach (XElement record in semsScore.Elements("Record"))
            {
                string sy = record.Element("SchoolYear").String();
                string ss = record.Element("Semester").String();

                foreach (XElement subject in record.XPathSelectElements("ScoreInfo/SemesterSubjectScoreInfo/Subject"))
                {
                    int fieldIndex = 0;

                    sheet.Cells[rowIndex, fieldIndex++].PutValue(sy);
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(ss);
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("領域").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("科目").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("節數").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("權數").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("成績").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("文字描述").String());
                    sheet.Cells[rowIndex, fieldIndex++].PutValue(subject.Attribute("努力程度").String());

                    rowIndex++;
                }
            }
        }

        private void ExportSemesterHistory(Worksheet sheet)
        {
            sheet.Name = "學期歷程";

            XElement history = Data.Element("SemesterHistory");

            sheet.Cells[0, 0].PutValue("學年度");
            sheet.Cells[0, 1].PutValue("學期");
            sheet.Cells[0, 2].PutValue("年級");

            if (history == null) return;

            int rowIndex = 1;
            foreach (XElement each in history.Elements())
            {
                string sy = each.Attribute("SchoolYear").String();
                string ss = each.Attribute("Semester").String();
                string gy = each.Attribute("GradeYear").String();

                sheet.Cells[rowIndex, 0].PutValue(sy);
                sheet.Cells[rowIndex, 1].PutValue(ss);
                sheet.Cells[rowIndex, 2].PutValue(gy);

                rowIndex++;
            }
        }

        #region 基本資料
        private void ExportBasicData(Worksheet basic)
        {
            basic.Name = "基本資料";

            List<FieldData> fieldMap = CreateMap(XElement.Parse(Properties.Resources.ExportNameMap));

            int fieldIndex = 0;

            XElement student = Student;
            basic.Cells[fieldIndex, 0].PutValue("姓名");
            basic.Cells[fieldIndex++, 1].PutValue(student.Element("Name").String());
            basic.Cells[fieldIndex, 0].PutValue("身分證號");
            basic.Cells[fieldIndex++, 1].PutValue(student.Element("IDNumber").String());
            basic.Cells[fieldIndex, 0].PutValue("生日");
            basic.Cells[fieldIndex++, 1].PutValue(student.Element("Birthdate").DateString());
            basic.Cells[fieldIndex, 0].PutValue("性別");
            basic.Cells[fieldIndex++, 1].PutValue(student.Element("Gender").String());

            XElement stuCom = StudentComplete;
            foreach (FieldData field in fieldMap)
            {
                Func<XElement, string> parser = GetParser(field.DataParser);

                basic.Cells[fieldIndex, 0].PutValue(field.Chinese);
                basic.Cells[fieldIndex, 1].PutValue(parser(stuCom.XPathSelectElement(field.Pattern)));

                fieldIndex++;
            }
        }

        private List<FieldData> CreateMap(XElement xElement)
        {
            List<FieldData> fields = new List<FieldData>();

            foreach (XElement field in xElement.Elements())
                fields.Add(new FieldData(field));

            return fields;
        }


        private Func<XElement, string> GetParser(string name)
        {
            if (name.ToUpper() == "ADDRESS")
                return xml =>
                {
                    if (xml == null) return string.Empty;

                    string zipCode = xml.Element("ZipCode").String();
                    string county = xml.Element("County").String();
                    string town = xml.Element("Town").String();
                    string district = xml.Element("District").String();
                    string area = xml.Element("Area").String();
                    string detail = xml.Element("DetailAddress").String();

                    return string.Format("{0} {1}{2}{3}{4}{5}", zipCode, county, town, district, area, detail);
                };
            else if (name.ToUpper() == "LIVING")
                return xml =>
                {
                    if (xml == null) return string.Empty;
                    if (string.IsNullOrWhiteSpace(xml.String())) return string.Empty;

                    bool living = bool.Parse(xml.Value);

                    if (living)
                        return "存";
                    else
                        return "歿";
                };

            return x =>
            {
                if (x == null)
                    return string.Empty;
                else
                    return x.Value;
            };
        }

        private class FieldData
        {
            public FieldData(XElement xml)
            {
                Pattern = xml.Attribute("Pattern").Value;
                Chinese = xml.Attribute("Chinese").Value;
                DataParser = xml.Attribute("DataParser").String();
            }

            public string Pattern { get; private set; }

            public string Chinese { get; private set; }

            public string DataParser { get; private set; }
        }
        #endregion
    }
}
