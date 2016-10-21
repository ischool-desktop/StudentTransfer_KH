using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using Aspose.Cells;
using FISCA;
using K12.Data;
using StudentTransferAPI;

namespace StudentTransferCoreImpl.TransferIn
{
    public partial class ImportDataForm : WizardForm
    {
        private TransferInRecord Record { get; set; }

        private StatusForm.TransferInItem Item { get; set; }

        private List<TransferProcessor> Processors { get; set; }

        private XElement XmlData { get; set; }

        public ImportDataForm(ArgDictionary args)
            : base(args)
        {
            InitializeComponent();
        }

        private void ImportDataForm_Load(object sender, EventArgs e)
        {
            Record = Arguments[Consts.TransferInRecord] as TransferInRecord;
            Item = Arguments[Consts.TransferInGridItem] as StatusForm.TransferInItem;
            Processors = Arguments[Consts.SelectedProcessor] as List<TransferProcessor>;
            XmlData = Arguments[Consts.XmlData] as XElement;

            cp1.IsRunning = true;
            NextButtonEnabled = false;

            Task task = Task.Factory.StartNew(() =>
            {
                Import();
            }, new System.Threading.CancellationToken(),
                TaskCreationOptions.None,
                TaskScheduler.Default);

            task.ContinueWith((x) =>
            {
                if (x.IsFaulted)
                {
                    lblGenerateXmlDesc.Text = x.Exception.Message;
                    RTOut.WriteError(x.Exception);
                    MessageBox.Show(x.Exception.Message);
                    return;
                }

                Item.Status = 4;
                Item.RefreshStatusString();

                //將學生改為一般狀態。
                StudentRecord sr = Student.SelectByID(Arguments[Consts.StudentID] + "");
                sr.Status = StudentRecord.StudentStatus.一般;
                Student.Update(sr);

                lblGenerateXmlDesc.Text = "匯入完成。";
                cp1.IsRunning = false;
                cp1.Value = 100;

                NextButtonEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        protected override ContinueDirection? OnNextButtonClick()
        {
            return base.OnNextButtonClick();
        }

        private void Import()
        {
            foreach (TransferProcessor tp in Processors)
            {
                XElement data = XmlData.XPathSelectElement("*[@Processor='" + tp.Identify + "']");

                if (data != null)
                    tp.TransferIn(data);
            }

            Record.Status = 4;
            Record.Save();
        }

        private void lblSummary_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Excel 檔案(*.xls)|*.xls";
                dialog.FileName = "資料轉移總表.xls";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Workbook book = new ExportToExcel(XmlData).Export();
                    book.Save(dialog.FileName);
                }

                Process.Start(dialog.FileName);
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
