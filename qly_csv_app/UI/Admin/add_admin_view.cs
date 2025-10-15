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

namespace qly_csv_app.UI.Admin
{
    public partial class add_admin_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;

        public add_admin_view()
        {
            InitializeComponent();
        }

        private void add_admin_view_Load(object sender, EventArgs e)
        {
            // Focus vào textbox username
            txt_username.Focus();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ThemAdmin();
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra tên tài khoản
            if (string.IsNullOrWhiteSpace(txt_username.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_username.Focus();
                return false;
            }

            // Kiểm tra độ dài username
            if (txt_username.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên tài khoản phải có ít nhất 3 ký tự!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_username.Focus();
                return false;
            }

            // Kiểm tra định dạng email cho username
            if (!IsValidEmail(txt_username.Text.Trim()))
            {
                MessageBox.Show("Tên tài khoản phải là địa chỉ email hợp lệ!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_username.Focus();
                return false;
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_password.Focus();
                return false;
            }

            // Kiểm tra độ dài mật khẩu
            if (txt_password.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_password.Focus();
                return false;
            }

            // Kiểm tra xác nhận mật khẩu
            if (string.IsNullOrWhiteSpace(txt_confirm_password.Text))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_confirm_password.Focus();
                return false;
            }

            // Kiểm tra mật khẩu khớp
            if (txt_password.Text != txt_confirm_password.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_confirm_password.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ThemAdmin()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    // Kiểm tra xem username đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM [User] WHERE username = @username";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@username", txt_username.Text.Trim());

                    int existingCount = (int)checkCommand.ExecuteScalar();
                    
                    if (existingCount > 0)
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại! Vui lòng chọn tên khác.", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_username.Focus();
                        return;
                    }

                    // Thêm admin mới
                    string insertQuery = @"INSERT INTO [User] (username, password, role_type, is_active, CSV_id) 
                                          VALUES (@username, @password, @role_type, @is_active, @CSV_id)";
                    
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@username", txt_username.Text.Trim());
                    insertCommand.Parameters.AddWithValue("@password", txt_password.Text); // Trong thực tế nên hash mật khẩu
                    insertCommand.Parameters.AddWithValue("@role_type", "admin");
                    insertCommand.Parameters.AddWithValue("@is_active", true);
                    insertCommand.Parameters.AddWithValue("@CSV_id", DBNull.Value); // Admin không liên kết với cựu sinh viên

                    int result = insertCommand.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm tài khoản admin thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Reset form hoặc đóng form
                        ClearForm();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm tài khoản admin!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản admin: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txt_username.Clear();
            txt_password.Clear();
            txt_confirm_password.Clear();
            txt_username.Focus();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi hủy nếu đã nhập dữ liệu
            if (!string.IsNullOrWhiteSpace(txt_username.Text) || 
                !string.IsNullOrWhiteSpace(txt_password.Text) ||
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
    }
}
