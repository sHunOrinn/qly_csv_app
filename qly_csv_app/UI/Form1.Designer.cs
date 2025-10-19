using System.Drawing;
using System.Windows.Forms;

namespace qly_csv_app
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_login = new System.Windows.Forms.Panel();
            this.lb_title = new System.Windows.Forms.Label();
            this.lb_subtitle = new System.Windows.Forms.Label();
            this.panel_username = new System.Windows.Forms.Panel();
            this.txb_username = new System.Windows.Forms.TextBox();
            this.panel_password = new System.Windows.Forms.Panel();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.linkLabel_forgot_password = new System.Windows.Forms.LinkLabel();
            this.panel_main.SuspendLayout();
            this.panel_login.SuspendLayout();
            this.panel_username.SuspendLayout();
            this.panel_password.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.panel_main.Controls.Add(this.panel_login);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Padding = new System.Windows.Forms.Padding(100);
            this.panel_main.Size = new System.Drawing.Size(900, 600);
            this.panel_main.TabIndex = 0;
            this.panel_main.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            // 
            // panel_login
            // 
            this.panel_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_login.BackColor = System.Drawing.Color.White;
            this.panel_login.Controls.Add(this.lb_title);
            this.panel_login.Controls.Add(this.lb_subtitle);
            this.panel_login.Controls.Add(this.panel_username);
            this.panel_login.Controls.Add(this.panel_password);
            this.panel_login.Controls.Add(this.btn_dangnhap);
            this.panel_login.Controls.Add(this.linkLabel_forgot_password);
            this.panel_login.Location = new System.Drawing.Point(200, 100);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(500, 400);
            this.panel_login.TabIndex = 0;
            this.panel_login.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_login_Paint);
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_title.Location = new System.Drawing.Point(62, 50);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(378, 54);
            this.lb_title.TabIndex = 0;
            this.lb_title.Text = "Chào mừng trở lại!";
            this.lb_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_subtitle
            // 
            this.lb_subtitle.AutoSize = true;
            this.lb_subtitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_subtitle.ForeColor = System.Drawing.Color.Gray;
            this.lb_subtitle.Location = new System.Drawing.Point(148, 110);
            this.lb_subtitle.Name = "lb_subtitle";
            this.lb_subtitle.Size = new System.Drawing.Size(199, 25);
            this.lb_subtitle.TabIndex = 1;
            this.lb_subtitle.Text = "Đăng nhập để tiếp tục";
            this.lb_subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_username
            // 
            this.panel_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panel_username.Controls.Add(this.txb_username);
            this.panel_username.Location = new System.Drawing.Point(60, 160);
            this.panel_username.Name = "panel_username";
            this.panel_username.Size = new System.Drawing.Size(380, 50);
            this.panel_username.TabIndex = 2;
            this.panel_username.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_input_Paint);
            // 
            // txb_username
            // 
            this.txb_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txb_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txb_username.Location = new System.Drawing.Point(9, 12);
            this.txb_username.Name = "txb_username";
            this.txb_username.Size = new System.Drawing.Size(315, 27);
            this.txb_username.TabIndex = 0;
            this.txb_username.Text = "Tài khoản";
            this.txb_username.Enter += new System.EventHandler(this.txb_username_Enter);
            this.txb_username.Leave += new System.EventHandler(this.txb_username_Leave);
            // 
            // panel_password
            // 
            this.panel_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panel_password.Controls.Add(this.txb_password);
            this.panel_password.Location = new System.Drawing.Point(60, 230);
            this.panel_password.Name = "panel_password";
            this.panel_password.Size = new System.Drawing.Size(380, 50);
            this.panel_password.TabIndex = 3;
            this.panel_password.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_input_Paint);
            // 
            // txb_password
            // 
            this.txb_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txb_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txb_password.Location = new System.Drawing.Point(8, 12);
            this.txb_password.Name = "txb_password";
            this.txb_password.Size = new System.Drawing.Size(315, 27);
            this.txb_password.TabIndex = 1;
            this.txb_password.Text = "Mật khẩu";
            this.txb_password.Enter += new System.EventHandler(this.txb_password_Enter);
            this.txb_password.Leave += new System.EventHandler(this.txb_password_Leave);
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btn_dangnhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dangnhap.FlatAppearance.BorderSize = 0;
            this.btn_dangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dangnhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dangnhap.ForeColor = System.Drawing.Color.White;
            this.btn_dangnhap.Location = new System.Drawing.Point(60, 300);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(380, 45);
            this.btn_dangnhap.TabIndex = 2;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.UseVisualStyleBackColor = false;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            this.btn_dangnhap.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_dangnhap_Paint);
            this.btn_dangnhap.MouseEnter += new System.EventHandler(this.btn_dangnhap_MouseEnter);
            this.btn_dangnhap.MouseLeave += new System.EventHandler(this.btn_dangnhap_MouseLeave);
            // 
            // linkLabel_forgot_password
            // 
            this.linkLabel_forgot_password.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.linkLabel_forgot_password.AutoSize = true;
            this.linkLabel_forgot_password.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_forgot_password.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel_forgot_password.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.linkLabel_forgot_password.Location = new System.Drawing.Point(66, 357);
            this.linkLabel_forgot_password.Name = "linkLabel_forgot_password";
            this.linkLabel_forgot_password.Size = new System.Drawing.Size(129, 23);
            this.linkLabel_forgot_password.TabIndex = 3;
            this.linkLabel_forgot_password.TabStop = true;
            this.linkLabel_forgot_password.Text = "Quên mật khẩu";
            this.linkLabel_forgot_password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel_forgot_password.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.linkLabel_forgot_password.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_forgot_password_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panel_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Hệ thống quản lý CSV";
            this.panel_main.ResumeLayout(false);
            this.panel_login.ResumeLayout(false);
            this.panel_login.PerformLayout();
            this.panel_username.ResumeLayout(false);
            this.panel_username.PerformLayout();
            this.panel_password.ResumeLayout(false);
            this.panel_password.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_main;
        private Panel panel_login;
        private Label lb_title;
        private Label lb_subtitle;
        private Panel panel_username;
        private TextBox txb_username;
        private Panel panel_password;
        private TextBox txb_password;
        private Button btn_dangnhap;
        private LinkLabel linkLabel_forgot_password;
    }
}

