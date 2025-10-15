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
            this.txb_username = new System.Windows.Forms.TextBox();
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_matkhau = new System.Windows.Forms.Label();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.linkLabel_forgot_password = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txb_username
            // 
            this.txb_username.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_username.Location = new System.Drawing.Point(338, 118);
            this.txb_username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txb_username.Name = "txb_username";
            this.txb_username.Size = new System.Drawing.Size(213, 30);
            this.txb_username.TabIndex = 0;
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.BackColor = System.Drawing.Color.Transparent;
            this.lb_username.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(245, 121);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(86, 23);
            this.lb_username.TabIndex = 1;
            this.lb_username.Text = "Tài khoản:";
            // 
            // lb_matkhau
            // 
            this.lb_matkhau.AutoSize = true;
            this.lb_matkhau.BackColor = System.Drawing.Color.Transparent;
            this.lb_matkhau.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_matkhau.Location = new System.Drawing.Point(245, 166);
            this.lb_matkhau.Name = "lb_matkhau";
            this.lb_matkhau.Size = new System.Drawing.Size(86, 23);
            this.lb_matkhau.TabIndex = 1;
            this.lb_matkhau.Text = "Mật khẩu:";
            // 
            // txb_password
            // 
            this.txb_password.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_password.Location = new System.Drawing.Point(338, 160);
            this.txb_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txb_password.Name = "txb_password";
            this.txb_password.PasswordChar = '*';
            this.txb_password.Size = new System.Drawing.Size(213, 30);
            this.txb_password.TabIndex = 1;
            this.txb_password.UseSystemPasswordChar = true;
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dangnhap.Location = new System.Drawing.Point(338, 234);
            this.btn_dangnhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(125, 36);
            this.btn_dangnhap.TabIndex = 2;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.UseVisualStyleBackColor = true;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // linkLabel_forgot_password
            // 
            this.linkLabel_forgot_password.AutoSize = true;
            this.linkLabel_forgot_password.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_forgot_password.LinkColor = System.Drawing.Color.Black;
            this.linkLabel_forgot_password.Location = new System.Drawing.Point(341, 204);
            this.linkLabel_forgot_password.Name = "linkLabel_forgot_password";
            this.linkLabel_forgot_password.Size = new System.Drawing.Size(96, 17);
            this.linkLabel_forgot_password.TabIndex = 3;
            this.linkLabel_forgot_password.TabStop = true;
            this.linkLabel_forgot_password.Text = "Quên mật khẩu";
            this.linkLabel_forgot_password.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_forgot_password_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.Controls.Add(this.linkLabel_forgot_password);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.lb_matkhau);
            this.Controls.Add(this.lb_username);
            this.Controls.Add(this.txb_password);
            this.Controls.Add(this.txb_username);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Hệ thống quản lý CSV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txb_username;
        private Label lb_username;
        private Label lb_matkhau;
        private TextBox txb_password;
        private Button btn_dangnhap;
        private LinkLabel linkLabel_forgot_password;
    }
}

