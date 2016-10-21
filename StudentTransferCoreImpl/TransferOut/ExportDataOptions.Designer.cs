namespace StudentTransferCoreImpl.TransferOut
{
    partial class ExportDataOptions
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
            this.dgProcessor = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chChecked = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.chTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgProcessor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(341, 254);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(256, 254);
            // 
            // dgProcessor
            // 
            this.dgProcessor.AllowUserToAddRows = false;
            this.dgProcessor.AllowUserToDeleteRows = false;
            this.dgProcessor.AllowUserToResizeRows = false;
            this.dgProcessor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProcessor.BackgroundColor = System.Drawing.Color.White;
            this.dgProcessor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProcessor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chChecked,
            this.chTitle});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProcessor.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgProcessor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgProcessor.HighlightSelectedColumnHeaders = false;
            this.dgProcessor.Location = new System.Drawing.Point(12, 12);
            this.dgProcessor.MultiSelect = false;
            this.dgProcessor.Name = "dgProcessor";
            this.dgProcessor.RowHeadersVisible = false;
            this.dgProcessor.RowTemplate.Height = 24;
            this.dgProcessor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProcessor.Size = new System.Drawing.Size(404, 226);
            this.dgProcessor.TabIndex = 3;
            // 
            // chChecked
            // 
            this.chChecked.Checked = true;
            this.chChecked.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chChecked.CheckValue = "N";
            this.chChecked.HeaderText = "●";
            this.chChecked.Name = "chChecked";
            this.chChecked.Width = 30;
            // 
            // chTitle
            // 
            this.chTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chTitle.HeaderText = "資料名稱";
            this.chTitle.Name = "chTitle";
            this.chTitle.ReadOnly = true;
            this.chTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExportDataOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 291);
            this.Controls.Add(this.dgProcessor);
            this.Name = "ExportDataOptions";
            this.Text = "線上轉學精靈 (轉出) - 轉出資料確認";
            this.Load += new System.EventHandler(this.ExportDataOptions_Load);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.dgProcessor, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgProcessor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgProcessor;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn chChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTitle;
    }
}