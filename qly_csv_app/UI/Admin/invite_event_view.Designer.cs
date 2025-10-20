namespace qly_csv_app.UI.Admin
{
    partial class invite_event_view
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
            this.dataGridView_events = new System.Windows.Forms.DataGridView();
            this.event_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_khoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so_luong_tham_gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_xacnhan = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_events)).BeginInit();
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
            this.lbl_title.Location = new System.Drawing.Point(270, 15);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(300, 37);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Mời Tham Gia Sự Kiện";
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
            this.label1.Location = new System.Drawing.Point(20, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn sự kiện để mời cựu sinh viên:";
            // 
            // label_khoa
            // 
            this.label_khoa.AutoSize = true;
            this.label_khoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_khoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_khoa.Location = new System.Drawing.Point(420, 125);
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
            this.comboBox_khoa.Location = new System.Drawing.Point(510, 122);
            this.comboBox_khoa.Name = "comboBox_khoa";
            this.comboBox_khoa.Size = new System.Drawing.Size(240, 31);
            this.comboBox_khoa.TabIndex = 4;
            this.comboBox_khoa.SelectedIndexChanged += new System.EventHandler(this.comboBox_khoa_SelectedIndexChanged);
            // 
            // dataGridView_events
            // 
            this.dataGridView_events.AllowUserToAddRows = false;
            this.dataGridView_events.AllowUserToDeleteRows = false;
            this.dataGridView_events.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_events.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_events.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_events.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.event_id,
            this.event_name,
            this.event_date,
            this.ten_khoa,
            this.description,
            this.so_luong_tham_gia});
            this.dataGridView_events.Location = new System.Drawing.Point(25, 170);
            this.dataGridView_events.MultiSelect = false;
            this.dataGridView_events.Name = "dataGridView_events";
            this.dataGridView_events.ReadOnly = true;
            this.dataGridView_events.RowHeadersWidth = 51;
            this.dataGridView_events.RowTemplate.Height = 28;
            this.dataGridView_events.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_events.Size = new System.Drawing.Size(750, 280);
            this.dataGridView_events.TabIndex = 5;
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
            this.event_name.Width = 180;
            // 
            // event_date
            // 
            this.event_date.DataPropertyName = "event_date";
            this.event_date.HeaderText = "Ngày Diễn Ra";
            this.event_date.MinimumWidth = 6;
            this.event_date.Name = "event_date";
            this.event_date.ReadOnly = true;
            this.event_date.Width = 120;
            // 
            // ten_khoa
            // 
            this.ten_khoa.DataPropertyName = "ten_khoa";
            this.ten_khoa.HeaderText = "Khoa Tổ Chức";
            this.ten_khoa.MinimumWidth = 6;
            this.ten_khoa.Name = "ten_khoa";
            this.ten_khoa.ReadOnly = true;
            this.ten_khoa.Width = 130;
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
            // so_luong_tham_gia
            // 
            this.so_luong_tham_gia.DataPropertyName = "so_luong_tham_gia";
            this.so_luong_tham_gia.HeaderText = "SL Tham Gia";
            this.so_luong_tham_gia.MinimumWidth = 6;
            this.so_luong_tham_gia.Name = "so_luong_tham_gia";
            this.so_luong_tham_gia.ReadOnly = true;
            this.so_luong_tham_gia.Width = 100;
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_xacnhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_xacnhan.FlatAppearance.BorderSize = 0;
            this.btn_xacnhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xacnhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xacnhan.ForeColor = System.Drawing.Color.White;
            this.btn_xacnhan.Location = new System.Drawing.Point(499, 470);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(134, 40);
            this.btn_xacnhan.TabIndex = 6;
            this.btn_xacnhan.Text = "Xác Nhận";
            this.btn_xacnhan.UseVisualStyleBackColor = false;
            this.btn_xacnhan.Click += new System.EventHandler(this.btn_xacnhan_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_huy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_huy.FlatAppearance.BorderSize = 0;
            this.btn_huy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_huy.ForeColor = System.Drawing.Color.White;
            this.btn_huy.Location = new System.Drawing.Point(659, 470);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(116, 40);
            this.btn_huy.TabIndex = 7;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.UseVisualStyleBackColor = false;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(25, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Vui lòng chọn một sự kiện để gửi lời mời";
            // 
            // invite_event_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_xacnhan);
            this.Controls.Add(this.dataGridView_events);
            this.Controls.Add(this.comboBox_khoa);
            this.Controls.Add(this.label_khoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_cuusv_info);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "invite_event_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mời Tham Gia Sự Kiện";
            this.Load += new System.EventHandler(this.invite_event_view_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_events)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView_events;
        private System.Windows.Forms.Button btn_xacnhan;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_khoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn so_luong_tham_gia;
    }
}