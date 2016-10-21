namespace StudentTransferCoreImpl.TransferIn
{
    partial class ImportDataForm
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
            this.lblGenerateXmlDesc = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cp1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(291, 165);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(206, 165);
            // 
            // lblGenerateXmlDesc
            // 
            this.lblGenerateXmlDesc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGenerateXmlDesc.AutoSize = true;
            this.lblGenerateXmlDesc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblGenerateXmlDesc.BackgroundStyle.Class = "";
            this.lblGenerateXmlDesc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGenerateXmlDesc.Location = new System.Drawing.Point(147, 16);
            this.lblGenerateXmlDesc.Name = "lblGenerateXmlDesc";
            this.lblGenerateXmlDesc.Size = new System.Drawing.Size(83, 21);
            this.lblGenerateXmlDesc.TabIndex = 6;
            this.lblGenerateXmlDesc.Text = "匯入資料中...";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 170);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(104, 20);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "<a Name=\"PrintName\">列印轉入資料總表</a>";
            this.labelX2.WordWrap = true;
            this.labelX2.Click += new System.EventHandler(this.lblSummary_Click);
            // 
            // cp1
            // 
            this.cp1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cp1.BackgroundStyle.Class = "";
            this.cp1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cp1.Location = new System.Drawing.Point(120, 39);
            this.cp1.Name = "cp1";
            this.cp1.Size = new System.Drawing.Size(108, 94);
            this.cp1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.cp1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblGenerateXmlDesc, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 54);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // ImportDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 202);
            this.Controls.Add(this.cp1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.labelX2);
            this.Name = "ImportDataForm";
            this.Text = "線上轉學精靈 (轉入) - 資料匯入";
            this.Load += new System.EventHandler(this.ImportDataForm_Load);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cp1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblGenerateXmlDesc;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.CircularProgress cp1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}