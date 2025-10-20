namespace qly_csv_app.UI.Admin
{
    partial class event_invited_view
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
            this.lbl_cuusv_info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_khoa = new System.Windows.Forms.Label();
            this.comboBox_khoa = new System.Windows.Forms.ComboBox();
            this.dataGridView_invitations = new System.Windows.Forms.DataGridView();
            this.event_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_khoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.participation_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_dong = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_thongke = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_invitations)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 60);
            this.panel1.TabIndex = 0;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(240, 15);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(358, 37);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Danh Sách Lời Mời Sự Kiện";
            // 
            // lbl_cuusv_info
            // 
            this.lbl_cuusv_info.AutoSize = true;
            this.lbl_cuusv_info.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cuusv_info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lbl_cuusv_info.Location = new System.Drawing.Point(20, 80);
            this.lbl_cuusv_info.Name = "lbl_cuusv_info";
            this.lbl_cuusv_info.Size = new System.Drawing.Size(166, 28);
            this.lbl_cuusv_info.TabIndex = 1;
            this.lbl_cuusv_info.Text = "Cựu sinh viên: ...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh sách các sự kiện đã được mời:";
            // 
            // label_khoa
            // 
            this.label_khoa.AutoSize = true;
            this.label_khoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_khoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_khoa.Location = new System.Drawing.Point(450, 155);
            this.label_khoa.Name = "label_khoa";
            this.label_khoa.Size = new System.Drawing.Size(79, 23);
            this.label_khoa.TabIndex = 3;
            this.label_khoa.Text = "Lọc khoa:";
            // 
            // comboBox_khoa
            // 
            this.comboBox_khoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_khoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_khoa.FormattingEnabled = true;
            this.comboBox_khoa.Location = new System.Drawing.Point(540, 152);
            this.comboBox_khoa.Name = "comboBox_khoa";
            this.comboBox_khoa.Size = new System.Drawing.Size(240, 31);
            this.comboBox_khoa.TabIndex = 4;
            this.comboBox_khoa.SelectedIndexChanged += new System.EventHandler(this.comboBox_khoa_SelectedIndexChanged);
            // 
            // dataGridView_invitations
            // 
            this.dataGridView_invitations.AllowUserToAddRows = false;
            this.dataGridView_invitations.AllowUserToDeleteRows = false;
            this.dataGridView_invitations.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_invitations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_invitations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_invitations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.event_id,
            this.event_name,
            this.event_date,
            this.ten_khoa,
            this.participation_date,
            this.status,
            this.description});
            this.dataGridView_invitations.Location = new System.Drawing.Point(25, 200);
            this.dataGridView_invitations.Name = "dataGridView_invitations";
            this.dataGridView_invitations.ReadOnly = true;
            this.dataGridView_invitations.RowHeadersWidth = 51;
            this.dataGridView_invitations.RowTemplate.Height = 28;
            this.dataGridView_invitations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_invitations.Size = new System.Drawing.Size(800, 300);
            this.dataGridView_invitations.TabIndex = 5;
            // 
            // event_id
            // 
            this.event_id.DataPropertyName = "event_id";
            this.event_id.HeaderText = "ID";
            this.event_id.MinimumWidth = 6;
            this.event_id.Name = "event_id";
            this.event_id.ReadOnly = true;
            this.event_id.Width = 50;
            // 
            // event_name
            // 
            this.event_name.DataPropertyName = "event_name";
            this.event_name.HeaderText = "Tên Sự Kiện";
            this.event_name.MinimumWidth = 6;
            this.event_name.Name = "event_name";
            this.event_name.ReadOnly = true;
            this.event_name.Width = 140;
            // 
            // event_date
            // 
            this.event_date.DataPropertyName = "event_date";
            this.event_date.HeaderText = "Ngày Tổ Chức";
            this.event_date.MinimumWidth = 6;
            this.event_date.Name = "event_date";
            this.event_date.ReadOnly = true;
            this.event_date.Width = 110;
            // 
            // ten_khoa
            // 
            this.ten_khoa.DataPropertyName = "ten_khoa";
            this.ten_khoa.HeaderText = "Khoa Tổ Chức";
            this.ten_khoa.MinimumWidth = 6;
            this.ten_khoa.Name = "ten_khoa";
            this.ten_khoa.ReadOnly = true;
            this.ten_khoa.Width = 120;
            // 
            // participation_date
            // 
            this.participation_date.DataPropertyName = "participation_date";
            this.participation_date.HeaderText = "Ngày Mời";
            this.participation_date.MinimumWidth = 6;
            this.participation_date.Name = "participation_date";
            this.participation_date.ReadOnly = true;
            this.participation_date.Width = 110;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Trạng Thái";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 110;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Mô Tả";
            this.description.MinimumWidth = 6;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 150;
            // 
            // btn_dong
            // 
            this.btn_dong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btn_dong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dong.FlatAppearance.BorderSize = 0;
            this.btn_dong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dong.ForeColor = System.Drawing.Color.White;
            this.btn_dong.Location = new System.Drawing.Point(730, 520);
            this.btn_dong.Name = "btn_dong";
            this.btn_dong.Size = new System.Drawing.Size(95, 40);
            this.btn_dong.TabIndex = 6;
            this.btn_dong.Text = "Đóng";
            this.btn_dong.UseVisualStyleBackColor = false;
            this.btn_dong.Click += new System.EventHandler(this.btn_dong_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(25, 530);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hiển thị tất cả lời mời sự kiện của cựu sinh viên này";
            // 
            // lbl_thongke
            // 
            this.lbl_thongke.AutoSize = true;
            this.lbl_thongke.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_thongke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_thongke.Location = new System.Drawing.Point(20, 115);
            this.lbl_thongke.Name = "lbl_thongke";
            this.lbl_thongke.Size = new System.Drawing.Size(285, 23);
            this.lbl_thongke.TabIndex = 8;
            this.lbl_thongke.Text = "Tổng số lời mời: 0 | Đã chấp nhận: 0";
            // 
            // event_invited_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(850, 580);
            this.Controls.Add(this.lbl_thongke);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_dong);
            this.Controls.Add(this.dataGridView_invitations);
            this.Controls.Add(this.comboBox_khoa);
            this.Controls.Add(this.label_khoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_cuusv_info);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "event_invited_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh Sách Lời Mời Sự Kiện";
            this.Load += new System.EventHandler(this.event_invited_view_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_invitations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_cuusv_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_khoa;
        private System.Windows.Forms.ComboBox comboBox_khoa;
        private System.Windows.Forms.DataGridView dataGridView_invitations;
        private System.Windows.Forms.Button btn_dong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_thongke;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_khoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn participation_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
    }
}