using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using qly_csv_app.Repository;
using qly_csv_app.UI;
using qly_csv_app.UI.Admin;
using qly_csv_app.UI.User;

namespace qly_csv_app
{
    //coment
    public partial class Form1 : Form
    {
        public string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        private dangNhap loginRepository = new dangNhap();
        private forgot_password forgotPasswordForm;

        public Form1()
        {
            InitializeComponent();
            //this.Paint += Form1_Paint;
            //panel_main.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ gradient nền tím-xanh
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(102, 126, 234), // Màu xanh-tím nhạt
                Color.FromArgb(118, 75, 162), // Màu tím đậm
                135f)) // Góc 135 độ
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string username = txb_username.Text.Trim();
            string password = txb_password.Text.Trim();

            // Kiểm tra input rỗng
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đăng nhập
            string roleType = loginRepository.KiemTraDangNhap(username, password);
            
            if (!string.IsNullOrEmpty(roleType))
            {
                // Đăng nhập thành công
                this.Hide(); // Ẩn form đăng nhập
                
                if (roleType == "admin")
                {
                    // Mở cửa sổ admin
                    admin_view adminForm = new admin_view();
                    adminForm.FormClosed += (s, args) => this.Show(); // Hiện lại form đăng nhập khi đóng
                    adminForm.Show();
                }
                else if (roleType == "Cựu sinh viên")
                {
                    // Lấy thông tin user để truyền vào user_view
                    GetUserInfoAndOpenUserView(username);
                }
                else
                {
                    MessageBox.Show("Loại tài khoản không được hỗ trợ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }

                // Xóa thông tin đăng nhập
                txb_username.Clear();
                txb_password.Clear();
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_password.Clear(); // Xóa mật khẩu để người dùng nhập lại
                txb_username.Focus(); // Focus vào ô username
            }
        }

        private void GetUserInfoAndOpenUserView(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = @"SELECT u.user_id, c.Ten 
                                    FROM [User] u
                                    INNER JOIN CuuSV c ON u.CSV_id = c.CSV_id
                                    WHERE u.username = @username AND u.role_type = N'Cựu sinh viên'";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["user_id"]);
                        string userName = reader["Ten"]?.ToString();
                        
                        // Mở cửa sổ user với thông tin đầy đủ
                        user_view userForm = new user_view(userId, userName);
                        userForm.FormClosed += (s, args) => this.Show(); // Hiện lại form đăng nhập khi đóng
                        userForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin cựu sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin người dùng: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void linkLabel_forgot_password_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgotPasswordForm = new forgot_password();
            forgotPasswordForm.Show();

        }
        private void txb_username_Enter(object sender, EventArgs e)
        {
            if (txb_username.Text == "Tài khoản")
            {
                txb_username.Text = "";
                txb_username.ForeColor = Color.Black;
            }
        }

        private void txb_username_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_username.Text))
            {
                txb_username.Text = "Tài khoản";
                txb_username.ForeColor = Color.Gray;
            }
        }

        // Xử lý placeholder cho password
        private void txb_password_Enter(object sender, EventArgs e)
        {
            if (txb_password.Text == "Mật khẩu")
            {
                txb_password.Text = "";
                txb_password.ForeColor = Color.Black;
                txb_password.UseSystemPasswordChar = true;
            }
        }

        private void txb_password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_password.Text))
            {
                txb_password.Text = "Mật khẩu";
                txb_password.ForeColor = Color.Gray;
                txb_password.UseSystemPasswordChar = false;
            }
        }

        // Tạo viền bo tròn cho panel login
        private void panel_login_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int cornerRadius = 15;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, panel.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseAllFigures();

                panel.Region = new Region(path);
            }
        }

        // Tạo viền bo tròn cho panel input
        private void panel_input_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int cornerRadius = 8;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, panel.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseAllFigures();

                panel.Region = new Region(path);
            }
        }

        // Tạo viền bo tròn cho button
        private void btn_dangnhap_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            int cornerRadius = 8;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(btn.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(btn.Width - cornerRadius, btn.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, btn.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseAllFigures();

                btn.Region = new Region(path);
            }
        }

        // Hiệu ứng hover cho button
        private void btn_dangnhap_MouseEnter(object sender, EventArgs e)
        {
            btn_dangnhap.BackColor = Color.FromArgb(0, 100, 220);
        }

        private void btn_dangnhap_MouseLeave(object sender, EventArgs e)
        {
            btn_dangnhap.BackColor = Color.FromArgb(0, 123, 255);
        }
    }
}
