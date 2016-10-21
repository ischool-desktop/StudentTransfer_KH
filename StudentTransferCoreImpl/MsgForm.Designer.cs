namespace StudentTransferCoreImpl
{
    partial class MsgForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnYes = new DevComponents.DotNetBar.ButtonX();
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.lblMsg = new DevComponents.DotNetBar.LabelX();
            this.lbUrl = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.AutoSize = true;
            this.btnYes.BackColor = System.Drawing.Color.Transparent;
            this.btnYes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnYes.Location = new System.Drawing.Point(301, 152);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 25);
            this.btnYes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "是";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.AutoSize = true;
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.Location = new System.Drawing.Point(386, 152);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 25);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "否";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblMsg.BackgroundStyle.Class = "";
            this.lblMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMsg.Location = new System.Drawing.Point(17, 18);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(444, 121);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.lblMsg.WordWrap = true;
            // 
            // lbUrl
            // 
            this.lbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbUrl.AutoSize = true;
            this.lbUrl.BackColor = System.Drawing.Color.Transparent;
            this.lbUrl.Location = new System.Drawing.Point(14, 156);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(242, 17);
            this.lbUrl.TabIndex = 3;
            this.lbUrl.TabStop = true;
            this.lbUrl.Text = "轉入生自動編班與調班系統紀錄審查作業";
            this.lbUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbUrl_LinkClicked);
            // 
            // MsgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 190);
            this.Controls.Add(this.lbUrl);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.DoubleBuffered = true;
            this.Name = "MsgForm";
            this.Text = "MsgForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnYes;
        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.LabelX lblMsg;
        private System.Windows.Forms.LinkLabel lbUrl;
    }
}