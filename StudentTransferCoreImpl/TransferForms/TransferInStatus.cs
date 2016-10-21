using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.Authentication;
using FISCA;
using DevComponents.DotNetBar;

namespace StudentTransferCoreImpl
{
    internal partial class TransferInStatus : BaseForm
    {
        private StatusForm.TransferInItem Item { get; set; }

        private StatusUIController StatusUI { get; set; }

        public TransferInStatus(StatusForm.TransferInItem item)
        {
            InitializeComponent();
            Item = item;

            StatusUI = new StatusUIController(new PanelEx[] { state1, state2, state3, state4 });
        }

        private void TransferInStatus_Load(object sender, EventArgs e)
        {
            txtName.Text = string.Format("{0} {1}", Item.ClassName, Item.Name);
            txtTransferCode.Text = string.Format("{0}@{1}", Item.TransferToken, Item.TransferSourceUrl);
            txtTransferSource.Text = Item.TransferSource;

            if (Item.Status <= 1)
                btnTransfer.Enabled = false;

            if (Item.Status == 2)
                btnTransfer.Enabled = true;

            if (Item.Status >= 4)
                btnTransfer.Enabled = false;

            Item.PropertyChanged += new PropertyChangedEventHandler(Item_PropertyChanged);

            RefreshGridData();
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "TransferSource")
                txtTransferSource.Text = Item.TransferSource;
            else if (e.PropertyName == "StatusString")
            {
                StatusUI.Status = Item.Status;
                btnTransfer.Enabled = (Item.Status == 2 || Item.Status == 3);
            }
        }

        private void ButtonToConfirmedStatus()
        {
            btnTransfer.Enabled = false;
            btnTransfer.Text = "已確認";
        }

        private void RefreshGridData()
        {
            foreach (string status in new string[] { "待確認", "已確認", "已轉移", "已轉入" })
            {
                if (status == Item.StatusString)
                    StatusUI.Status = Item.Status;
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            ArgDictionary args = new ArgDictionary();

            args.Add(Consts.TransferInRecordUID, Item.UID);
            args.Add(Consts.TransferInGridItem, Item);

            Features.Invoke(Program.Private_TransferIn, args);
        }
    }
}
