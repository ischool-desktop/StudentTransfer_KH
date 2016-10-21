namespace StudentTransferCoreImpl.TransferIn
{
    partial class UpdateRecord
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
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.intSemester = new DevComponents.Editors.IntegerInput();
            this.intSchoolYear = new DevComponents.Editors.IntegerInput();
            this.txtComment = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnGetSchoolList = new System.Windows.Forms.Button();
            this.txtExportSchool = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtUpdateDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cboUpdateDescription = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtUpdateDate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(342, 142);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(257, 142);
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(227, 12);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(34, 21);
            this.labelX6.TabIndex = 29;
            this.labelX6.Text = "學期";
            // 
            // intSemester
            // 
            this.intSemester.AutoOverwrite = true;
            this.intSemester.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.intSemester.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intSemester.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intSemester.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intSemester.Location = new System.Drawing.Point(293, 10);
            this.intSemester.MaxValue = 2;
            this.intSemester.MinValue = 1;
            this.intSemester.Name = "intSemester";
            this.intSemester.Size = new System.Drawing.Size(121, 25);
            this.intSemester.TabIndex = 28;
            this.intSemester.Value = 1;
            // 
            // intSchoolYear
            // 
            this.intSchoolYear.AutoOverwrite = true;
            this.intSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.intSchoolYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intSchoolYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intSchoolYear.Location = new System.Drawing.Point(93, 10);
            this.intSchoolYear.MaxValue = 9999;
            this.intSchoolYear.MinValue = 1;
            this.intSchoolYear.Name = "intSchoolYear";
            this.intSchoolYear.Size = new System.Drawing.Size(120, 25);
            this.intSchoolYear.TabIndex = 27;
            this.intSchoolYear.Value = 1;
            // 
            // txtComment
            // 
            // 
            // 
            // 
            this.txtComment.Border.Class = "TextBoxBorder";
            this.txtComment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtComment.Location = new System.Drawing.Point(93, 102);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(321, 25);
            this.txtComment.TabIndex = 26;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(227, 42);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 21);
            this.labelX3.TabIndex = 19;
            this.labelX3.Text = "異動原因";
            // 
            // btnGetSchoolList
            // 
            this.btnGetSchoolList.BackColor = System.Drawing.Color.Transparent;
            this.btnGetSchoolList.Location = new System.Drawing.Point(388, 72);
            this.btnGetSchoolList.Name = "btnGetSchoolList";
            this.btnGetSchoolList.Size = new System.Drawing.Size(26, 23);
            this.btnGetSchoolList.TabIndex = 23;
            this.btnGetSchoolList.Text = "...";
            this.btnGetSchoolList.UseVisualStyleBackColor = false;
            this.btnGetSchoolList.Click += new System.EventHandler(this.btnGetSchoolList_Click_1);
            // 
            // txtExportSchool
            // 
            // 
            // 
            // 
            this.txtExportSchool.Border.Class = "TextBoxBorder";
            this.txtExportSchool.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtExportSchool.Location = new System.Drawing.Point(93, 71);
            this.txtExportSchool.Name = "txtExportSchool";
            this.txtExportSchool.Size = new System.Drawing.Size(292, 25);
            this.txtExportSchool.TabIndex = 22;
            // 
            // dtUpdateDate
            // 
            this.dtUpdateDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dtUpdateDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtUpdateDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtUpdateDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtUpdateDate.ButtonDropDown.Visible = true;
            this.dtUpdateDate.IsPopupCalendarOpen = false;
            this.dtUpdateDate.Location = new System.Drawing.Point(93, 40);
            // 
            // 
            // 
            this.dtUpdateDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtUpdateDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtUpdateDate.MonthCalendar.BackgroundStyle.Class = "";
            this.dtUpdateDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtUpdateDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtUpdateDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtUpdateDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtUpdateDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtUpdateDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtUpdateDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtUpdateDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtUpdateDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtUpdateDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtUpdateDate.MonthCalendar.DayNames = new string[] {
        "日",
        "一",
        "二",
        "三",
        "四",
        "五",
        "六"};
            this.dtUpdateDate.MonthCalendar.DisplayMonth = new System.DateTime(2009, 5, 1, 0, 0, 0, 0);
            this.dtUpdateDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtUpdateDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtUpdateDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtUpdateDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtUpdateDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtUpdateDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtUpdateDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtUpdateDate.MonthCalendar.TodayButtonVisible = true;
            this.dtUpdateDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtUpdateDate.Name = "dtUpdateDate";
            this.dtUpdateDate.Size = new System.Drawing.Size(120, 25);
            this.dtUpdateDate.TabIndex = 18;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(12, 103);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 24;
            this.labelX4.Text = "備         註";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(12, 12);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(60, 21);
            this.labelX5.TabIndex = 17;
            this.labelX5.Text = "學  年  度";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(12, 41);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 16;
            this.labelX1.Text = "異動日期";
            // 
            // cboUpdateDescription
            // 
            this.cboUpdateDescription.DisplayMember = "Text";
            this.cboUpdateDescription.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboUpdateDescription.FormattingEnabled = true;
            this.cboUpdateDescription.ItemHeight = 19;
            this.cboUpdateDescription.Location = new System.Drawing.Point(293, 40);
            this.cboUpdateDescription.Name = "cboUpdateDescription";
            this.cboUpdateDescription.Size = new System.Drawing.Size(121, 25);
            this.cboUpdateDescription.TabIndex = 20;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(12, 72);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 21;
            this.labelX2.Text = "轉入前學校";
            // 
            // UpdateRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 179);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.intSemester);
            this.Controls.Add(this.intSchoolYear);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.btnGetSchoolList);
            this.Controls.Add(this.txtExportSchool);
            this.Controls.Add(this.dtUpdateDate);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.cboUpdateDescription);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX5);
            this.Name = "UpdateRecord";
            this.Text = "線上轉學精靈 (轉入) - 建立異動記錄";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateRecord_FormClosed);
            this.Load += new System.EventHandler(this.UpdateRecord_Load);
            this.Controls.SetChildIndex(this.labelX5, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.cboUpdateDescription, 0);
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.dtUpdateDate, 0);
            this.Controls.SetChildIndex(this.txtExportSchool, 0);
            this.Controls.SetChildIndex(this.btnGetSchoolList, 0);
            this.Controls.SetChildIndex(this.labelX3, 0);
            this.Controls.SetChildIndex(this.txtComment, 0);
            this.Controls.SetChildIndex(this.intSchoolYear, 0);
            this.Controls.SetChildIndex(this.intSemester, 0);
            this.Controls.SetChildIndex(this.labelX6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.intSemester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtUpdateDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.IntegerInput intSemester;
        private DevComponents.Editors.IntegerInput intSchoolYear;
        private DevComponents.DotNetBar.Controls.TextBoxX txtComment;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Button btnGetSchoolList;
        private DevComponents.DotNetBar.Controls.TextBoxX txtExportSchool;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtUpdateDate;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboUpdateDescription;
        private DevComponents.DotNetBar.LabelX labelX2;

    }
}