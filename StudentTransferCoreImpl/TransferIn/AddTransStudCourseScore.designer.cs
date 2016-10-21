//namespace StudentTransferCoreImpl
//{
//    partial class AddTransStudCourseScore
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
//            this.lblSchoolYearSemester = new DevComponents.DotNetBar.LabelX();
//            this.labelX1 = new DevComponents.DotNetBar.LabelX();
//            this.cboExam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
//            this.dgScore = new DevComponents.DotNetBar.Controls.DataGridViewX();
//            this.colSCETakeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colEffort = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colAssignmentScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colTextDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.cacheIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.btnSave = new DevComponents.DotNetBar.ButtonX();
//            this.lblStudMsg = new DevComponents.DotNetBar.LabelX();
//            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.lblMsg = new DevComponents.DotNetBar.LabelX();
//            ((System.ComponentModel.ISupportInitialize)(this.dgScore)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // lblSchoolYearSemester
//            // 
//            this.lblSchoolYearSemester.BackColor = System.Drawing.Color.Transparent;
//            this.lblSchoolYearSemester.Location = new System.Drawing.Point(12, 37);
//            this.lblSchoolYearSemester.Name = "lblSchoolYearSemester";
//            this.lblSchoolYearSemester.Size = new System.Drawing.Size(165, 23);
//            this.lblSchoolYearSemester.TabIndex = 0;
//            // 
//            // labelX1
//            // 
//            this.labelX1.BackColor = System.Drawing.Color.Transparent;
//            this.labelX1.Location = new System.Drawing.Point(273, 37);
//            this.labelX1.Name = "labelX1";
//            this.labelX1.Size = new System.Drawing.Size(54, 23);
//            this.labelX1.TabIndex = 1;
//            this.labelX1.Text = "評量別";
//            // 
//            // cboExam
//            // 
//            this.cboExam.DisplayMember = "Text";
//            this.cboExam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
//            this.cboExam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cboExam.FormattingEnabled = true;
//            this.cboExam.ItemHeight = 17;
//            this.cboExam.Location = new System.Drawing.Point(339, 37);
//            this.cboExam.Name = "cboExam";
//            this.cboExam.Size = new System.Drawing.Size(139, 23);
//            this.cboExam.TabIndex = 2;
//            this.cboExam.SelectedIndexChanged += new System.EventHandler(this.cboExam_SelectedIndexChanged);
//            // 
//            // dgScore
//            // 
//            this.dgScore.AllowUserToAddRows = false;
//            this.dgScore.AllowUserToDeleteRows = false;
//            this.dgScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.colSCETakeID,
//            this.colCourseName,
//            this.colScore,
//            this.colEffort,
//            this.colAssignmentScore,
//            this.colTextDescription,
//            this.cacheIndex});
//            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
//            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
//            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
//            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
//            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
//            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
//            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
//            this.dgScore.DefaultCellStyle = dataGridViewCellStyle1;
//            this.dgScore.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
//            this.dgScore.Location = new System.Drawing.Point(12, 68);
//            this.dgScore.Name = "dgScore";
//            this.dgScore.RowTemplate.Height = 24;
//            this.dgScore.Size = new System.Drawing.Size(466, 168);
//            this.dgScore.TabIndex = 3;
//            this.dgScore.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgScore_CellEndEdit);
//            // 
//            // colSCETakeID
//            // 
//            this.colSCETakeID.HeaderText = "SCETakeID";
//            this.colSCETakeID.Name = "colSCETakeID";
//            this.colSCETakeID.Visible = false;
//            // 
//            // colCourseName
//            // 
//            this.colCourseName.HeaderText = "課程名稱";
//            this.colCourseName.Name = "colCourseName";
//            this.colCourseName.ReadOnly = true;
//            // 
//            // colScore
//            // 
//            this.colScore.HeaderText = "分數評量";
//            this.colScore.Name = "colScore";
//            // 
//            // colEffort
//            // 
//            this.colEffort.HeaderText = "努力程度";
//            this.colEffort.Name = "colEffort";
//            // 
//            // colAssignmentScore
//            // 
//            this.colAssignmentScore.HeaderText = "評時分數";
//            this.colAssignmentScore.Name = "colAssignmentScore";
//            // 
//            // colTextDescription
//            // 
//            this.colTextDescription.HeaderText = "文字描述";
//            this.colTextDescription.Name = "colTextDescription";
//            // 
//            // cacheIndex
//            // 
//            this.cacheIndex.HeaderText = "cacheIndex";
//            this.cacheIndex.Name = "cacheIndex";
//            this.cacheIndex.Visible = false;
//            // 
//            // btnSave
//            // 
//            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
//            this.btnSave.BackColor = System.Drawing.Color.Transparent;
//            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
//            this.btnSave.Location = new System.Drawing.Point(403, 247);
//            this.btnSave.Name = "btnSave";
//            this.btnSave.Size = new System.Drawing.Size(75, 23);
//            this.btnSave.TabIndex = 4;
//            this.btnSave.Text = "儲存";
//            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
//            // 
//            // lblStudMsg
//            // 
//            this.lblStudMsg.BackColor = System.Drawing.Color.Transparent;
//            this.lblStudMsg.Location = new System.Drawing.Point(12, 8);
//            this.lblStudMsg.Name = "lblStudMsg";
//            this.lblStudMsg.Size = new System.Drawing.Size(466, 23);
//            this.lblStudMsg.TabIndex = 6;
//            this.lblStudMsg.Text = "labelX1";
//            // 
//            // dataGridViewTextBoxColumn1
//            // 
//            this.dataGridViewTextBoxColumn1.HeaderText = "ExamScoreID";
//            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
//            this.dataGridViewTextBoxColumn1.Visible = false;
//            // 
//            // dataGridViewTextBoxColumn2
//            // 
//            this.dataGridViewTextBoxColumn2.HeaderText = "課程名稱";
//            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
//            this.dataGridViewTextBoxColumn2.ReadOnly = true;
//            // 
//            // dataGridViewTextBoxColumn3
//            // 
//            this.dataGridViewTextBoxColumn3.HeaderText = "分數評量";
//            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
//            // 
//            // dataGridViewTextBoxColumn4
//            // 
//            this.dataGridViewTextBoxColumn4.HeaderText = "努力程度";
//            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
//            // 
//            // dataGridViewTextBoxColumn5
//            // 
//            this.dataGridViewTextBoxColumn5.HeaderText = "文字描述";
//            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
//            // 
//            // dataGridViewTextBoxColumn6
//            // 
//            this.dataGridViewTextBoxColumn6.HeaderText = "cacheIndex";
//            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
//            this.dataGridViewTextBoxColumn6.Visible = false;
//            // 
//            // lblMsg
//            // 
//            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
//            this.lblMsg.Location = new System.Drawing.Point(12, 247);
//            this.lblMsg.Name = "lblMsg";
//            this.lblMsg.Size = new System.Drawing.Size(210, 23);
//            this.lblMsg.TabIndex = 7;
//            this.lblMsg.Text = "labelX2";
//            // 
//            // AddTransStudCourseScore
//            // 
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
//            this.ClientSize = new System.Drawing.Size(490, 276);
//            this.Controls.Add(this.lblMsg);
//            this.Controls.Add(this.lblStudMsg);
//            this.Controls.Add(this.btnSave);
//            this.Controls.Add(this.dgScore);
//            this.Controls.Add(this.cboExam);
//            this.Controls.Add(this.labelX1);
//            this.Controls.Add(this.lblSchoolYearSemester);
//            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
//            this.MaximumSize = new System.Drawing.Size(498, 310);
//            this.MinimumSize = new System.Drawing.Size(498, 310);
//            this.Name = "AddTransStudCourseScore";
//            this.Text = "學期課程成績輸入";
//            this.Load += new System.EventHandler(this.AddTransStudCourseScore_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.dgScore)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private DevComponents.DotNetBar.LabelX lblSchoolYearSemester;
//        private DevComponents.DotNetBar.LabelX labelX1;
//        private DevComponents.DotNetBar.Controls.ComboBoxEx cboExam;
//        private DevComponents.DotNetBar.Controls.DataGridViewX dgScore;
//        private DevComponents.DotNetBar.ButtonX btnSave;
//        private DevComponents.DotNetBar.LabelX lblStudMsg;
//        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
//        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
//        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
//        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
//        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
//        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colSCETakeID;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colCourseName;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colEffort;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignmentScore;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colTextDescription;
//        private System.Windows.Forms.DataGridViewTextBoxColumn cacheIndex;
//        private DevComponents.DotNetBar.LabelX lblMsg;
//    }
//}