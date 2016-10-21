using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using FISCA;
using StudentTransferAPI;
using System.Xml.XPath;

namespace StudentTransferCoreImpl.TransferIn
{
    public partial class ImportDataOptions : WizardForm
    {
        private XElement XmlData { get; set; }

        public ImportDataOptions(ArgDictionary args)
            : base(args)
        {
            InitializeComponent();

            NextButtonTitle = "開始匯入";
            chAdjust.Click += new EventHandler<EventArgs>(chAdjust_Click);
        }

        private void chAdjust_Click(object sender, EventArgs e)
        {
            if (dgProcessor.SelectedRows.Count <= 0) return;

            TransferProcessor tp = dgProcessor.SelectedRows[0].Tag as TransferProcessor;

            if (!tp.TransferInAdjustSupport)
                MessageBox.Show("不支援檢視資料。");
            else
            {
                XElement data = XmlData.XPathSelectElement("*[@Processor='" + tp.Identify + "']");

                if (data != null)
                    data.ReplaceWith(tp.TransferInAdjust(data));
                else
                    MessageBox.Show(string.Format("找不到資料檢視器({0})。", tp.Identify));
            }
        }

        private void ImportDataOptions_Load(object sender, EventArgs e)
        {
            XmlData = Arguments[Consts.XmlData] as XElement;

            List<TransferProcessor> processors = new List<TransferProcessor>();
            foreach (XElement each in XmlData.Elements())
            {
                //不包含 Processor 表示不需要處理。
                if (each.Attribute("Processor") != null)
                {
                    TransferProcessor tp = FindProcessor(each.Attribute("Processor").Value);

                    if (tp != null)
                    {
                        //不可選擇的話，也不需要顯示讓使用者選。
                        if (!tp.Optional) continue;

                        processors.Add(tp);
                        DataGridViewRow row = new DataGridViewRow();
                        row.Tag = tp;
                        row.CreateCells(dgProcessor, true, tp.Title, "檢視");
                        dgProcessor.Rows.Add(row);
                    }
                }
            }
        }

        private TransferProcessor FindProcessor(string name)
        {
            foreach (TransferProcessor each in TransferProcessor.Processors)
            {
                if (each.Identify == name)
                    return each;
            }
            return null;
        }

        protected override ContinueDirection? OnNextButtonClick()
        {
            try
            {
                List<TransferProcessor> processors = new List<TransferProcessor>();

                foreach (TransferProcessor each in TransferProcessor.Processors)
                {
                    if (!each.Optional)
                        processors.Add(each);
                }

                foreach (DataGridViewRow each in dgProcessor.Rows)
                {
                    if (each.IsNewRow) continue;

                    TransferProcessor tp = each.Tag as TransferProcessor;
                    processors.Add(tp);
                }
                Arguments[Consts.SelectedProcessor] = processors;

                return ContinueDirection.Next;
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);

                return ContinueDirection.Cancel;
            }
        }
    }
}
