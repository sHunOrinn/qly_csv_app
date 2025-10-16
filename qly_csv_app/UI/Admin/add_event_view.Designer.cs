namespace qly_csv_app.UI.Admin
{
    partial class add_event_view
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_khoa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_event_name = new System.Windows.Forms.TextBox();
            this.dtp_event_date = new System.Windows.Forms.DateTimePicker();
            this.cb_khoa = new System.Windows.Forms.ComboBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 60);
            this.panel1.TabIndex = 0;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(170, 15);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(160, 37);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Thêm Sự Kiện";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(50, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên sự kiện *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(50, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày diễn ra *";
            // 
            // label_khoa
            // 
            this.label_khoa.AutoSize = true;
            this.label_khoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_khoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_khoa.Location = new System.Drawing.Point(50, 200);
            this.label_khoa.Name = "label_khoa";
            this.label_khoa.Size = new System.Drawing.Size(118, 23);
            this.label_khoa.TabIndex = 3;
            this.label_khoa.Text = "Khoa tổ chức *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(50, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mô tả";
            // 
            // txt_event_name
            // 
            this.txt_event_name.BackColor = System.Drawing.Color.White;
            this.txt_event_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_event_name.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_event_name.Location = new System.Drawing.Point(180, 97);
            this.txt_event_name.MaxLength = 255;
            this.txt_event_name.Name = "txt_event_name";
            this.txt_event_name.Size = new System.Drawing.Size(280, 30);
            this.txt_event_name.TabIndex = 5;
            // 
            // dtp_event_date
            // 
            this.dtp_event_date.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtp_event_date.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_event_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_event_date.Location = new System.Drawing.Point(180, 147);
            this.dtp_event_date.Name = "dtp_event_date";
            this.dtp_event_date.Size = new System.Drawing.Size(280, 30);
            this.dtp_event_date.TabIndex = 6;
            // 
            // cb_khoa
            // 
            this.cb_khoa.BackColor = System.Drawing.Color.White;
            this.cb_khoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_khoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_khoa.FormattingEnabled = true;
            this.cb_khoa.Location = new System.Drawing.Point(180, 197);
            this.cb_khoa.Name = "cb_khoa";
            this.cb_khoa.Size = new System.Drawing.Size(280, 31);
            this.cb_khoa.TabIndex = 7;
            // 
            // txt_description
            // 
            this.txt_description.BackColor = System.Drawing.Color.White;
            this.txt_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_description.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_description.Location = new System.Drawing.Point(180, 247);
            this.txt_description.MaxLength = 1000;
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_description.Size = new System.Drawing.Size(280, 80);
            this.txt_description.TabIndex = 8;
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_them.FlatAppearance.BorderSize = 0;
            this.btn_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.ForeColor = System.Drawing.Color.White;
            this.btn_them.Location = new System.Drawing.Point(180, 350);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(130, 40);
            this.btn_them.TabIndex = 9;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_huy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_huy.FlatAppearance.BorderSize = 0;
            this.btn_huy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_huy.ForeColor = System.Drawing.Color.White;
            this.btn_huy.Location = new System.Drawing.Point(330, 350);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(130, 40);
            this.btn_huy.TabIndex = 10;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.UseVisualStyleBackColor = false;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // add_event_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.cb_khoa);
            this.Controls.Add(this.dtp_event_date);
            this.Controls.Add(this.txt_event_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_khoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "add_event_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm Sự Kiện";
            this.Load += new System.EventHandler(this.add_event_view_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_khoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_event_name;
        private System.Windows.Forms.DateTimePicker dtp_event_date;
        private System.Windows.Forms.ComboBox cb_khoa;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_huy;
    }
}