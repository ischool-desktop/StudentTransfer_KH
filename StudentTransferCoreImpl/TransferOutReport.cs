using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;
using System.Diagnostics;
using Aspose.Words;
using System.IO;
using System.Windows.Forms;
using FISCA;
using FISCA.Authentication;

namespace StudentTransferCoreImpl
{
    class TransferOutReport
    {
        public void Generate(TransferOutRecord record)
        {
            try
            {
                string fullToken = string.Format("{0}@{1}", record.TransferToken, DSAServices.AccessPoint);
                Document doc = new Document(new MemoryStream(Properties.Resources.綜合資料轉移單));

                Dictionary<string, string> mergeData = GetMergeData(record.RefStudentID, fullToken);
                doc.MailMerge.Execute(mergeData.Keys.ToArray(), mergeData.Values.ToArray());

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "*.doc 文件|*.doc";
                dialog.FileName = "綜合資料轉移單.doc";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    doc.Save(dialog.FileName, SaveFormat.Doc);
                    Process.Start(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorReport.Generate(ex));
            }
        }

        private Dictionary<string, string> GetMergeData(string studentId, string fullToken)
        {
            Dictionary<string, string> md = new Dictionary<string, string>();

            StudentRecord student = Student.SelectByID(studentId);

            md.Add("TransferToken", fullToken);
            md.Add("學校名稱", School.ChineseName);
            md.Add("姓名", student.Name);
            md.Add("民國生日", student.Birthday.HasValue ? ToChineseDate(student.Birthday.Value) : "");
            md.Add("班級年級", student.Class == null ? "" : student.Class.GradeYear + "");
            md.Add("校長姓名", student.Name);
            md.Add("今天民國日期", ToChineseDate(DateTime.Now));

            return md;
        }

        // 取得系統今年中文年
        private string ToChineseDate(DateTime dt)
        {
            return (dt.Year - 1911) + "年" + dt.Month + "月" + dt.Day + "日";
        }
    }
}
