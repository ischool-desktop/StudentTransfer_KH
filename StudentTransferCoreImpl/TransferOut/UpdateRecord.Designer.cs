namespace StudentTransferCoreImpl.TransferOut
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLastUpdate = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.gpOrigin = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dateBirthDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cmbGender = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.txtAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.txtClass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txtStudentNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.txtIDNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.intSemester = new DevComponents.Editors.IntegerInput();
            this.intSchoolYear = new DevComponents.Editors.IntegerInput();
            this.txtComment = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnGetSchoolList = new System.Windows.Forms.Button();
            this.txtImportSchool = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtUpdateDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cboUpdateDescription = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSeatNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLastUpdate)).BeginInit();
            this.gpOrigin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirthDate)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtUpdateDate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(345, 538);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(260, 538);
            // 
            // dgvLastUpdate
            // 
            this.dgvLastUpdate.AllowUserToAddRows = false;
            this.dgvLastUpdate.AllowUserToDeleteRows = false;
            this.dgvLastUpdate.AllowUserToResizeRows = false;
            this.dgvLastUpdate.BackgroundColor = System.Drawing.Color.White;
            this.dgvLastUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLastUpdate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chDate,
            this.chDesc,
            this.chComment});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLastUpdate.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLastUpdate.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvLastUpdate.HighlightSelectedColumnHeaders = false;
            this.dgvLastUpdate.Location = new System.Drawing.Point(1, 387);
            this.dgvLastUpdate.MultiSelect = false;
            this.dgvLastUpdate.Name = "dgvLastUpdate";
            this.dgvLastUpdate.ReadOnly = true;
            this.dgvLastUpdate.RowHeadersVisible = false;
            this.dgvLastUpdate.RowTemplate.Height = 24;
            this.dgvLastUpdate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLastUpdate.Size = new System.Drawing.Size(416, 140);
            this.dgvLastUpdate.TabIndex = 15;
            // 
            // chDate
            // 
            this.chDate.HeaderText = "異動日期";
            this.chDate.Name = "chDate";
            this.chDate.ReadOnly = true;
            // 
            // chDesc
            // 
            this.chDesc.HeaderText = "異動原因";
            this.chDesc.Name = "chDesc";
            this.chDesc.ReadOnly = true;
            // 
            // chComment
            // 
            this.chComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chComment.HeaderText = "核准文號";
            this.chComment.Name = "chComment";
            this.chComment.ReadOnly = true;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(2, 360);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(87, 21);
            this.labelX7.TabIndex = 7;
            this.labelX7.Text = "學籍核准文號";
            // 
            // gpOrigin
            // 
            this.gpOrigin.BackColor = System.Drawing.Color.Transparent;
            this.gpOrigin.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpOrigin.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpOrigin.Controls.Add(this.dateBirthDate);
            this.gpOrigin.Controls.Add(this.cmbGender);
            this.gpOrigin.Controls.Add(this.labelX17);
            this.gpOrigin.Controls.Add(this.txtAddress);
            this.gpOrigin.Controls.Add(this.labelX10);
            this.gpOrigin.Controls.Add(this.labelX9);
            this.gpOrigin.Controls.Add(this.txtClass);
            this.gpOrigin.Controls.Add(this.labelX8);
            this.gpOrigin.Controls.Add(this.txtSeatNo);
            this.gpOrigin.Controls.Add(this.txtStudentNumber);
            this.gpOrigin.Controls.Add(this.labelX11);
            this.gpOrigin.Controls.Add(this.txtName);
            this.gpOrigin.Controls.Add(this.labelX12);
            this.gpOrigin.Controls.Add(this.labelX13);
            this.gpOrigin.Controls.Add(this.labelX14);
            this.gpOrigin.Controls.Add(this.txtIDNumber);
            this.gpOrigin.Location = new System.Drawing.Point(1, 166);
            this.gpOrigin.Name = "gpOrigin";
            this.gpOrigin.Size = new System.Drawing.Size(416, 185);
            // 
            // 
            // 
            this.gpOrigin.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpOrigin.Style.BackColorGradientAngle = 90;
            this.gpOrigin.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpOrigin.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpOrigin.Style.BorderBottomWidth = 1;
            this.gpOrigin.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpOrigin.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpOrigin.Style.BorderLeftWidth = 1;
            this.gpOrigin.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpOrigin.Style.BorderRightWidth = 1;
            this.gpOrigin.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpOrigin.Style.BorderTopWidth = 1;
            this.gpOrigin.Style.Class = "";
            this.gpOrigin.Style.CornerDiameter = 4;
            this.gpOrigin.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpOrigin.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpOrigin.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gpOrigin.StyleMouseDown.Class = "";
            this.gpOrigin.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpOrigin.StyleMouseOver.Class = "";
            this.gpOrigin.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpOrigin.TabIndex = 16;
            this.gpOrigin.Text = "學生基本資料";
            // 
            // dateBirthDate
            // 
            this.dateBirthDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dateBirthDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateBirthDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateBirthDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateBirthDate.ButtonDropDown.Visible = true;
            this.dateBirthDate.IsPopupCalendarOpen = false;
            this.dateBirthDate.Location = new System.Drawing.Point(288, 66);
            // 
            // 
            // 
            this.dateBirthDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateBirthDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateBirthDate.MonthCalendar.BackgroundStyle.Class = "";
            this.dateBirthDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateBirthDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateBirthDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateBirthDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateBirthDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateBirthDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateBirthDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateBirthDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateBirthDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateBirthDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateBirthDate.MonthCalendar.DayNames = new string[] {
        "日",
        "一",
        "二",
        "三",
        "四",
        "五",
        "六"};
            this.dateBirthDate.MonthCalendar.DisplayMonth = new System.DateTime(2009, 5, 1, 0, 0, 0, 0);
            this.dateBirthDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateBirthDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateBirthDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateBirthDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateBirthDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateBirthDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateBirthDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateBirthDate.MonthCalendar.TodayButtonVisible = true;
            this.dateBirthDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateBirthDate.Name = "dateBirthDate";
            this.dateBirthDate.Size = new System.Drawing.Size(120, 25);
            this.dateBirthDate.TabIndex = 20;
            // 
            // cmbGender
            // 
            this.cmbGender.DisplayMember = "Text";
            this.cmbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.ItemHeight = 19;
            this.cmbGender.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cmbGender.Location = new System.Drawing.Point(87, 65);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 25);
            this.cmbGender.TabIndex = 19;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "男";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "女";
            // 
            // labelX17
            // 
            this.labelX17.AutoSize = true;
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.Class = "";
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX17.ForeColor = System.Drawing.Color.Black;
            this.labelX17.Location = new System.Drawing.Point(7, 132);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(60, 21);
            this.labelX17.TabIndex = 18;
            this.labelX17.Text = "遷出地址";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txtAddress.Border.Class = "TextBoxBorder";
            this.txtAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddress.Location = new System.Drawing.Point(88, 128);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(320, 25);
            this.txtAddress.TabIndex = 17;
            this.txtAddress.TabStop = false;
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX10.ForeColor = System.Drawing.Color.Black;
            this.labelX10.Location = new System.Drawing.Point(8, 7);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(64, 21);
            this.labelX10.TabIndex = 10;
            this.labelX10.Text = "班         級";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX9.ForeColor = System.Drawing.Color.Black;
            this.labelX9.Location = new System.Drawing.Point(222, 37);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(64, 21);
            this.labelX9.TabIndex = 2;
            this.labelX9.Text = "座         號";
            // 
            // txtClass
            // 
            this.txtClass.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txtClass.Border.Class = "TextBoxBorder";
            this.txtClass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClass.Location = new System.Drawing.Point(88, 3);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(120, 25);
            this.txtClass.TabIndex = 1;
            this.txtClass.TabStop = false;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX8.ForeColor = System.Drawing.Color.Black;
            this.labelX8.Location = new System.Drawing.Point(222, 3);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(64, 21);
            this.labelX8.TabIndex = 4;
            this.labelX8.Text = "學         號";
            // 
            // txtStudentNumber
            // 
            this.txtStudentNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txtStudentNumber.Border.Class = "TextBoxBorder";
            this.txtStudentNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStudentNumber.Location = new System.Drawing.Point(288, 3);
            this.txtStudentNumber.Name = "txtStudentNumber";
            this.txtStudentNumber.Size = new System.Drawing.Size(121, 25);
            this.txtStudentNumber.TabIndex = 5;
            this.txtStudentNumber.TabStop = false;
            // 
            // labelX11
            // 
            this.labelX11.AutoSize = true;
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX11.ForeColor = System.Drawing.Color.Black;
            this.labelX11.Location = new System.Drawing.Point(8, 39);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(64, 21);
            this.labelX11.TabIndex = 0;
            this.labelX11.Text = "姓         名";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.Location = new System.Drawing.Point(88, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 25);
            this.txtName.TabIndex = 1;
            this.txtName.TabStop = false;
            // 
            // labelX12
            // 
            this.labelX12.AutoSize = true;
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.Class = "";
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX12.ForeColor = System.Drawing.Color.Black;
            this.labelX12.Location = new System.Drawing.Point(222, 69);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(64, 21);
            this.labelX12.TabIndex = 4;
            this.labelX12.Text = "生         日";
            // 
            // labelX13
            // 
            this.labelX13.AutoSize = true;
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.Class = "";
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX13.ForeColor = System.Drawing.Color.Black;
            this.labelX13.Location = new System.Drawing.Point(8, 70);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(64, 21);
            this.labelX13.TabIndex = 2;
            this.labelX13.Text = "性         別";
            // 
            // labelX14
            // 
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.Class = "";
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX14.ForeColor = System.Drawing.Color.Black;
            this.labelX14.Location = new System.Drawing.Point(7, 99);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(76, 23);
            this.labelX14.TabIndex = 6;
            this.labelX14.Text = "身分證號";
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txtIDNumber.Border.Class = "TextBoxBorder";
            this.txtIDNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIDNumber.Location = new System.Drawing.Point(88, 97);
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(319, 25);
            this.txtIDNumber.TabIndex = 7;
            this.txtIDNumber.TabStop = false;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.intSemester);
            this.groupPanel1.Controls.Add(this.intSchoolYear);
            this.groupPanel1.Controls.Add(this.txtComment);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.btnGetSchoolList);
            this.groupPanel1.Controls.Add(this.txtImportSchool);
            this.groupPanel1.Controls.Add(this.dtUpdateDate);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.cboUpdateDescription);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Location = new System.Drawing.Point(2, 7);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(416, 149);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 17;
            this.groupPanel1.Text = "異動內容";
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
            this.labelX6.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(221, 3);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(60, 21);
            this.labelX6.TabIndex = 27;
            this.labelX6.Text = "學　　期";
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
            this.intSemester.Location = new System.Drawing.Point(287, 1);
            this.intSemester.MaxValue = 2;
            this.intSemester.MinValue = 1;
            this.intSemester.Name = "intSemester";
            this.intSemester.Size = new System.Drawing.Size(121, 25);
            this.intSemester.TabIndex = 26;
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
            this.intSchoolYear.Location = new System.Drawing.Point(87, 1);
            this.intSchoolYear.MaxValue = 9999;
            this.intSchoolYear.MinValue = 1;
            this.intSchoolYear.Name = "intSchoolYear";
            this.intSchoolYear.Size = new System.Drawing.Size(120, 25);
            this.intSchoolYear.TabIndex = 25;
            this.intSchoolYear.Value = 1;
            // 
            // txtComment
            // 
            // 
            // 
            // 
            this.txtComment.Border.Class = "TextBoxBorder";
            this.txtComment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtComment.Location = new System.Drawing.Point(87, 93);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(321, 25);
            this.txtComment.TabIndex = 24;
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
            this.labelX3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(221, 33);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 21);
            this.labelX3.TabIndex = 18;
            this.labelX3.Text = "異動原因";
            // 
            // btnGetSchoolList
            // 
            this.btnGetSchoolList.BackColor = System.Drawing.Color.Transparent;
            this.btnGetSchoolList.Location = new System.Drawing.Point(382, 63);
            this.btnGetSchoolList.Name = "btnGetSchoolList";
            this.btnGetSchoolList.Size = new System.Drawing.Size(26, 23);
            this.btnGetSchoolList.TabIndex = 22;
            this.btnGetSchoolList.Text = "...";
            this.btnGetSchoolList.UseVisualStyleBackColor = false;
            this.btnGetSchoolList.Click += new System.EventHandler(this.btnGetSchoolList_Click);
            // 
            // txtImportSchool
            // 
            // 
            // 
            // 
            this.txtImportSchool.Border.Class = "TextBoxBorder";
            this.txtImportSchool.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtImportSchool.Location = new System.Drawing.Point(87, 62);
            this.txtImportSchool.Name = "txtImportSchool";
            this.txtImportSchool.Size = new System.Drawing.Size(292, 25);
            this.txtImportSchool.TabIndex = 21;
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
            this.dtUpdateDate.Location = new System.Drawing.Point(87, 31);
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
            this.dtUpdateDate.TabIndex = 17;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(6, 94);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 23;
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
            this.labelX5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(6, 3);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(60, 21);
            this.labelX5.TabIndex = 15;
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
            this.labelX1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(6, 32);
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
            this.cboUpdateDescription.Location = new System.Drawing.Point(287, 31);
            this.cboUpdateDescription.Name = "cboUpdateDescription";
            this.cboUpdateDescription.Size = new System.Drawing.Size(121, 25);
            this.cboUpdateDescription.TabIndex = 19;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(6, 63);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 20;
            this.labelX2.Text = "轉出後學校";
            // 
            // txtSeatNo
            // 
            this.txtSeatNo.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txtSeatNo.Border.Class = "TextBoxBorder";
            this.txtSeatNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSeatNo.Location = new System.Drawing.Point(288, 34);
            this.txtSeatNo.Name = "txtSeatNo";
            this.txtSeatNo.Size = new System.Drawing.Size(121, 25);
            this.txtSeatNo.TabIndex = 3;
            this.txtSeatNo.TabStop = false;
            // 
            // UpdateRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 575);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.gpOrigin);
            this.Controls.Add(this.dgvLastUpdate);
            this.Controls.Add(this.labelX7);
            this.Name = "UpdateRecord";
            this.Text = "線上轉學精靈 (轉出) - 建立異動記錄";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateRecord_FormClosed);
            this.Load += new System.EventHandler(this.UpdateRecord_Load);
            this.Controls.SetChildIndex(this.labelX7, 0);
            this.Controls.SetChildIndex(this.dgvLastUpdate, 0);
            this.Controls.SetChildIndex(this.gpOrigin, 0);
            this.Controls.SetChildIndex(this.groupPanel1, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLastUpdate)).EndInit();
            this.gpOrigin.ResumeLayout(false);
            this.gpOrigin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirthDate)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtUpdateDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvLastUpdate;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn chComment;
        private DevComponents.DotNetBar.Controls.GroupPanel gpOrigin;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtStudentNumber;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClass;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIDNumber;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAddress;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbGender;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateBirthDate;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.IntegerInput intSemester;
        private DevComponents.Editors.IntegerInput intSchoolYear;
        private DevComponents.DotNetBar.Controls.TextBoxX txtComment;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Button btnGetSchoolList;
        private DevComponents.DotNetBar.Controls.TextBoxX txtImportSchool;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtUpdateDate;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboUpdateDescription;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSeatNo;
    }
}