using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentTransferCoreImpl
{
    public partial class MsgForm : FISCA.Presentation.Controls.BaseForm
    {
        public MsgForm()
        {
            InitializeComponent();
        }

        private void lbUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "http://163.32.129.93/%E9%AB%98%E9%9B%84%E5%B8%82%E5%85%AC%E7%A7%81%E7%AB%8B%E5%9C%8B%E6%B0%91%E4%B8%AD%E5%AD%B8%E8%BD%89%E5%85%A5%E7%94%9F%E8%87%AA%E5%8B%95%E7%B7%A8%E7%8F%AD%E8%88%87%E8%AA%BF%E7%8F%AD%E7%B3%BB%E7%B5%B1%E7%B4%80%E9%8C%84%E5%AF%A9%E6%9F%A5%E4%BD%9C%E6%A5%AD.pdf";
            ProcessStartInfo info = new ProcessStartInfo(url);
            Process.Start(info);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        public void SetMsg(string msg)
        {
            this.lblMsg.Text = msg;
        }
    }
}
