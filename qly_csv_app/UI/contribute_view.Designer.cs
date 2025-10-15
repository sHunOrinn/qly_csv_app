namespace qly_csv_app.UI
{
    partial class contribute_view
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.cmb_filter = new System.Windows.Forms.ComboBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.dgv_contributions = new System.Windows.Forms.DataGridView();
            this.summaryPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.lbl_summary = new System.Windows.Forms.Label();
            this.quanLy_CSVDataSet = new qly_csv_app.QuanLy_CSVDataSet();
            this.quanLyCSVDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contributionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contributionTableAdapter = new qly_csv_app.QuanLy_CSVDataSetTableAdapters.ContributionTableAdapter();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_contributions)).BeginInit();
            this.summaryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quanLy_CSVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyCSVDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contributionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.titleLabel.Location = new System.Drawing.Point(20, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(242, 37);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Chi tiết đóng góp";
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lbl_info.Location = new System.Drawing.Point(20, 60);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(180, 25);
            this.lbl_info.TabIndex = 1;
            this.lbl_info.Text = "Thông tin đóng góp";
            // 
            // filterPanel
            // 
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Controls.Add(this.refreshButton);
            this.filterPanel.Controls.Add(this.cmb_filter);
            this.filterPanel.Controls.Add(this.filterLabel);
            this.filterPanel.Location = new System.Drawing.Point(20, 95);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(840, 50);
            this.filterPanel.TabIndex = 2;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.refreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Location = new System.Drawing.Point(285, 10);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(94, 30);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Làm mới";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // cmb_filter
            // 
            this.cmb_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_filter.FormattingEnabled = true;
            this.cmb_filter.Items.AddRange(new object[] {
            "Tất cả",
            "Tiền",
            "Khác"});
            this.cmb_filter.Location = new System.Drawing.Point(121, 10);
            this.cmb_filter.Name = "cmb_filter";
            this.cmb_filter.Size = new System.Drawing.Size(120, 28);
            this.cmb_filter.TabIndex = 1;
            this.cmb_filter.SelectedIndexChanged += new System.EventHandler(this.CmbFilter_SelectedIndexChanged);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLabel.Location = new System.Drawing.Point(10, 15);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(98, 20);
            this.filterLabel.TabIndex = 0;
            this.filterLabel.Text = "Lọc theo loại:";
            // 
            // dgv_contributions
            // 
            this.dgv_contributions.AllowUserToAddRows = false;
            this.dgv_contributions.AllowUserToDeleteRows = false;
            this.dgv_contributions.BackgroundColor = System.Drawing.Color.White;
            this.dgv_contributions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_contributions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_contributions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_contributions.EnableHeadersVisualStyles = false;
            this.dgv_contributions.Location = new System.Drawing.Point(20, 155);
            this.dgv_contributions.MultiSelect = false;
            this.dgv_contributions.Name = "dgv_contributions";
            this.dgv_contributions.ReadOnly = true;
            this.dgv_contributions.RowHeadersVisible = false;
            this.dgv_contributions.RowHeadersWidth = 51;
            this.dgv_contributions.RowTemplate.Height = 24;
            this.dgv_contributions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_contributions.Size = new System.Drawing.Size(840, 350);
            this.dgv_contributions.TabIndex = 3;
            // 
            // summaryPanel
            // 
            this.summaryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.summaryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.summaryPanel.Controls.Add(this.closeButton);
            this.summaryPanel.Controls.Add(this.lbl_summary);
            this.summaryPanel.Location = new System.Drawing.Point(20, 515);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Size = new System.Drawing.Size(840, 40);
            this.summaryPanel.TabIndex = 4;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(750, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 30);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Đóng";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // lbl_summary
            // 
            this.lbl_summary.AutoSize = true;
            this.lbl_summary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_summary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lbl_summary.Location = new System.Drawing.Point(10, 7);
            this.lbl_summary.Name = "lbl_summary";
            this.lbl_summary.Size = new System.Drawing.Size(186, 25);
            this.lbl_summary.TabIndex = 0;
            this.lbl_summary.Text = "Tổng kết đóng góp";
            // 
            // quanLy_CSVDataSet
            // 
            this.quanLy_CSVDataSet.DataSetName = "QuanLy_CSVDataSet";
            this.quanLy_CSVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contributionTableAdapter
            // 
            this.contributionTableAdapter.ClearBeforeFill = true;
            // 
            // contribute_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.summaryPanel);
            this.Controls.Add(this.dgv_contributions);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "contribute_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết đóng góp";
            this.Load += new System.EventHandler(this.contribute_view_Load);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_contributions)).EndInit();
            this.summaryPanel.ResumeLayout(false);
            this.summaryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quanLy_CSVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyCSVDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contributionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ComboBox cmb_filter;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.DataGridView dgv_contributions;
        private System.Windows.Forms.Panel summaryPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label lbl_summary;
        private System.Windows.Forms.BindingSource quanLyCSVDataSetBindingSource;
        private QuanLy_CSVDataSet quanLy_CSVDataSet;
        private System.Windows.Forms.BindingSource contributionBindingSource;
        private QuanLy_CSVDataSetTableAdapters.ContributionTableAdapter contributionTableAdapter;
    }
}