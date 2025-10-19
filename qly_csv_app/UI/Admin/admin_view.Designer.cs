namespace qly_csv_app.UI.Admin
{
    partial class admin_view
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
            this.panel_buttons = new System.Windows.Forms.Panel();
            this.btn_dangxuat = new System.Windows.Forms.Button();
            this.btn_themadmin = new System.Windows.Forms.Button();
            this.btn_danhsachsukien = new System.Windows.Forms.Button();
            this.btn_danhsachcuusinhvien = new System.Windows.Forms.Button();
            this.panel_content = new System.Windows.Forms.Panel();
            this.panel_cuusinhvien = new System.Windows.Forms.Panel();
            this.comboBox_fillkhoa = new System.Windows.Forms.ComboBox();
            this.khoaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.quanLy_CSVDataSet = new qly_csv_app.QuanLy_CSVDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_moithamgiasukien = new System.Windows.Forms.Button();
            this.btn_xoacuusinhvien = new System.Windows.Forms.Button();
            this.btn_themcuusinhvien = new System.Windows.Forms.Button();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cSVidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaySinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mSSVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuuSVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_sukien = new System.Windows.Forms.Panel();
            this.dataGridView_events = new System.Windows.Forms.DataGridView();
            this.eventidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluongthamgiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_timkiem_event = new System.Windows.Forms.TextBox();
            this.btn_timkiem_event = new System.Windows.Forms.Button();
            this.btn_them_event = new System.Windows.Forms.Button();
            this.btn_xoa_event = new System.Windows.Forms.Button();
            this.btn_capnhat_event = new System.Windows.Forms.Button();
            this.label_event_title = new System.Windows.Forms.Label();
            this.label_timkiem_event = new System.Windows.Forms.Label();
            this.panel_themadmin = new System.Windows.Forms.Panel();
            this.dataGridView_admins = new System.Windows.Forms.DataGridView();
            this.btn_them_admin_new = new System.Windows.Forms.Button();
            this.label_admin_title = new System.Windows.Forms.Label();
            this.cuuSVTableAdapter = new qly_csv_app.QuanLy_CSVDataSetTableAdapters.CuuSVTableAdapter();
            this.eventTableAdapter = new qly_csv_app.QuanLy_CSVDataSetTableAdapters.EventTableAdapter();
            this.khoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khoaTableAdapter = new qly_csv_app.QuanLy_CSVDataSetTableAdapters.KhoaTableAdapter();
            this.panel_buttons.SuspendLayout();
            this.panel_content.SuspendLayout();
            this.panel_cuusinhvien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLy_CSVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuuSVBindingSource)).BeginInit();
            this.panel_sukien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_events)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            this.panel_themadmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_admins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_buttons
            // 
            this.panel_buttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panel_buttons.Controls.Add(this.btn_dangxuat);
            this.panel_buttons.Controls.Add(this.btn_themadmin);
            this.panel_buttons.Controls.Add(this.btn_danhsachsukien);
            this.panel_buttons.Controls.Add(this.btn_danhsachcuusinhvien);
            this.panel_buttons.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_buttons.Location = new System.Drawing.Point(0, 0);
            this.panel_buttons.Name = "panel_buttons";
            this.panel_buttons.Size = new System.Drawing.Size(200, 454);
            this.panel_buttons.TabIndex = 0;
            // 
            // btn_dangxuat
            // 
            this.btn_dangxuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_dangxuat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dangxuat.ForeColor = System.Drawing.Color.White;
            this.btn_dangxuat.Location = new System.Drawing.Point(12, 276);
            this.btn_dangxuat.Name = "btn_dangxuat";
            this.btn_dangxuat.Size = new System.Drawing.Size(176, 50);
            this.btn_dangxuat.TabIndex = 3;
            this.btn_dangxuat.Text = "Đăng xuất";
            this.btn_dangxuat.UseVisualStyleBackColor = false;
            this.btn_dangxuat.Click += new System.EventHandler(this.btn_dangxuat_Click);
            // 
            // btn_themadmin
            // 
            this.btn_themadmin.BackColor = System.Drawing.Color.Lime;
            this.btn_themadmin.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_themadmin.ForeColor = System.Drawing.Color.White;
            this.btn_themadmin.Location = new System.Drawing.Point(12, 203);
            this.btn_themadmin.Name = "btn_themadmin";
            this.btn_themadmin.Size = new System.Drawing.Size(176, 50);
            this.btn_themadmin.TabIndex = 2;
            this.btn_themadmin.Text = "Thêm admin";
            this.btn_themadmin.UseVisualStyleBackColor = false;
            this.btn_themadmin.Click += new System.EventHandler(this.btn_themadmin_Click);
            // 
            // btn_danhsachsukien
            // 
            this.btn_danhsachsukien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_danhsachsukien.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_danhsachsukien.ForeColor = System.Drawing.Color.White;
            this.btn_danhsachsukien.Location = new System.Drawing.Point(12, 110);
            this.btn_danhsachsukien.Name = "btn_danhsachsukien";
            this.btn_danhsachsukien.Size = new System.Drawing.Size(176, 74);
            this.btn_danhsachsukien.TabIndex = 1;
            this.btn_danhsachsukien.Text = "Danh sách sự kiện";
            this.btn_danhsachsukien.UseVisualStyleBackColor = false;
            this.btn_danhsachsukien.Click += new System.EventHandler(this.btn_danhsachsukien_Click);
            // 
            // btn_danhsachcuusinhvien
            // 
            this.btn_danhsachcuusinhvien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btn_danhsachcuusinhvien.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_danhsachcuusinhvien.ForeColor = System.Drawing.Color.White;
            this.btn_danhsachcuusinhvien.Location = new System.Drawing.Point(12, 40);
            this.btn_danhsachcuusinhvien.Name = "btn_danhsachcuusinhvien";
            this.btn_danhsachcuusinhvien.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.btn_danhsachcuusinhvien.Size = new System.Drawing.Size(176, 50);
            this.btn_danhsachcuusinhvien.TabIndex = 0;
            this.btn_danhsachcuusinhvien.Text = "Danh sách cựu sinh viên";
            this.btn_danhsachcuusinhvien.UseVisualStyleBackColor = false;
            this.btn_danhsachcuusinhvien.Click += new System.EventHandler(this.btn_danhsachcuusinhvien_Click);
            // 
            // panel_content
            // 
            this.panel_content.Controls.Add(this.panel_cuusinhvien);
            this.panel_content.Controls.Add(this.panel_sukien);
            this.panel_content.Controls.Add(this.panel_themadmin);
            this.panel_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_content.Location = new System.Drawing.Point(200, 0);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(1066, 454);
            this.panel_content.TabIndex = 1;
            // 
            // panel_cuusinhvien
            // 
            this.panel_cuusinhvien.Controls.Add(this.comboBox_fillkhoa);
            this.panel_cuusinhvien.Controls.Add(this.label2);
            this.panel_cuusinhvien.Controls.Add(this.btn_moithamgiasukien);
            this.panel_cuusinhvien.Controls.Add(this.btn_xoacuusinhvien);
            this.panel_cuusinhvien.Controls.Add(this.btn_themcuusinhvien);
            this.panel_cuusinhvien.Controls.Add(this.btn_timkiem);
            this.panel_cuusinhvien.Controls.Add(this.label1);
            this.panel_cuusinhvien.Controls.Add(this.txt_timkiem);
            this.panel_cuusinhvien.Controls.Add(this.dataGridView1);
            this.panel_cuusinhvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cuusinhvien.Location = new System.Drawing.Point(0, 0);
            this.panel_cuusinhvien.Name = "panel_cuusinhvien";
            this.panel_cuusinhvien.Size = new System.Drawing.Size(1066, 454);
            this.panel_cuusinhvien.TabIndex = 0;
            this.panel_cuusinhvien.Visible = false;
            // 
            // comboBox_fillkhoa
            // 
            this.comboBox_fillkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_fillkhoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_fillkhoa.FormattingEnabled = true;
            this.comboBox_fillkhoa.Location = new System.Drawing.Point(419, 19);
            this.comboBox_fillkhoa.Name = "comboBox_fillkhoa";
            this.comboBox_fillkhoa.Size = new System.Drawing.Size(203, 31);
            this.comboBox_fillkhoa.TabIndex = 8;
            this.comboBox_fillkhoa.SelectedIndexChanged += new System.EventHandler(this.comboBox_fillkhoa_SelectedIndexChanged);
            // 
            // khoaBindingSource1
            // 
            this.khoaBindingSource1.DataMember = "Khoa";
            this.khoaBindingSource1.DataSource = this.quanLy_CSVDataSet;
            // 
            // quanLy_CSVDataSet
            // 
            this.quanLy_CSVDataSet.DataSetName = "QuanLy_CSVDataSet";
            this.quanLy_CSVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Danh sách cựu SV";
            // 
            // btn_moithamgiasukien
            // 
            this.btn_moithamgiasukien.BackColor = System.Drawing.Color.LightBlue;
            this.btn_moithamgiasukien.Location = new System.Drawing.Point(443, 396);
            this.btn_moithamgiasukien.Name = "btn_moithamgiasukien";
            this.btn_moithamgiasukien.Size = new System.Drawing.Size(157, 35);
            this.btn_moithamgiasukien.TabIndex = 5;
            this.btn_moithamgiasukien.Text = "Mời tham gia sự kiện";
            this.btn_moithamgiasukien.UseVisualStyleBackColor = false;
            this.btn_moithamgiasukien.Click += new System.EventHandler(this.btn_moithamgiasukien_Click);
            // 
            // btn_xoacuusinhvien
            // 
            this.btn_xoacuusinhvien.BackColor = System.Drawing.Color.LightCoral;
            this.btn_xoacuusinhvien.Location = new System.Drawing.Point(303, 396);
            this.btn_xoacuusinhvien.Name = "btn_xoacuusinhvien";
            this.btn_xoacuusinhvien.Size = new System.Drawing.Size(120, 35);
            this.btn_xoacuusinhvien.TabIndex = 4;
            this.btn_xoacuusinhvien.Text = "Xóa cựu SV";
            this.btn_xoacuusinhvien.UseVisualStyleBackColor = false;
            this.btn_xoacuusinhvien.Click += new System.EventHandler(this.btn_xoacuusinhvien_Click);
            // 
            // btn_themcuusinhvien
            // 
            this.btn_themcuusinhvien.BackColor = System.Drawing.Color.LightGreen;
            this.btn_themcuusinhvien.Location = new System.Drawing.Point(165, 396);
            this.btn_themcuusinhvien.Name = "btn_themcuusinhvien";
            this.btn_themcuusinhvien.Size = new System.Drawing.Size(120, 35);
            this.btn_themcuusinhvien.TabIndex = 3;
            this.btn_themcuusinhvien.Text = "Thêm cựu SV";
            this.btn_themcuusinhvien.UseVisualStyleBackColor = false;
            this.btn_themcuusinhvien.Click += new System.EventHandler(this.btn_themcuusinhvien_Click);
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Location = new System.Drawing.Point(300, 18);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(80, 32);
            this.btn_timkiem.TabIndex = 2;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tìm kiếm:";
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(85, 23);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(200, 22);
            this.txt_timkiem.TabIndex = 1;
            this.txt_timkiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_timkiem_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSVidDataGridViewTextBoxColumn,
            this.tenDataGridViewTextBoxColumn,
            this.ngaySinhDataGridViewTextBoxColumn,
            this.mSSVDataGridViewTextBoxColumn,
            this.dCDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cuuSVBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1042, 280);
            this.dataGridView1.TabIndex = 0;
            // 
            // cSVidDataGridViewTextBoxColumn
            // 
            this.cSVidDataGridViewTextBoxColumn.DataPropertyName = "CSV_id";
            this.cSVidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.cSVidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cSVidDataGridViewTextBoxColumn.Name = "cSVidDataGridViewTextBoxColumn";
            this.cSVidDataGridViewTextBoxColumn.ReadOnly = true;
            this.cSVidDataGridViewTextBoxColumn.Width = 50;
            // 
            // tenDataGridViewTextBoxColumn
            // 
            this.tenDataGridViewTextBoxColumn.DataPropertyName = "Ten";
            this.tenDataGridViewTextBoxColumn.HeaderText = "Họ Tên";
            this.tenDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tenDataGridViewTextBoxColumn.Name = "tenDataGridViewTextBoxColumn";
            this.tenDataGridViewTextBoxColumn.ReadOnly = true;
            this.tenDataGridViewTextBoxColumn.Width = 120;
            // 
            // ngaySinhDataGridViewTextBoxColumn
            // 
            this.ngaySinhDataGridViewTextBoxColumn.DataPropertyName = "NgaySinh";
            this.ngaySinhDataGridViewTextBoxColumn.HeaderText = "Ngày Sinh";
            this.ngaySinhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ngaySinhDataGridViewTextBoxColumn.Name = "ngaySinhDataGridViewTextBoxColumn";
            this.ngaySinhDataGridViewTextBoxColumn.ReadOnly = true;
            this.ngaySinhDataGridViewTextBoxColumn.Width = 90;
            // 
            // mSSVDataGridViewTextBoxColumn
            // 
            this.mSSVDataGridViewTextBoxColumn.DataPropertyName = "MSSV";
            this.mSSVDataGridViewTextBoxColumn.HeaderText = "MSSV";
            this.mSSVDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mSSVDataGridViewTextBoxColumn.Name = "mSSVDataGridViewTextBoxColumn";
            this.mSSVDataGridViewTextBoxColumn.ReadOnly = true;
            this.mSSVDataGridViewTextBoxColumn.Width = 80;
            // 
            // dCDataGridViewTextBoxColumn
            // 
            this.dCDataGridViewTextBoxColumn.DataPropertyName = "DC";
            this.dCDataGridViewTextBoxColumn.HeaderText = "Địa Chỉ";
            this.dCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dCDataGridViewTextBoxColumn.Name = "dCDataGridViewTextBoxColumn";
            this.dCDataGridViewTextBoxColumn.ReadOnly = true;
            this.dCDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 120;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Điện Thoại";
            this.phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.phoneDataGridViewTextBoxColumn.Width = 150;
            // 
            // cuuSVBindingSource
            // 
            this.cuuSVBindingSource.DataMember = "CuuSV";
            this.cuuSVBindingSource.DataSource = this.quanLy_CSVDataSet;
            // 
            // panel_sukien
            // 
            this.panel_sukien.Controls.Add(this.dataGridView_events);
            this.panel_sukien.Controls.Add(this.txt_timkiem_event);
            this.panel_sukien.Controls.Add(this.btn_timkiem_event);
            this.panel_sukien.Controls.Add(this.btn_them_event);
            this.panel_sukien.Controls.Add(this.btn_xoa_event);
            this.panel_sukien.Controls.Add(this.btn_capnhat_event);
            this.panel_sukien.Controls.Add(this.label_event_title);
            this.panel_sukien.Controls.Add(this.label_timkiem_event);
            this.panel_sukien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sukien.Location = new System.Drawing.Point(0, 0);
            this.panel_sukien.Name = "panel_sukien";
            this.panel_sukien.Size = new System.Drawing.Size(1066, 454);
            this.panel_sukien.TabIndex = 1;
            this.panel_sukien.Visible = false;
            // 
            // dataGridView_events
            // 
            this.dataGridView_events.AllowUserToAddRows = false;
            this.dataGridView_events.AllowUserToDeleteRows = false;
            this.dataGridView_events.AutoGenerateColumns = false;
            this.dataGridView_events.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_events.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_events.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_events.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventidDataGridViewTextBoxColumn,
            this.eventnameDataGridViewTextBoxColumn,
            this.eventdateDataGridViewTextBoxColumn,
            this.soluongthamgiaDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dataGridView_events.DataSource = this.eventBindingSource;
            this.dataGridView_events.Location = new System.Drawing.Point(24, 100);
            this.dataGridView_events.Name = "dataGridView_events";
            this.dataGridView_events.ReadOnly = true;
            this.dataGridView_events.RowHeadersWidth = 51;
            this.dataGridView_events.RowTemplate.Height = 24;
            this.dataGridView_events.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_events.Size = new System.Drawing.Size(1030, 280);
            this.dataGridView_events.TabIndex = 0;
            // 
            // eventidDataGridViewTextBoxColumn
            // 
            this.eventidDataGridViewTextBoxColumn.DataPropertyName = "event_id";
            this.eventidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.eventidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.eventidDataGridViewTextBoxColumn.Name = "eventidDataGridViewTextBoxColumn";
            this.eventidDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventidDataGridViewTextBoxColumn.Width = 50;
            // 
            // eventnameDataGridViewTextBoxColumn
            // 
            this.eventnameDataGridViewTextBoxColumn.DataPropertyName = "event_name";
            this.eventnameDataGridViewTextBoxColumn.HeaderText = "Tên sự kiện";
            this.eventnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.eventnameDataGridViewTextBoxColumn.Name = "eventnameDataGridViewTextBoxColumn";
            this.eventnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // eventdateDataGridViewTextBoxColumn
            // 
            this.eventdateDataGridViewTextBoxColumn.DataPropertyName = "event_date";
            this.eventdateDataGridViewTextBoxColumn.HeaderText = "Ngày tổ chức";
            this.eventdateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.eventdateDataGridViewTextBoxColumn.Name = "eventdateDataGridViewTextBoxColumn";
            this.eventdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventdateDataGridViewTextBoxColumn.Width = 125;
            // 
            // soluongthamgiaDataGridViewTextBoxColumn
            // 
            this.soluongthamgiaDataGridViewTextBoxColumn.DataPropertyName = "so_luong_tham_gia";
            this.soluongthamgiaDataGridViewTextBoxColumn.HeaderText = "Số lượng tham gia";
            this.soluongthamgiaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.soluongthamgiaDataGridViewTextBoxColumn.Name = "soluongthamgiaDataGridViewTextBoxColumn";
            this.soluongthamgiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.soluongthamgiaDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Mô tả";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 450;
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataMember = "Event";
            this.eventBindingSource.DataSource = this.quanLy_CSVDataSet;
            // 
            // txt_timkiem_event
            // 
            this.txt_timkiem_event.Location = new System.Drawing.Point(85, 23);
            this.txt_timkiem_event.Name = "txt_timkiem_event";
            this.txt_timkiem_event.Size = new System.Drawing.Size(200, 22);
            this.txt_timkiem_event.TabIndex = 1;
            // 
            // btn_timkiem_event
            // 
            this.btn_timkiem_event.Location = new System.Drawing.Point(300, 18);
            this.btn_timkiem_event.Name = "btn_timkiem_event";
            this.btn_timkiem_event.Size = new System.Drawing.Size(80, 32);
            this.btn_timkiem_event.TabIndex = 2;
            this.btn_timkiem_event.Text = "Tìm kiếm";
            this.btn_timkiem_event.UseVisualStyleBackColor = true;
            // 
            // btn_them_event
            // 
            this.btn_them_event.BackColor = System.Drawing.Color.LightGreen;
            this.btn_them_event.Location = new System.Drawing.Point(24, 390);
            this.btn_them_event.Name = "btn_them_event";
            this.btn_them_event.Size = new System.Drawing.Size(120, 35);
            this.btn_them_event.TabIndex = 3;
            this.btn_them_event.Text = "Thêm sự kiện";
            this.btn_them_event.UseVisualStyleBackColor = false;
            // 
            // btn_xoa_event
            // 
            this.btn_xoa_event.BackColor = System.Drawing.Color.LightCoral;
            this.btn_xoa_event.Location = new System.Drawing.Point(160, 390);
            this.btn_xoa_event.Name = "btn_xoa_event";
            this.btn_xoa_event.Size = new System.Drawing.Size(120, 35);
            this.btn_xoa_event.TabIndex = 4;
            this.btn_xoa_event.Text = "Xóa sự kiện";
            this.btn_xoa_event.UseVisualStyleBackColor = false;
            // 
            // btn_capnhat_event
            // 
            this.btn_capnhat_event.BackColor = System.Drawing.Color.LightBlue;
            this.btn_capnhat_event.Location = new System.Drawing.Point(300, 390);
            this.btn_capnhat_event.Name = "btn_capnhat_event";
            this.btn_capnhat_event.Size = new System.Drawing.Size(120, 35);
            this.btn_capnhat_event.TabIndex = 5;
            this.btn_capnhat_event.Text = "Cập nhật";
            this.btn_capnhat_event.UseVisualStyleBackColor = false;
            //this.btn_capnhat_event.Click += new System.EventHandler(this.btn_capnhat_event_Click_1);
            // 
            // label_event_title
            // 
            this.label_event_title.AutoSize = true;
            this.label_event_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_event_title.Location = new System.Drawing.Point(12, 70);
            this.label_event_title.Name = "label_event_title";
            this.label_event_title.Size = new System.Drawing.Size(190, 25);
            this.label_event_title.TabIndex = 6;
            this.label_event_title.Text = "Danh sách sự kiện";
            // 
            // label_timkiem_event
            // 
            this.label_timkiem_event.AutoSize = true;
            this.label_timkiem_event.Location = new System.Drawing.Point(12, 26);
            this.label_timkiem_event.Name = "label_timkiem_event";
            this.label_timkiem_event.Size = new System.Drawing.Size(65, 16);
            this.label_timkiem_event.TabIndex = 7;
            this.label_timkiem_event.Text = "Tìm kiếm:";
            // 
            // panel_themadmin
            // 
            this.panel_themadmin.Controls.Add(this.dataGridView_admins);
            this.panel_themadmin.Controls.Add(this.btn_them_admin_new);
            this.panel_themadmin.Controls.Add(this.label_admin_title);
            this.panel_themadmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_themadmin.Location = new System.Drawing.Point(0, 0);
            this.panel_themadmin.Name = "panel_themadmin";
            this.panel_themadmin.Size = new System.Drawing.Size(1066, 454);
            this.panel_themadmin.TabIndex = 2;
            this.panel_themadmin.Visible = false;
            // 
            // dataGridView_admins
            // 
            this.dataGridView_admins.AllowUserToAddRows = false;
            this.dataGridView_admins.AllowUserToDeleteRows = false;
            this.dataGridView_admins.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_admins.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_admins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_admins.Location = new System.Drawing.Point(24, 110);
            this.dataGridView_admins.Name = "dataGridView_admins";
            this.dataGridView_admins.ReadOnly = true;
            this.dataGridView_admins.RowHeadersWidth = 51;
            this.dataGridView_admins.RowTemplate.Height = 24;
            this.dataGridView_admins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_admins.Size = new System.Drawing.Size(773, 280);
            this.dataGridView_admins.TabIndex = 2;
            // 
            // btn_them_admin_new
            // 
            this.btn_them_admin_new.BackColor = System.Drawing.Color.LightGreen;
            this.btn_them_admin_new.Location = new System.Drawing.Point(24, 60);
            this.btn_them_admin_new.Name = "btn_them_admin_new";
            this.btn_them_admin_new.Size = new System.Drawing.Size(140, 35);
            this.btn_them_admin_new.TabIndex = 1;
            this.btn_them_admin_new.Text = "Thêm Admin mới";
            this.btn_them_admin_new.UseVisualStyleBackColor = false;
            this.btn_them_admin_new.Click += new System.EventHandler(this.btn_them_admin_new_Click);
            // 
            // label_admin_title
            // 
            this.label_admin_title.AutoSize = true;
            this.label_admin_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_admin_title.Location = new System.Drawing.Point(12, 20);
            this.label_admin_title.Name = "label_admin_title";
            this.label_admin_title.Size = new System.Drawing.Size(248, 25);
            this.label_admin_title.TabIndex = 0;
            this.label_admin_title.Text = "Quản lý tài khoản Admin";
            // 
            // cuuSVTableAdapter
            // 
            this.cuuSVTableAdapter.ClearBeforeFill = true;
            // 
            // eventTableAdapter
            // 
            this.eventTableAdapter.ClearBeforeFill = true;
            // 
            // khoaBindingSource
            // 
            this.khoaBindingSource.DataMember = "Khoa";
            this.khoaBindingSource.DataSource = this.quanLy_CSVDataSet;
            // 
            // khoaTableAdapter
            // 
            this.khoaTableAdapter.ClearBeforeFill = true;
            // 
            // admin_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 454);
            this.Controls.Add(this.panel_content);
            this.Controls.Add(this.panel_buttons);
            this.Name = "admin_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin - Quản lý CSV";
            this.Load += new System.EventHandler(this.admin_view_Load);
            this.panel_buttons.ResumeLayout(false);
            this.panel_content.ResumeLayout(false);
            this.panel_cuusinhvien.ResumeLayout(false);
            this.panel_cuusinhvien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLy_CSVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuuSVBindingSource)).EndInit();
            this.panel_sukien.ResumeLayout(false);
            this.panel_sukien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_events)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            this.panel_themadmin.ResumeLayout(false);
            this.panel_themadmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_admins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_buttons;
        private System.Windows.Forms.Button btn_dangxuat;
        private System.Windows.Forms.Button btn_themadmin;
        private System.Windows.Forms.Button btn_danhsachsukien;
        private System.Windows.Forms.Button btn_danhsachcuusinhvien;
        private System.Windows.Forms.Panel panel_content;
        private System.Windows.Forms.Panel panel_sukien;
        private System.Windows.Forms.DataGridView dataGridView_events;
        private System.Windows.Forms.TextBox txt_timkiem_event;
        private System.Windows.Forms.Button btn_timkiem_event;
        private System.Windows.Forms.Button btn_them_event;
        private System.Windows.Forms.Button btn_xoa_event;
        private System.Windows.Forms.Button btn_capnhat_event;
        private System.Windows.Forms.Label label_event_title;
        private System.Windows.Forms.Label label_timkiem_event;
        private System.Windows.Forms.Panel panel_themadmin;
        private System.Windows.Forms.Label label_admin_title;
        private System.Windows.Forms.Button btn_them_admin_new;
        private System.Windows.Forms.DataGridView dataGridView_admins;
        private System.Windows.Forms.Panel panel_cuusinhvien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_moithamgiasukien;
        private System.Windows.Forms.Button btn_xoacuusinhvien;
        private System.Windows.Forms.Button btn_themcuusinhvien;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private QuanLy_CSVDataSet quanLy_CSVDataSet;
        private System.Windows.Forms.BindingSource cuuSVBindingSource;
        private QuanLy_CSVDataSetTableAdapters.CuuSVTableAdapter cuuSVTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSVidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaySinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mSSVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private QuanLy_CSVDataSetTableAdapters.EventTableAdapter eventTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluongthamgiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox_fillkhoa;
        private System.Windows.Forms.BindingSource khoaBindingSource;
        private QuanLy_CSVDataSetTableAdapters.KhoaTableAdapter khoaTableAdapter;
        private System.Windows.Forms.BindingSource khoaBindingSource1;
    }
}