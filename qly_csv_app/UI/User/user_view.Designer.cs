namespace qly_csv_app.UI.User
{
    partial class user_view
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
            this.panel_sidebar = new System.Windows.Forms.Panel();
            this.btn_dangxuat = new System.Windows.Forms.Button();
            this.btn_thongtincanhan = new System.Windows.Forms.Button();
            this.btn_danhsachsukienthamgia = new System.Windows.Forms.Button();
            this.btn_danhsachloimoi = new System.Windows.Forms.Button();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.panel_content = new System.Windows.Forms.Panel();
            this.panel_loimoi = new System.Windows.Forms.Panel();
            this.dataGridView_invitations = new System.Windows.Forms.DataGridView();
            this.eventidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.participationidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSVidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.participationdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedbackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.participationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLy_CSVDataSet = new qly_csv_app.QuanLy_CSVDataSet();
            this.btn_chapnhan = new System.Windows.Forms.Button();
            this.btn_tuchoi = new System.Windows.Forms.Button();
            this.label_loimoi_title = new System.Windows.Forms.Label();
            this.panel_sukienthamgia = new System.Windows.Forms.Panel();
            this.dataGridView_accepted_events = new System.Windows.Forms.DataGridView();
            this.label_accepted_events_title = new System.Windows.Forms.Label();
            this.panel_thongtin = new System.Windows.Forms.Panel();
            this.txt_congty = new System.Windows.Forms.TextBox();
            this.txt_congviec = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_doimatkhau = new System.Windows.Forms.Button();
            this.btn_capnhat_thongtin = new System.Windows.Forms.Button();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_diachi = new System.Windows.Forms.TextBox();
            this.txt_mssv = new System.Windows.Forms.TextBox();
            this.txt_hoten = new System.Windows.Forms.TextBox();
            this.dtp_ngaysinh = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_thongtin_title = new System.Windows.Forms.Label();
            this.participationTableAdapter = new qly_csv_app.QuanLy_CSVDataSetTableAdapters.ParticipationTableAdapter();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eventTableAdapter = new qly_csv_app.QuanLy_CSVDataSetTableAdapters.EventTableAdapter();
            this.panel_sidebar.SuspendLayout();
            this.panel_content.SuspendLayout();
            this.panel_loimoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_invitations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.participationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLy_CSVDataSet)).BeginInit();
            this.panel_sukienthamgia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_accepted_events)).BeginInit();
            this.panel_thongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_sidebar
            // 
            this.panel_sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panel_sidebar.Controls.Add(this.btn_dangxuat);
            this.panel_sidebar.Controls.Add(this.btn_thongtincanhan);
            this.panel_sidebar.Controls.Add(this.btn_danhsachsukienthamgia);
            this.panel_sidebar.Controls.Add(this.btn_danhsachloimoi);
            this.panel_sidebar.Controls.Add(this.lbl_welcome);
            this.panel_sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_sidebar.Location = new System.Drawing.Point(0, 0);
            this.panel_sidebar.Name = "panel_sidebar";
            this.panel_sidebar.Size = new System.Drawing.Size(220, 450);
            this.panel_sidebar.TabIndex = 0;
            // 
            // btn_dangxuat
            // 
            this.btn_dangxuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_dangxuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dangxuat.FlatAppearance.BorderSize = 0;
            this.btn_dangxuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dangxuat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dangxuat.ForeColor = System.Drawing.Color.White;
            this.btn_dangxuat.Location = new System.Drawing.Point(12, 350);
            this.btn_dangxuat.Name = "btn_dangxuat";
            this.btn_dangxuat.Size = new System.Drawing.Size(196, 45);
            this.btn_dangxuat.TabIndex = 3;
            this.btn_dangxuat.Text = "Đăng xuất";
            this.btn_dangxuat.UseVisualStyleBackColor = false;
            this.btn_dangxuat.Click += new System.EventHandler(this.btn_dangxuat_Click);
            // 
            // btn_thongtincanhan
            // 
            this.btn_thongtincanhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_thongtincanhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thongtincanhan.FlatAppearance.BorderSize = 0;
            this.btn_thongtincanhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thongtincanhan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thongtincanhan.ForeColor = System.Drawing.Color.White;
            this.btn_thongtincanhan.Location = new System.Drawing.Point(12, 269);
            this.btn_thongtincanhan.Name = "btn_thongtincanhan";
            this.btn_thongtincanhan.Size = new System.Drawing.Size(196, 45);
            this.btn_thongtincanhan.TabIndex = 2;
            this.btn_thongtincanhan.Text = "Thông tin cá nhân";
            this.btn_thongtincanhan.UseVisualStyleBackColor = false;
            this.btn_thongtincanhan.Click += new System.EventHandler(this.btn_thongtincanhan_Click);
            // 
            // btn_danhsachsukienthamgia
            // 
            this.btn_danhsachsukienthamgia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btn_danhsachsukienthamgia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_danhsachsukienthamgia.FlatAppearance.BorderSize = 0;
            this.btn_danhsachsukienthamgia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_danhsachsukienthamgia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_danhsachsukienthamgia.ForeColor = System.Drawing.Color.White;
            this.btn_danhsachsukienthamgia.Location = new System.Drawing.Point(12, 182);
            this.btn_danhsachsukienthamgia.Name = "btn_danhsachsukienthamgia";
            this.btn_danhsachsukienthamgia.Size = new System.Drawing.Size(196, 65);
            this.btn_danhsachsukienthamgia.TabIndex = 4;
            this.btn_danhsachsukienthamgia.Text = "Danh sách sự kiện\r\ntham gia";
            this.btn_danhsachsukienthamgia.UseVisualStyleBackColor = false;
            this.btn_danhsachsukienthamgia.Click += new System.EventHandler(this.btn_danhsachsukienthamgia_Click);
            // 
            // btn_danhsachloimoi
            // 
            this.btn_danhsachloimoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btn_danhsachloimoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_danhsachloimoi.FlatAppearance.BorderSize = 0;
            this.btn_danhsachloimoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_danhsachloimoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_danhsachloimoi.ForeColor = System.Drawing.Color.White;
            this.btn_danhsachloimoi.Location = new System.Drawing.Point(12, 120);
            this.btn_danhsachloimoi.Name = "btn_danhsachloimoi";
            this.btn_danhsachloimoi.Size = new System.Drawing.Size(196, 45);
            this.btn_danhsachloimoi.TabIndex = 1;
            this.btn_danhsachloimoi.Text = "Danh sách lời mời";
            this.btn_danhsachloimoi.UseVisualStyleBackColor = false;
            this.btn_danhsachloimoi.Click += new System.EventHandler(this.btn_danhsachloimoi_Click);
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.Color.White;
            this.lbl_welcome.Location = new System.Drawing.Point(15, 30);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(151, 60);
            this.lbl_welcome.TabIndex = 0;
            // 
            // panel_content
            // 
            this.panel_content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panel_content.Controls.Add(this.panel_thongtin);
            this.panel_content.Controls.Add(this.panel_loimoi);
            this.panel_content.Controls.Add(this.panel_sukienthamgia);
            this.panel_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_content.Location = new System.Drawing.Point(220, 0);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(1026, 450);
            this.panel_content.TabIndex = 1;
            // 
            // panel_loimoi
            // 
            this.panel_loimoi.Controls.Add(this.dataGridView_invitations);
            this.panel_loimoi.Controls.Add(this.btn_chapnhan);
            this.panel_loimoi.Controls.Add(this.btn_tuchoi);
            this.panel_loimoi.Controls.Add(this.label_loimoi_title);
            this.panel_loimoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_loimoi.Location = new System.Drawing.Point(0, 0);
            this.panel_loimoi.Name = "panel_loimoi";
            this.panel_loimoi.Size = new System.Drawing.Size(1026, 450);
            this.panel_loimoi.TabIndex = 0;
            this.panel_loimoi.Visible = false;
            // 
            // dataGridView_invitations
            // 
            this.dataGridView_invitations.AllowUserToAddRows = false;
            this.dataGridView_invitations.AllowUserToDeleteRows = false;
            this.dataGridView_invitations.AutoGenerateColumns = false;
            this.dataGridView_invitations.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_invitations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_invitations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_invitations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventidDataGridViewTextBoxColumn,
            this.participationidDataGridViewTextBoxColumn,
            this.cSVidDataGridViewTextBoxColumn,
            this.participationdateDataGridViewTextBoxColumn,
            this.feedbackDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dataGridView_invitations.DataSource = this.participationBindingSource;
            this.dataGridView_invitations.Location = new System.Drawing.Point(20, 60);
            this.dataGridView_invitations.Name = "dataGridView_invitations";
            this.dataGridView_invitations.ReadOnly = true;
            this.dataGridView_invitations.RowHeadersWidth = 51;
            this.dataGridView_invitations.RowTemplate.Height = 24;
            this.dataGridView_invitations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_invitations.Size = new System.Drawing.Size(994, 320);
            this.dataGridView_invitations.TabIndex = 3;
            // 
            // eventidDataGridViewTextBoxColumn
            // 
            this.eventidDataGridViewTextBoxColumn.DataPropertyName = "event_id";
            this.eventidDataGridViewTextBoxColumn.HeaderText = "event_id";
            this.eventidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.eventidDataGridViewTextBoxColumn.Name = "eventidDataGridViewTextBoxColumn";
            this.eventidDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventidDataGridViewTextBoxColumn.Width = 125;
            // 
            // participationidDataGridViewTextBoxColumn
            // 
            this.participationidDataGridViewTextBoxColumn.DataPropertyName = "participation_id";
            this.participationidDataGridViewTextBoxColumn.HeaderText = "participation_id";
            this.participationidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.participationidDataGridViewTextBoxColumn.Name = "participationidDataGridViewTextBoxColumn";
            this.participationidDataGridViewTextBoxColumn.ReadOnly = true;
            this.participationidDataGridViewTextBoxColumn.Width = 125;
            // 
            // cSVidDataGridViewTextBoxColumn
            // 
            this.cSVidDataGridViewTextBoxColumn.DataPropertyName = "CSV_id";
            this.cSVidDataGridViewTextBoxColumn.HeaderText = "CSV_id";
            this.cSVidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cSVidDataGridViewTextBoxColumn.Name = "cSVidDataGridViewTextBoxColumn";
            this.cSVidDataGridViewTextBoxColumn.ReadOnly = true;
            this.cSVidDataGridViewTextBoxColumn.Width = 125;
            // 
            // participationdateDataGridViewTextBoxColumn
            // 
            this.participationdateDataGridViewTextBoxColumn.DataPropertyName = "participation_date";
            this.participationdateDataGridViewTextBoxColumn.HeaderText = "participation_date";
            this.participationdateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.participationdateDataGridViewTextBoxColumn.Name = "participationdateDataGridViewTextBoxColumn";
            this.participationdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.participationdateDataGridViewTextBoxColumn.Width = 125;
            // 
            // feedbackDataGridViewTextBoxColumn
            // 
            this.feedbackDataGridViewTextBoxColumn.DataPropertyName = "feedback";
            this.feedbackDataGridViewTextBoxColumn.HeaderText = "feedback";
            this.feedbackDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.feedbackDataGridViewTextBoxColumn.Name = "feedbackDataGridViewTextBoxColumn";
            this.feedbackDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedbackDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // participationBindingSource
            // 
            this.participationBindingSource.DataMember = "Participation";
            this.participationBindingSource.DataSource = this.quanLy_CSVDataSet;
            // 
            // quanLy_CSVDataSet
            // 
            this.quanLy_CSVDataSet.DataSetName = "QuanLy_CSVDataSet";
            this.quanLy_CSVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_chapnhan
            // 
            this.btn_chapnhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_chapnhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_chapnhan.FlatAppearance.BorderSize = 0;
            this.btn_chapnhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chapnhan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chapnhan.ForeColor = System.Drawing.Color.White;
            this.btn_chapnhan.Location = new System.Drawing.Point(20, 400);
            this.btn_chapnhan.Name = "btn_chapnhan";
            this.btn_chapnhan.Size = new System.Drawing.Size(120, 35);
            this.btn_chapnhan.TabIndex = 1;
            this.btn_chapnhan.Text = "Chấp nhận";
            this.btn_chapnhan.UseVisualStyleBackColor = false;
            this.btn_chapnhan.Click += new System.EventHandler(this.btn_chapnhan_Click);
            // 
            // btn_tuchoi
            // 
            this.btn_tuchoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_tuchoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_tuchoi.FlatAppearance.BorderSize = 0;
            this.btn_tuchoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tuchoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tuchoi.ForeColor = System.Drawing.Color.White;
            this.btn_tuchoi.Location = new System.Drawing.Point(160, 400);
            this.btn_tuchoi.Name = "btn_tuchoi";
            this.btn_tuchoi.Size = new System.Drawing.Size(120, 35);
            this.btn_tuchoi.TabIndex = 2;
            this.btn_tuchoi.Text = "Từ chối";
            this.btn_tuchoi.UseVisualStyleBackColor = false;
            this.btn_tuchoi.Click += new System.EventHandler(this.btn_tuchoi_Click);
            // 
            // label_loimoi_title
            // 
            this.label_loimoi_title.AutoSize = true;
            this.label_loimoi_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_loimoi_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label_loimoi_title.Location = new System.Drawing.Point(20, 20);
            this.label_loimoi_title.Name = "label_loimoi_title";
            this.label_loimoi_title.Size = new System.Drawing.Size(244, 37);
            this.label_loimoi_title.TabIndex = 0;
            this.label_loimoi_title.Text = "Danh sách lời mời";
            // 
            // panel_sukienthamgia
            // 
            this.panel_sukienthamgia.Controls.Add(this.dataGridView_accepted_events);
            this.panel_sukienthamgia.Controls.Add(this.label_accepted_events_title);
            this.panel_sukienthamgia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sukienthamgia.Location = new System.Drawing.Point(0, 0);
            this.panel_sukienthamgia.Name = "panel_sukienthamgia";
            this.panel_sukienthamgia.Size = new System.Drawing.Size(1026, 450);
            this.panel_sukienthamgia.TabIndex = 2;
            this.panel_sukienthamgia.Visible = false;
            // 
            // dataGridView_accepted_events
            // 
            this.dataGridView_accepted_events.AllowUserToAddRows = false;
            this.dataGridView_accepted_events.AllowUserToDeleteRows = false;
            this.dataGridView_accepted_events.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_accepted_events.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_accepted_events.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_accepted_events.Location = new System.Drawing.Point(20, 60);
            this.dataGridView_accepted_events.MultiSelect = false;
            this.dataGridView_accepted_events.Name = "dataGridView_accepted_events";
            this.dataGridView_accepted_events.ReadOnly = true;
            this.dataGridView_accepted_events.RowHeadersWidth = 51;
            this.dataGridView_accepted_events.RowTemplate.Height = 24;
            this.dataGridView_accepted_events.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_accepted_events.Size = new System.Drawing.Size(994, 370);
            this.dataGridView_accepted_events.TabIndex = 1;
            // 
            // label_accepted_events_title
            // 
            this.label_accepted_events_title.AutoSize = true;
            this.label_accepted_events_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_accepted_events_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label_accepted_events_title.Location = new System.Drawing.Point(20, 20);
            this.label_accepted_events_title.Name = "label_accepted_events_title";
            this.label_accepted_events_title.Size = new System.Drawing.Size(366, 37);
            this.label_accepted_events_title.TabIndex = 0;
            this.label_accepted_events_title.Text = "Danh sách sự kiện tham gia";
            // 
            // panel_thongtin
            // 
            this.panel_thongtin.Controls.Add(this.txt_congty);
            this.panel_thongtin.Controls.Add(this.txt_congviec);
            this.panel_thongtin.Controls.Add(this.label8);
            this.panel_thongtin.Controls.Add(this.label7);
            this.panel_thongtin.Controls.Add(this.btn_doimatkhau);
            this.panel_thongtin.Controls.Add(this.btn_capnhat_thongtin);
            this.panel_thongtin.Controls.Add(this.txt_phone);
            this.panel_thongtin.Controls.Add(this.txt_email);
            this.panel_thongtin.Controls.Add(this.txt_diachi);
            this.panel_thongtin.Controls.Add(this.txt_mssv);
            this.panel_thongtin.Controls.Add(this.txt_hoten);
            this.panel_thongtin.Controls.Add(this.dtp_ngaysinh);
            this.panel_thongtin.Controls.Add(this.label6);
            this.panel_thongtin.Controls.Add(this.label5);
            this.panel_thongtin.Controls.Add(this.label4);
            this.panel_thongtin.Controls.Add(this.label3);
            this.panel_thongtin.Controls.Add(this.label2);
            this.panel_thongtin.Controls.Add(this.label1);
            this.panel_thongtin.Controls.Add(this.label_thongtin_title);
            this.panel_thongtin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_thongtin.Location = new System.Drawing.Point(0, 0);
            this.panel_thongtin.Name = "panel_thongtin";
            this.panel_thongtin.Size = new System.Drawing.Size(1026, 450);
            this.panel_thongtin.TabIndex = 1;
            this.panel_thongtin.Visible = false;
            // 
            // txt_congty
            // 
            this.txt_congty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_congty.Location = new System.Drawing.Point(200, 430);
            this.txt_congty.Name = "txt_congty";
            this.txt_congty.Size = new System.Drawing.Size(300, 30);
            this.txt_congty.TabIndex = 16;
            // 
            // txt_congviec
            // 
            this.txt_congviec.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_congviec.Location = new System.Drawing.Point(200, 380);
            this.txt_congviec.Name = "txt_congviec";
            this.txt_congviec.Size = new System.Drawing.Size(300, 30);
            this.txt_congviec.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(60, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Công ty";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(60, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "Công việc";
            // 
            // btn_doimatkhau
            // 
            this.btn_doimatkhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btn_doimatkhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_doimatkhau.FlatAppearance.BorderSize = 0;
            this.btn_doimatkhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_doimatkhau.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_doimatkhau.ForeColor = System.Drawing.Color.White;
            this.btn_doimatkhau.Location = new System.Drawing.Point(352, 480);
            this.btn_doimatkhau.Name = "btn_doimatkhau";
            this.btn_doimatkhau.Size = new System.Drawing.Size(165, 40);
            this.btn_doimatkhau.TabIndex = 14;
            this.btn_doimatkhau.Text = "Đổi mật khẩu";
            this.btn_doimatkhau.UseVisualStyleBackColor = false;
            this.btn_doimatkhau.Click += new System.EventHandler(this.btn_doimatkhau_Click);
            // 
            // btn_capnhat_thongtin
            // 
            this.btn_capnhat_thongtin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btn_capnhat_thongtin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_capnhat_thongtin.FlatAppearance.BorderSize = 0;
            this.btn_capnhat_thongtin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_capnhat_thongtin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_capnhat_thongtin.ForeColor = System.Drawing.Color.White;
            this.btn_capnhat_thongtin.Location = new System.Drawing.Point(160, 480);
            this.btn_capnhat_thongtin.Name = "btn_capnhat_thongtin";
            this.btn_capnhat_thongtin.Size = new System.Drawing.Size(158, 40);
            this.btn_capnhat_thongtin.TabIndex = 13;
            this.btn_capnhat_thongtin.Text = "Cập nhật";
            this.btn_capnhat_thongtin.UseVisualStyleBackColor = false;
            this.btn_capnhat_thongtin.Click += new System.EventHandler(this.btn_capnhat_thongtin_Click);
            // 
            // txt_phone
            // 
            this.txt_phone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phone.Location = new System.Drawing.Point(200, 330);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(300, 30);
            this.txt_phone.TabIndex = 12;
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(200, 280);
            this.txt_email.Name = "txt_email";
            this.txt_email.ReadOnly = true;
            this.txt_email.Size = new System.Drawing.Size(300, 30);
            this.txt_email.TabIndex = 11;
            // 
            // txt_diachi
            // 
            this.txt_diachi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_diachi.Location = new System.Drawing.Point(200, 230);
            this.txt_diachi.Name = "txt_diachi";
            this.txt_diachi.Size = new System.Drawing.Size(300, 30);
            this.txt_diachi.TabIndex = 10;
            // 
            // txt_mssv
            // 
            this.txt_mssv.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mssv.Location = new System.Drawing.Point(200, 180);
            this.txt_mssv.Name = "txt_mssv";
            this.txt_mssv.ReadOnly = true;
            this.txt_mssv.Size = new System.Drawing.Size(300, 30);
            this.txt_mssv.TabIndex = 9;
            // 
            // txt_hoten
            // 
            this.txt_hoten.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_hoten.Location = new System.Drawing.Point(200, 80);
            this.txt_hoten.Name = "txt_hoten";
            this.txt_hoten.Size = new System.Drawing.Size(300, 30);
            this.txt_hoten.TabIndex = 8;
            // 
            // dtp_ngaysinh
            // 
            this.dtp_ngaysinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngaysinh.Location = new System.Drawing.Point(200, 130);
            this.dtp_ngaysinh.Name = "dtp_ngaysinh";
            this.dtp_ngaysinh.Size = new System.Drawing.Size(300, 30);
            this.dtp_ngaysinh.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(60, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Số điện thoại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(60, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(60, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(60, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "MSSV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(60, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày sinh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(60, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ và tên";
            // 
            // label_thongtin_title
            // 
            this.label_thongtin_title.AutoSize = true;
            this.label_thongtin_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thongtin_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label_thongtin_title.Location = new System.Drawing.Point(20, 20);
            this.label_thongtin_title.Name = "label_thongtin_title";
            this.label_thongtin_title.Size = new System.Drawing.Size(246, 37);
            this.label_thongtin_title.TabIndex = 0;
            this.label_thongtin_title.Text = "Thông tin cá nhân";
            // 
            // participationTableAdapter
            // 
            this.participationTableAdapter.ClearBeforeFill = true;
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataMember = "Event";
            this.eventBindingSource.DataSource = this.quanLy_CSVDataSet;
            // 
            // eventTableAdapter
            // 
            this.eventTableAdapter.ClearBeforeFill = true;
            // 
            // user_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 550);
            this.Controls.Add(this.panel_content);
            this.Controls.Add(this.panel_sidebar);
            this.Name = "user_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cựu Sinh Viên - Hệ thống quản lý";
            this.Load += new System.EventHandler(this.user_view_Load);
            this.panel_sidebar.ResumeLayout(false);
            this.panel_content.ResumeLayout(false);
            this.panel_loimoi.ResumeLayout(false);
            this.panel_loimoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_invitations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.participationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLy_CSVDataSet)).EndInit();
            this.panel_sukienthamgia.ResumeLayout(false);
            //this.panel_sukienthamgia.PersumeLayout();
            this.panel_sukienthamgia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_accepted_events)).EndInit();
            this.panel_thongtin.ResumeLayout(false);
            this.panel_thongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_sidebar;
        private System.Windows.Forms.Button btn_dangxuat;
        private System.Windows.Forms.Button btn_thongtincanhan;
        private System.Windows.Forms.Button btn_danhsachsukienthamgia;
        private System.Windows.Forms.Button btn_danhsachloimoi;
        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Panel panel_content;
        private System.Windows.Forms.Panel panel_sukienthamgia;
        private System.Windows.Forms.DataGridView dataGridView_accepted_events;
        private System.Windows.Forms.Label label_accepted_events_title;
        private System.Windows.Forms.Panel panel_loimoi;
        private System.Windows.Forms.DataGridView dataGridView_invitations;
        private System.Windows.Forms.Button btn_chapnhan;
        private System.Windows.Forms.Button btn_tuchoi;
        private System.Windows.Forms.Label label_loimoi_title;
        private System.Windows.Forms.Panel panel_thongtin;
        private System.Windows.Forms.TextBox txt_congty;
        private System.Windows.Forms.TextBox txt_congviec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_doimatkhau;
        private System.Windows.Forms.Button btn_capnhat_thongtin;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_diachi;
        private System.Windows.Forms.TextBox txt_mssv;
        private System.Windows.Forms.TextBox txt_hoten;
        private System.Windows.Forms.DateTimePicker dtp_ngaysinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_thongtin_title;
        private QuanLy_CSVDataSet quanLy_CSVDataSet;
        private System.Windows.Forms.BindingSource participationBindingSource;
        private QuanLy_CSVDataSetTableAdapters.ParticipationTableAdapter participationTableAdapter;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private QuanLy_CSVDataSetTableAdapters.EventTableAdapter eventTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn participationidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSVidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn participationdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedbackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}