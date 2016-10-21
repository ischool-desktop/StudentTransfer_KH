namespace StudentTransferCoreImpl.TransferOut
{
    partial class StudentTag
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPlace = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEthnicGroup = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStuTag = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chChecked = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEthnicGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuTag)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(327, 315);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(242, 315);
            // 
            // dgvPlace
            // 
            this.dgvPlace.AllowUserToAddRows = false;
            this.dgvPlace.AllowUserToDeleteRows = false;
            this.dgvPlace.AllowUserToResizeRows = false;
            this.dgvPlace.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlace.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlace.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPlace.HighlightSelectedColumnHeaders = false;
            this.dgvPlace.Location = new System.Drawing.Point(216, 198);
            this.dgvPlace.MultiSelect = false;
            this.dgvPlace.Name = "dgvPlace";
            this.dgvPlace.ReadOnly = true;
            this.dgvPlace.RowHeadersVisible = false;
            this.dgvPlace.RowTemplate.Height = 24;
            this.dgvPlace.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlace.Size = new System.Drawing.Size(184, 99);
            this.dgvPlace.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "居住地";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dgvEthnicGroup
            // 
            this.dgvEthnicGroup.AllowUserToAddRows = false;
            this.dgvEthnicGroup.AllowUserToDeleteRows = false;
            this.dgvEthnicGroup.AllowUserToResizeRows = false;
            this.dgvEthnicGroup.BackgroundColor = System.Drawing.Color.White;
            this.dgvEthnicGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEthnicGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEthnicGroup.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEthnicGroup.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvEthnicGroup.HighlightSelectedColumnHeaders = false;
            this.dgvEthnicGroup.Location = new System.Drawing.Point(216, 12);
            this.dgvEthnicGroup.MultiSelect = false;
            this.dgvEthnicGroup.Name = "dgvEthnicGroup";
            this.dgvEthnicGroup.ReadOnly = true;
            this.dgvEthnicGroup.RowHeadersVisible = false;
            this.dgvEthnicGroup.RowTemplate.Height = 24;
            this.dgvEthnicGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEthnicGroup.Size = new System.Drawing.Size(184, 180);
            this.dgvEthnicGroup.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "原住民族別";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dgvStuTag
            // 
            this.dgvStuTag.AllowUserToAddRows = false;
            this.dgvStuTag.AllowUserToDeleteRows = false;
            this.dgvStuTag.AllowUserToResizeRows = false;
            this.dgvStuTag.BackgroundColor = System.Drawing.Color.White;
            this.dgvStuTag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStuTag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chChecked,
            this.chName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStuTag.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStuTag.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvStuTag.HighlightSelectedColumnHeaders = false;
            this.dgvStuTag.Location = new System.Drawing.Point(12, 12);
            this.dgvStuTag.MultiSelect = false;
            this.dgvStuTag.Name = "dgvStuTag";
            this.dgvStuTag.ReadOnly = true;
            this.dgvStuTag.RowHeadersVisible = false;
            this.dgvStuTag.RowTemplate.Height = 24;
            this.dgvStuTag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStuTag.Size = new System.Drawing.Size(198, 284);
            this.dgvStuTag.TabIndex = 1;
            this.dgvStuTag.SelectionChanged += new System.EventHandler(this.dgvStuTag_SelectionChanged);
            // 
            // chChecked
            // 
            this.chChecked.Checked = true;
            this.chChecked.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chChecked.CheckValue = "N";
            this.chChecked.HeaderText = "●";
            this.chChecked.Name = "chChecked";
            this.chChecked.ReadOnly = true;
            this.chChecked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chChecked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chChecked.Width = 30;
            // 
            // chName
            // 
            this.chName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chName.HeaderText = "學生身份註記";
            this.chName.Name = "chName";
            this.chName.ReadOnly = true;
            // 
            // StudentTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 352);
            this.Controls.Add(this.dgvPlace);
            this.Controls.Add(this.dgvEthnicGroup);
            this.Controls.Add(this.dgvStuTag);
            this.Name = "StudentTag";
            this.Text = "線上轉學精靈 (轉出) - 學生身份確認";
            this.Load += new System.EventHandler(this.StudentTag_Load);
            this.Controls.SetChildIndex(this.dgvStuTag, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.dgvEthnicGroup, 0);
            this.Controls.SetChildIndex(this.dgvPlace, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEthnicGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuTag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPlace;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvEthnicGroup;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvStuTag;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn chChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn chName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}