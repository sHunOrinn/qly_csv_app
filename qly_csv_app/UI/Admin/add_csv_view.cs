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
    public partial class add_csv_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        
        public add_csv_view()
        {
            InitializeComponent();
        }

        private void add_csv_view_Load(object sender, EventArgs e)
        {
            LoadKhoaHoc();
            SetDefaultValues();
        }

        private void LoadKhoaHoc()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = @"SELECT k.khoa_hoc_id, 
                                           CONCAT(k.ten_khoa_hoc, ' - ', n.ten_nganh) AS display_text
                                    FROM KhoaHoc k
                                    INNER JOIN Nganh n ON k.nganh_id = n.nganh_id
                                    ORDER BY k.nam_bat_dau DESC";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cb_khoahoc.DisplayMember = "display_text";
                    cb_khoahoc.ValueMember = "khoa_hoc_id";
                    cb_khoahoc.DataSource = dt;
                    
                    if (dt.Rows.Count > 0)
                    {
                        cb_khoahoc.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khóa học: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultValues()
        {
            // Đặt ngày sinh mặc định (22 tuổi)
            dtp_ngaysinh.Value = DateTime.Now.AddYears(-22);
            dtp_ngaysinh.MaxDate = DateTime.Now.AddYears(-18); // Tối thiểu 18 tuổi
            dtp_ngaysinh.MinDate = DateTime.Now.AddYears(-65); // Tối đa 65 tuổi
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ThemCuuSinhVien();
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txt_hoten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_hoten.Focus();
                return false;
            }

            // Kiểm tra MSSV
            if (string.IsNullOrWhiteSpace(txt_mssv.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_mssv.Focus();
                return false;
            }

            // Kiểm tra định dạng email
            if (!string.IsNullOrWhiteSpace(txt_email.Text))
            {
                if (!IsValidEmail(txt_email.Text))
                {
                    MessageBox.Show("Email không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_email.Focus();
                    return false;
                }
            }

            // Kiểm tra số điện thoại
            if (!string.IsNullOrWhiteSpace(txt_sodienthoai.Text))
            {
                if (!IsValidPhoneNumber(txt_sodienthoai.Text))
                {
                    MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_sodienthoai.Focus();
                    return false;
                }
            }

            // Kiểm tra tuổi
            int age = DateTime.Now.Year - dtp_ngaysinh.Value.Year;
            if (dtp_ngaysinh.Value.Date > DateTime.Now.AddYears(-age)) age--;
            
            if (age < 22)
            {
                MessageBox.Show("Cựu sinh viên phải từ 22 tuổi trở lên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_ngaysinh.Focus();
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

        private bool IsValidPhoneNumber(string phone)
        {
            return phone.Length == 10 && phone.StartsWith("0") && phone.All(char.IsDigit);
        }

        private void ThemCuuSinhVien()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = @"INSERT INTO CuuSV (Ten, NgaySinh, MSSV, DC, email, phone, khoa_hoc_id) 
                                    VALUES (@Ten, @NgaySinh, @MSSV, @DC, @email, @phone, @khoa_hoc_id)";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ten", txt_hoten.Text.Trim());
                    command.Parameters.AddWithValue("@NgaySinh", dtp_ngaysinh.Value.Date);
                    command.Parameters.AddWithValue("@MSSV", txt_mssv.Text.Trim());
                    command.Parameters.AddWithValue("@DC", string.IsNullOrWhiteSpace(txt_diachi.Text) ? (object)DBNull.Value : txt_diachi.Text.Trim());
                    command.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txt_email.Text) ? (object)DBNull.Value : txt_email.Text.Trim());
                    command.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(txt_sodienthoai.Text) ? (object)DBNull.Value : txt_sodienthoai.Text.Trim());
                    command.Parameters.AddWithValue("@khoa_hoc_id", cb_khoahoc.SelectedValue);

                    int result = command.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm cựu sinh viên thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Reset form
                        ClearForm();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm cựu sinh viên!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint violation
                {
                    MessageBox.Show("MSSV hoặc Email đã tồn tại trong hệ thống!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm cựu sinh viên: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txt_hoten.Clear();
            txt_mssv.Clear();
            txt_diachi.Clear();
            txt_email.Clear();
            txt_sodienthoai.Clear();
            dtp_ngaysinh.Value = DateTime.Now.AddYears(-22);
            if (cb_khoahoc.Items.Count > 0)
                cb_khoahoc.SelectedIndex = 0;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
