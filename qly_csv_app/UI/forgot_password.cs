using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace qly_csv_app.UI
{
    public partial class forgot_password : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        public forgot_password()
        {
            InitializeComponent();
        }

        //Quên mật khẩu
        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txb_email.Text.Trim();
                string mssv = txb_mssv.Text.Trim();
                string newPassword = txb_newPass.Text.Trim();
                string confirmPassword = txb_comfirmPass.Text.Trim();
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SqlConnection connection = new SqlConnection(connectString);
                connection.Open();
                string query = @"UPDATE u 
                                SET password = @newPassword 
                                FROM [User] u
                                INNER JOIN CuuSV c ON u.CSV_id = c.CSV_id
                                WHERE u.username = @Email AND c.MSSV = @mssv;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@mssv", mssv);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
