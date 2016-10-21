namespace StudentTransferCoreImpl
{
    partial class GetJHSchoolNames
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
            this.lstCounty = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkElm = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkJH1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkJh2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lstSchool = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lstCounty
            // 
            // 
            // 
            // 
            this.lstCounty.Border.Class = "ListViewBorder";
            this.lstCounty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lstCounty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstCounty.Location = new System.Drawing.Point(12, 40);
            this.lstCounty.Name = "lstCounty";
            this.lstCounty.Size = new System.Drawing.Size(132, 242);
            this.lstCounty.TabIndex = 0;
            this.lstCounty.UseCompatibleStateImageBehavior = false;
            this.lstCounty.View = System.Windows.Forms.View.Details;
            this.lstCounty.SelectedIndexChanged += new System.EventHandler(this.lstCounty_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "縣市";
            this.columnHeader1.Width = 148;
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkAll.BackgroundStyle.Class = "";
            this.chkAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAll.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkAll.Location = new System.Drawing.Point(244, 12);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(67, 23);
            this.chkAll.TabIndex = 1;
            this.chkAll.Text = "全部";
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkElm
            // 
            this.chkElm.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkElm.BackgroundStyle.Class = "";
            this.chkElm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkElm.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkElm.Location = new System.Drawing.Point(317, 12);
            this.chkElm.Name = "chkElm";
            this.chkElm.Size = new System.Drawing.Size(69, 23);
            this.chkElm.TabIndex = 2;
            this.chkElm.Text = "國小";
            this.chkElm.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkJH1
            // 
            this.chkJH1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkJH1.BackgroundStyle.Class = "";
            this.chkJH1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkJH1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkJH1.Location = new System.Drawing.Point(392, 12);
            this.chkJH1.Name = "chkJH1";
            this.chkJH1.Size = new System.Drawing.Size(61, 23);
            this.chkJH1.TabIndex = 3;
            this.chkJH1.Text = "國中";
            this.chkJH1.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkJh2
            // 
            this.chkJh2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkJh2.BackgroundStyle.Class = "";
            this.chkJh2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkJh2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkJh2.Location = new System.Drawing.Point(459, 12);
            this.chkJh2.Name = "chkJh2";
            this.chkJh2.Size = new System.Drawing.Size(142, 23);
            this.chkJh2.TabIndex = 4;
            this.chkJh2.Text = "高中職附屬國中部";
            this.chkJh2.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lstSchool
            // 
            // 
            // 
            // 
            this.lstSchool.Border.Class = "ListViewBorder";
            this.lstSchool.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lstSchool.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3});
            this.lstSchool.FullRowSelect = true;
            this.lstSchool.Location = new System.Drawing.Point(150, 40);
            this.lstSchool.Name = "lstSchool";
            this.lstSchool.Size = new System.Drawing.Size(443, 242);
            this.lstSchool.TabIndex = 5;
            this.lstSchool.UseCompatibleStateImageBehavior = false;
            this.lstSchool.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "縣市";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "學校代碼";
            this.columnHeader2.Width = 118;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "學校名稱";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 320;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(150, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(58, 23);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "學校名稱";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 11);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "縣市別";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(437, 292);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "確定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(518, 292);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GetJHSchoolNames
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(605, 322);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lstSchool);
            this.Controls.Add(this.chkJh2);
            this.Controls.Add(this.chkJH1);
            this.Controls.Add(this.chkElm);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.lstCounty);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "GetJHSchoolNames";
            this.Text = "國中小清單";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GetJHSchoolNames_FormClosed);
            this.Load += new System.EventHandler(this.GetJHSchoolNames_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ListViewEx lstCounty;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAll;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkElm;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkJH1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkJh2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevComponents.DotNetBar.Controls.ListViewEx lstSchool;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}