namespace qly_csv_app.UI.User
{
    partial class donggop_view
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_tien = new System.Windows.Forms.RadioButton();
            this.rb_khac = new System.Windows.Forms.RadioButton();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.txt_details = new System.Windows.Forms.TextBox();
            this.btn_xacnhan = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_khongdonggop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.lbl_title.Location = new System.Drawing.Point(180, 15);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(140, 37);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Đóng góp";
            // 
            // lbl_event_info
            // 
            this.lbl_event_info.AutoSize = true;
            this.lbl_event_info.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_event_info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lbl_event_info.Location = new System.Drawing.Point(30, 80);
            this.lbl_event_info.Name = "lbl_event_info";
            this.lbl_event_info.Size = new System.Drawing.Size(111, 28);
            this.lbl_event_info.TabIndex = 1;
            this.lbl_event_info.Text = "Sự kiện: ...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(50, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loại đóng góp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(50, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số tiền *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(50, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chi tiết/Ghi chú";
            // 
            // rb_tien
            // 
            this.rb_tien.AutoSize = true;
            this.rb_tien.Checked = true;
            this.rb_tien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_tien.Location = new System.Drawing.Point(20, 25);
            this.rb_tien.Name = "rb_tien";
            this.rb_tien.Size = new System.Drawing.Size(62, 27);
            this.rb_tien.TabIndex = 5;
            this.rb_tien.TabStop = true;
            this.rb_tien.Text = "Tiền";
            this.rb_tien.UseVisualStyleBackColor = true;
            this.rb_tien.CheckedChanged += new System.EventHandler(this.rb_tien_CheckedChanged);
            // 
            // rb_khac
            // 
            this.rb_khac.AutoSize = true;
            this.rb_khac.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_khac.Location = new System.Drawing.Point(120, 25);
            this.rb_khac.Name = "rb_khac";
            this.rb_khac.Size = new System.Drawing.Size(65, 27);
            this.rb_khac.TabIndex = 6;
            this.rb_khac.Text = "Khác";
            this.rb_khac.UseVisualStyleBackColor = true;
            this.rb_khac.CheckedChanged += new System.EventHandler(this.rb_khac_CheckedChanged);
            // 
            // txt_amount
            // 
            this.txt_amount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_amount.Location = new System.Drawing.Point(200, 217);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(250, 30);
            this.txt_amount.TabIndex = 7;
            this.txt_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_amount_KeyPress);
            // 
            // txt_details
            // 
            this.txt_details.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_details.Location = new System.Drawing.Point(200, 267);
            this.txt_details.Multiline = true;
            this.txt_details.Name = "txt_details";
            this.txt_details.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_details.Size = new System.Drawing.Size(250, 60);
            this.txt_details.TabIndex = 8;
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_xacnhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_xacnhan.FlatAppearance.BorderSize = 0;
            this.btn_xacnhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xacnhan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xacnhan.ForeColor = System.Drawing.Color.White;
            this.btn_xacnhan.Location = new System.Drawing.Point(50, 350);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(120, 40);
            this.btn_xacnhan.TabIndex = 9;
            this.btn_xacnhan.Text = "Xác nhận đóng góp";
            this.btn_xacnhan.UseVisualStyleBackColor = false;
            this.btn_xacnhan.Click += new System.EventHandler(this.btn_xacnhan_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_huy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_huy.FlatAppearance.BorderSize = 0;
            this.btn_huy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_huy.ForeColor = System.Drawing.Color.White;
            this.btn_huy.Location = new System.Drawing.Point(330, 350);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(120, 40);
            this.btn_huy.TabIndex = 10;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.UseVisualStyleBackColor = false;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_khongdonggop
            // 
            this.btn_khongdonggop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btn_khongdonggop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_khongdonggop.FlatAppearance.BorderSize = 0;
            this.btn_khongdonggop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_khongdonggop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_khongdonggop.ForeColor = System.Drawing.Color.White;
            this.btn_khongdonggop.Location = new System.Drawing.Point(190, 350);
            this.btn_khongdonggop.Name = "btn_khongdonggop";
            this.btn_khongdonggop.Size = new System.Drawing.Size(120, 40);
            this.btn_khongdonggop.TabIndex = 11;
            this.btn_khongdonggop.Text = "Không đóng góp";
            this.btn_khongdonggop.UseVisualStyleBackColor = false;
            this.btn_khongdonggop.Click += new System.EventHandler(this.btn_khongdonggop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_tien);
            this.groupBox1.Controls.Add(this.rb_khac);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(200, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 65);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // donggop_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_khongdonggop);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_xacnhan);
            this.Controls.Add(this.txt_details);
            this.Controls.Add(this.txt_amount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_event_info);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "donggop_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đóng góp cho sự kiện";
            this.Load += new System.EventHandler(this.donggop_view_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_event_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rb_tien;
        private System.Windows.Forms.RadioButton rb_khac;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.TextBox txt_details;
        private System.Windows.Forms.Button btn_xacnhan;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Button btn_khongdonggop;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}