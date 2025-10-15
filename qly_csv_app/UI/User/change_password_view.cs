using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace qly_csv_app.UI.User
{
    public partial class change_password_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        private int currentUserId;
        private bool isAdmin = false; // Thêm flag để phân biệt admin

        public change_password_view()
        {
            InitializeComponent();
        }

        public change_password_view(int userId) : this()
        {
            currentUserId = userId;
        }

        private void change_password_view_Load(object sender, EventArgs e)
        {
            LoadCurrentUsername();
            CheckIfUserIsAdmin(); // Kiểm tra xem có phải admin không
            txt_current_password.Focus();
        }

        // Thêm method để kiểm tra user có phải admin không qua tài khoản
        private void CheckIfUserIsAdmin()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "SELECT role_type FROM [User] WHERE username = @username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", txt_username.Text.Trim());

                    object result = command.ExecuteScalar();
                    if (result != null && result.ToString() == "admin")
                    {
                        isAdmin = true;
                        // Cập nhật tiêu đề form cho admin
                        this.Text = "Đổi mật khẩu Admin";
                        label1.Text = "Đổi mật khẩu Admin";
                        label1.ForeColor = Color.FromArgb(220, 53, 69); // Màu đỏ cho admin
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra quyền người dùng: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCurrentUsername()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "SELECT username FROM [User] WHERE user_id = @user_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", currentUserId);
                    
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        txt_username.Text = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin tài khoản: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ChangePassword();
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra mật khẩu hiện tại
            if (string.IsNullOrWhiteSpace(txt_current_password.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_current_password.Focus();
                return false;
            }

            // Kiểm tra mật khẩu mới
            if (string.IsNullOrWhiteSpace(txt_new_password.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_new_password.Focus();
                return false;
            }

            // Kiểm tra độ dài mật khẩu mới (admin có yêu cầu cao hơn)
            int minLength = isAdmin ? 8 : 6;
            if (txt_new_password.Text.Length < minLength)
            {
                string userType = isAdmin ? "admin" : "người dùng";
                MessageBox.Show($"Mật khẩu {userType} phải có ít nhất {minLength} ký tự!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_new_password.Focus();
                return false;
            }

            // Kiểm tra xác nhận mật khẩu
            if (string.IsNullOrWhiteSpace(txt_confirm_password.Text))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu mới!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_confirm_password.Focus();
                return false;
            }

            // Kiểm tra mật khẩu mới và xác nhận có khớp
            if (txt_new_password.Text != txt_confirm_password.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_confirm_password.Focus();
                return false;
            }

            // Kiểm tra mật khẩu mới không giống mật khẩu cũ
            if (txt_current_password.Text == txt_new_password.Text)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_new_password.Focus();
                return false;
            }

            // Kiểm tra bổ sung cho admin
            if (isAdmin && !IsStrongPassword(txt_new_password.Text))
            {
                MessageBox.Show("Mật khẩu admin phải chứa ít nhất một chữ hoa, một chữ thường và một số!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_new_password.Focus();
                return false;
            }

            return true;
        }

        // Thêm method kiểm tra mật khẩu mạnh cho admin
        private bool IsStrongPassword(string password)
        {
            return password.Any(char.IsUpper) && 
                   password.Any(char.IsLower) && 
                   password.Any(char.IsDigit);
        }

        private void ChangePassword()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    // Kiểm tra mật khẩu hiện tại có đúng không
                    string checkQuery = "SELECT COUNT(*) FROM [User] WHERE user_id = @user_id AND password = @current_password";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@user_id", currentUserId);
                    checkCommand.Parameters.AddWithValue("@current_password", txt_current_password.Text);

                    int matchCount = (int)checkCommand.ExecuteScalar();
                    
                    if (matchCount == 0)
                    {
                        MessageBox.Show("Mật khẩu hiện tại không đúng!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_current_password.Focus();
                        return;
                    }

                    // Cập nhật mật khẩu mới
                    string updateQuery = "UPDATE [User] SET password = @new_password WHERE user_id = @user_id";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@new_password", txt_new_password.Text);
                    updateCommand.Parameters.AddWithValue("@user_id", currentUserId);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    
                    if (rowsAffected > 0)
                    {
                        string userType = isAdmin ? "admin" : "người dùng";
                        MessageBox.Show($"Đổi mật khẩu {userType} thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể đổi mật khẩu!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi hủy nếu đã nhập dữ liệu
            if (!string.IsNullOrWhiteSpace(txt_current_password.Text) || 
                !string.IsNullOrWhiteSpace(txt_new_password.Text) ||
                !string.IsNullOrWhiteSpace(txt_confirm_password.Text))
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy? Dữ liệu đã nhập sẽ bị mất!", 
                    "Xác nhận hủy", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txt_current_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txt_new_password.Focus();
                e.Handled = true;
            }
        }

        private void txt_new_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txt_confirm_password.Focus();
                e.Handled = true;
            }
        }

        private void txt_confirm_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_xacnhan_Click(sender, null);
                e.Handled = true;
            }
        }
    }
}
