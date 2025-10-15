namespace qly_csv_app.UI.Admin
{
    partial class csv_invited_view
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_event_info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_csv = new System.Windows.Forms.DataGridView();
            this.csv_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_csv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mssv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.participation_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_dong = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_thongke = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_csv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 60);
            this.panel1.TabIndex = 0;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(220, 15);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(360, 37);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Danh Sách Cựu Sinh Viên Được Mời";
            // 
            // lbl_event_info
            // 
            this.lbl_event_info.AutoSize = true;
            this.lbl_event_info.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_event_info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lbl_event_info.Location = new System.Drawing.Point(20, 80);
            this.lbl_event_info.Name = "lbl_event_info";
            this.lbl_event_info.Size = new System.Drawing.Size(111, 28);
            this.lbl_event_info.TabIndex = 1;
            this.lbl_event_info.Text = "Sự kiện: ...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh sách cựu sinh viên đã được mời:";
            // 
            // dataGridView_csv
            // 
            this.dataGridView_csv.AllowUserToAddRows = false;
            this.dataGridView_csv.AllowUserToDeleteRows = false;
            this.dataGridView_csv.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_csv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_csv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_csv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.csv_id,
            this.ten_csv,
            this.mssv,
            this.email,
            this.phone,
            this.participation_date,
            this.status});
            this.dataGridView_csv.Location = new System.Drawing.Point(25, 190);
            this.dataGridView_csv.Name = "dataGridView_csv";
            this.dataGridView_csv.ReadOnly = true;
            this.dataGridView_csv.RowHeadersWidth = 51;
            this.dataGridView_csv.RowTemplate.Height = 28;
            this.dataGridView_csv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_csv.Size = new System.Drawing.Size(750, 300);
            this.dataGridView_csv.TabIndex = 3;
            this.dataGridView_csv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_csv_CellDoubleClick);
            // 
            // csv_id
            // 
            this.csv_id.DataPropertyName = "CSV_id";
            this.csv_id.HeaderText = "ID";
            this.csv_id.MinimumWidth = 6;
            this.csv_id.Name = "csv_id";
            this.csv_id.ReadOnly = true;
            this.csv_id.Width = 50;
            // 
            // ten_csv
            // 
            this.ten_csv.DataPropertyName = "Ten";
            this.ten_csv.HeaderText = "Họ Tên";
            this.ten_csv.MinimumWidth = 6;
            this.ten_csv.Name = "ten_csv";
            this.ten_csv.ReadOnly = true;
            this.ten_csv.Width = 120;
            // 
            // mssv
            // 
            this.mssv.DataPropertyName = "MSSV";
            this.mssv.HeaderText = "MSSV";
            this.mssv.MinimumWidth = 6;
            this.mssv.Name = "mssv";
            this.mssv.ReadOnly = true;
            this.mssv.Width = 80;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 150;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "Điện Thoại";
            this.phone.MinimumWidth = 6;
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Width = 100;
            // 
            // participation_date
            // 
            this.participation_date.DataPropertyName = "participation_date";
            this.participation_date.HeaderText = "Ngày Mời";
            this.participation_date.MinimumWidth = 6;
            this.participation_date.Name = "participation_date";
            this.participation_date.ReadOnly = true;
            this.participation_date.Width = 100;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Trạng Thái";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 100;
            // 
            // btn_dong
            // 
            this.btn_dong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btn_dong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dong.FlatAppearance.BorderSize = 0;
            this.btn_dong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dong.ForeColor = System.Drawing.Color.White;
            this.btn_dong.Location = new System.Drawing.Point(680, 510);
            this.btn_dong.Name = "btn_dong";
            this.btn_dong.Size = new System.Drawing.Size(95, 40);
            this.btn_dong.TabIndex = 4;
            this.btn_dong.Text = "Đóng";
            this.btn_dong.UseVisualStyleBackColor = false;
            this.btn_dong.Click += new System.EventHandler(this.btn_dong_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(25, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hiển thị tất cả cựu sinh viên đã được mời sự kiện này";
            // 
            // lbl_thongke
            // 
            this.lbl_thongke.AutoSize = true;
            this.lbl_thongke.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_thongke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_thongke.Location = new System.Drawing.Point(20, 115);
            this.lbl_thongke.Name = "lbl_thongke";
            this.lbl_thongke.Size = new System.Drawing.Size(272, 23);
            this.lbl_thongke.TabIndex = 6;
            this.lbl_thongke.Text = "Tổng số lời mời: 0 | Đã chấp nhận: 0";
            // 
            // csv_invited_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.lbl_thongke);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_dong);
            this.Controls.Add(this.dataGridView_csv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_event_info);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "csv_invited_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh Sách Cựu Sinh Viên Được Mời";
            this.Load += new System.EventHandler(this.csv_invited_view_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_csv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_event_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_csv;
        private System.Windows.Forms.Button btn_dong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_thongke;
        private System.Windows.Forms.DataGridViewTextBoxColumn csv_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_csv;
        private System.Windows.Forms.DataGridViewTextBoxColumn mssv;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn participation_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}