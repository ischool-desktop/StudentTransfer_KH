namespace StudentTransferCoreImpl
{
    partial class StatusForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.contextMenuBar2 = new DevComponents.DotNetBar.ContextMenuBar();
            this.InMenu = new DevComponents.DotNetBar.ButtonItem();
            this.btnExportInXml = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.btnInDel = new DevComponents.DotNetBar.ButtonItem();
            this.dgvTransferIn = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chClass_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTrace1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAllIn = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.chkAllOut = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.contextMenuBar1 = new DevComponents.DotNetBar.ContextMenuBar();
            this.OutMenu = new DevComponents.DotNetBar.ButtonItem();
            this.btnOutExportXml = new DevComponents.DotNetBar.ButtonItem();
            this.btnTransferReport = new DevComponents.DotNetBar.ButtonItem();
            this.btnArchive = new DevComponents.DotNetBar.ButtonItem();
            this.btnUnArchive = new DevComponents.DotNetBar.ButtonItem();
            this.btnStatus_1 = new DevComponents.DotNetBar.ButtonItem();
            this.dgvTransferOut = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTransferTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTrace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferIn)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferOut)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = false;
            this.tabControl1.CloseButtonOnTabsAlwaysDisplayed = false;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 462);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.tabControlPanel1.Controls.Add(this.contextMenuBar2);
            this.tabControlPanel1.Controls.Add(this.chkAllIn);
            this.tabControlPanel1.Controls.Add(this.dgvTransferIn);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(640, 434);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // contextMenuBar2
            // 
            this.contextMenuBar2.AntiAlias = true;
            this.contextMenuBar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.contextMenuBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.InMenu});
            this.contextMenuBar2.Location = new System.Drawing.Point(12, 4);
            this.contextMenuBar2.Name = "contextMenuBar2";
            this.contextMenuBar2.Size = new System.Drawing.Size(75, 27);
            this.contextMenuBar2.Stretch = true;
            this.contextMenuBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.contextMenuBar2.TabIndex = 4;
            this.contextMenuBar2.TabStop = false;
            this.contextMenuBar2.Text = "contextMenuBar2";
            // 
            // InMenu
            // 
            this.InMenu.AutoExpandOnClick = true;
            this.InMenu.Name = "InMenu";
            this.InMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnExportInXml,
            this.buttonItem3,
            this.btnInDel});
            this.InMenu.Text = "轉入右鍵";
            this.InMenu.PopupOpen += new DevComponents.DotNetBar.DotNetBarManager.PopupOpenEventHandler(this.InMenu_PopupOpen);
            // 
            // btnExportInXml
            // 
            this.btnExportInXml.Name = "btnExportInXml";
            this.btnExportInXml.Text = "匯出 Xml";
            this.btnExportInXml.Click += new System.EventHandler(this.btnExportInXml_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "資料轉移總表";
            this.buttonItem3.Click += new System.EventHandler(this.btnTransferInReport_Click);
            // 
            // btnInDel
            // 
            this.btnInDel.Name = "btnInDel";
            this.btnInDel.Text = "刪除資料";
            this.btnInDel.Click += new System.EventHandler(this.btnInDel_Click);
            // 
            // dgvTransferIn
            // 
            this.dgvTransferIn.AllowUserToAddRows = false;
            this.dgvTransferIn.AllowUserToDeleteRows = false;
            this.dgvTransferIn.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chClass_in,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.chTrace1});
            this.contextMenuBar2.SetContextMenuEx(this.dgvTransferIn, this.InMenu);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransferIn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransferIn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTransferIn.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvTransferIn.HighlightSelectedColumnHeaders = false;
            this.dgvTransferIn.Location = new System.Drawing.Point(1, 31);
            this.dgvTransferIn.MultiSelect = false;
            this.dgvTransferIn.Name = "dgvTransferIn";
            this.dgvTransferIn.ReadOnly = true;
            this.dgvTransferIn.RowTemplate.Height = 24;
            this.dgvTransferIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferIn.Size = new System.Drawing.Size(638, 402);
            this.dgvTransferIn.TabIndex = 2;
            this.dgvTransferIn.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTransferIn_CellMouseDoubleClick);
            // 
            // chClass_in
            // 
            this.chClass_in.DataPropertyName = "ClassName";
            this.chClass_in.HeaderText = "班級";
            this.chClass_in.Name = "chClass_in";
            this.chClass_in.ReadOnly = true;
            this.chClass_in.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TransferSource";
            this.dataGridViewTextBoxColumn3.HeaderText = "轉出校";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 180;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "StatusString";
            this.dataGridViewTextBoxColumn4.HeaderText = "處理進度";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // chTrace1
            // 
            this.chTrace1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chTrace1.DataPropertyName = "Trace";
            this.chTrace1.HeaderText = "最後更新時間";
            this.chTrace1.Name = "chTrace1";
            this.chTrace1.ReadOnly = true;
            // 
            // chkAllIn
            // 
            this.chkAllIn.AutoSize = true;
            this.chkAllIn.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkAllIn.BackgroundStyle.Class = "";
            this.chkAllIn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAllIn.Location = new System.Drawing.Point(529, 4);
            this.chkAllIn.Name = "chkAllIn";
            this.chkAllIn.Size = new System.Drawing.Size(107, 21);
            this.chkAllIn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAllIn.TabIndex = 3;
            this.chkAllIn.Text = "顯示所有歷程";
            this.chkAllIn.CheckedChanged += new System.EventHandler(this.chkAllIn_CheckedChanged);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "轉入學生清單";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.chkAllOut);
            this.tabControlPanel2.Controls.Add(this.contextMenuBar1);
            this.tabControlPanel2.Controls.Add(this.dgvTransferOut);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(640, 434);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // chkAllOut
            // 
            this.chkAllOut.AutoSize = true;
            this.chkAllOut.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkAllOut.BackgroundStyle.Class = "";
            this.chkAllOut.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAllOut.Location = new System.Drawing.Point(529, 6);
            this.chkAllOut.Name = "chkAllOut";
            this.chkAllOut.Size = new System.Drawing.Size(107, 21);
            this.chkAllOut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAllOut.TabIndex = 4;
            this.chkAllOut.Text = "顯示所有歷程";
            this.chkAllOut.CheckedChanged += new System.EventHandler(this.chkAllOut_CheckedChanged);
            // 
            // contextMenuBar1
            // 
            this.contextMenuBar1.AntiAlias = true;
            this.contextMenuBar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.contextMenuBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.OutMenu});
            this.contextMenuBar1.Location = new System.Drawing.Point(4, 4);
            this.contextMenuBar1.Name = "contextMenuBar1";
            this.contextMenuBar1.Size = new System.Drawing.Size(75, 27);
            this.contextMenuBar1.Stretch = true;
            this.contextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.contextMenuBar1.TabIndex = 2;
            this.contextMenuBar1.TabStop = false;
            this.contextMenuBar1.Text = "contextMenuBar1";
            // 
            // OutMenu
            // 
            this.OutMenu.AutoExpandOnClick = true;
            this.OutMenu.Name = "OutMenu";
            this.OutMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOutExportXml,
            this.btnTransferReport,
            this.btnArchive,
            this.btnUnArchive,
            this.btnStatus_1});
            this.OutMenu.Text = "轉出右鍵";
            this.OutMenu.PopupOpen += new DevComponents.DotNetBar.DotNetBarManager.PopupOpenEventHandler(this.OutMenu_PopupOpen);
            this.OutMenu.Click += new System.EventHandler(this.OutMenu_Click);
            // 
            // btnOutExportXml
            // 
            this.btnOutExportXml.Name = "btnOutExportXml";
            this.btnOutExportXml.Text = "匯出 Xml";
            this.btnOutExportXml.Click += new System.EventHandler(this.btnOutExportXml_Click);
            // 
            // btnTransferReport
            // 
            this.btnTransferReport.Name = "btnTransferReport";
            this.btnTransferReport.Text = "綜合資料轉移單";
            this.btnTransferReport.Click += new System.EventHandler(this.btnTransferReport_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Text = "封存";
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnUnArchive
            // 
            this.btnUnArchive.Name = "btnUnArchive";
            this.btnUnArchive.Text = "解除封存";
            this.btnUnArchive.Click += new System.EventHandler(this.btnUnArchive_Click);
            // 
            // btnStatus_1
            // 
            this.btnStatus_1.Name = "btnStatus_1";
            this.btnStatus_1.Text = "恢復成待轉出";
            this.btnStatus_1.Click += new System.EventHandler(this.btnStatus_1_Click);
            // 
            // dgvTransferOut
            // 
            this.dgvTransferOut.AllowUserToAddRows = false;
            this.dgvTransferOut.AllowUserToDeleteRows = false;
            this.dgvTransferOut.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chClass,
            this.chName,
            this.chTransferTarget,
            this.chStatus,
            this.chTrace});
            this.contextMenuBar1.SetContextMenuEx(this.dgvTransferOut, this.OutMenu);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransferOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransferOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTransferOut.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvTransferOut.HighlightSelectedColumnHeaders = false;
            this.dgvTransferOut.Location = new System.Drawing.Point(1, 33);
            this.dgvTransferOut.Name = "dgvTransferOut";
            this.dgvTransferOut.ReadOnly = true;
            this.dgvTransferOut.RowTemplate.Height = 24;
            this.dgvTransferOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferOut.Size = new System.Drawing.Size(638, 400);
            this.dgvTransferOut.TabIndex = 1;
            this.dgvTransferOut.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTransferOut_CellFormatting);
            this.dgvTransferOut.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTransferOut_CellMouseDoubleClick);
            // 
            // chClass
            // 
            this.chClass.DataPropertyName = "ClassName";
            this.chClass.HeaderText = "班級";
            this.chClass.Name = "chClass";
            this.chClass.ReadOnly = true;
            this.chClass.Width = 80;
            // 
            // chName
            // 
            this.chName.DataPropertyName = "Name";
            this.chName.HeaderText = "姓名";
            this.chName.Name = "chName";
            this.chName.ReadOnly = true;
            this.chName.Width = 80;
            // 
            // chTransferTarget
            // 
            this.chTransferTarget.DataPropertyName = "TransferTarget";
            this.chTransferTarget.HeaderText = "轉入校";
            this.chTransferTarget.Name = "chTransferTarget";
            this.chTransferTarget.ReadOnly = true;
            this.chTransferTarget.Width = 200;
            // 
            // chStatus
            // 
            this.chStatus.DataPropertyName = "StatusString";
            this.chStatus.HeaderText = "處理進度";
            this.chStatus.Name = "chStatus";
            this.chStatus.ReadOnly = true;
            // 
            // chTrace
            // 
            this.chTrace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chTrace.DataPropertyName = "Trace";
            this.chTrace.HeaderText = "最後更新時間";
            this.chTrace.Name = "chTrace";
            this.chTrace.ReadOnly = true;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "轉出學生清單";
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 462);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StatusForm";
            this.Text = "";
            this.Load += new System.EventHandler(this.StatusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferIn)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvTransferOut;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvTransferIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chClass_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTrace1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn chName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTransferTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn chStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTrace;
        private DevComponents.DotNetBar.ContextMenuBar contextMenuBar1;
        private DevComponents.DotNetBar.ButtonItem OutMenu;
        private DevComponents.DotNetBar.ButtonItem btnOutExportXml;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllIn;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllOut;
        private DevComponents.DotNetBar.ButtonItem btnTransferReport;
        private DevComponents.DotNetBar.ContextMenuBar contextMenuBar2;
        private DevComponents.DotNetBar.ButtonItem InMenu;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem btnExportInXml;
        private DevComponents.DotNetBar.ButtonItem btnArchive;
        private DevComponents.DotNetBar.ButtonItem btnUnArchive;
        private DevComponents.DotNetBar.ButtonItem btnStatus_1;
        private DevComponents.DotNetBar.ButtonItem btnInDel;
    }
}