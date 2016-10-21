using System;
using System.Windows.Forms;
using FISCA;
using StudentTransferAPI;
using System.Collections.Generic;

namespace StudentTransferCoreImpl.TransferOut
{
    public partial class ExportDataOptions : WizardForm
    {
        public ExportDataOptions(ArgDictionary args)
            : base(args)
        {
            InitializeComponent();
        }

        private void ExportDataOptions_Load(object sender, EventArgs e)
        {
            foreach (TransferProcessor tp in TransferProcessor.Processors)
            {
                if (!tp.Optional) continue;

                DataGridViewRow row = new DataGridViewRow();
                row.Tag = tp;
                row.CreateCells(dgProcessor, true, tp.Title);
                dgProcessor.Rows.Add(row);
            }
        }

        protected override ContinueDirection? OnNextButtonClick()
        {
            List<TransferProcessor> processors = new List<TransferProcessor>();

            foreach (TransferProcessor each in TransferProcessor.Processors)
            {
                if (!each.Optional)
                    processors.Add(each);
            }

            foreach (DataGridViewRow row in dgProcessor.Rows)
            {
                if (row.IsNewRow) continue;
                if (!bool.Parse(row.Cells[0].Value + "")) continue;

                processors.Add(row.Tag as TransferProcessor);
            }
            Arguments[Consts.SelectedProcessor] = processors;

            return ContinueDirection.Next;
        }
    }
}
