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
    public partial class add_event_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;

        public add_event_view()
        {
            InitializeComponent();
        }

        private void add_event_view_Load(object sender, EventArgs e)
        {
            LoadKhoa(); // Load danh sách khoa trước
            SetDefaultValues();
        }

        private void LoadKhoa()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "SELECT khoa_id, ten_khoa FROM Khoa ORDER BY ten_khoa";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Thêm dòng "Chọn khoa" ở đầu
                    DataRow emptyRow = dt.NewRow();
                    emptyRow["khoa_id"] = 0;
                    emptyRow["ten_khoa"] = "-- Chọn khoa tổ chức --";
                    dt.Rows.InsertAt(emptyRow, 0);

                    cb_khoa.DisplayMember = "ten_khoa";
                    cb_khoa.ValueMember = "khoa_id";
                    cb_khoa.DataSource = dt;
                    cb_khoa.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khoa: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultValues()
        {
            // Đặt ngày mặc định là ngày hiện tại
            dtp_event_date.Value = DateTime.Now;
            dtp_event_date.MinDate = DateTime.Now; // Không cho phép chọn ngày trong quá khứ
            
            // Focus vào textbox tên sự kiện
            txt_event_name.Focus();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ThemSuKien();
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra tên sự kiện
            if (string.IsNullOrWhiteSpace(txt_event_name.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sự kiện!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_event_name.Focus();
                return false;
            }

            // Kiểm tra độ dài tên sự kiện
            if (txt_event_name.Text.Trim().Length > 255)
            {
                MessageBox.Show("Tên sự kiện không được vượt quá 255 ký tự!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_event_name.Focus();
                return false;
            }

            // Kiểm tra ngày sự kiện
            if (dtp_event_date.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sự kiện không được là ngày trong quá khứ!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_event_date.Focus();
                return false;
            }

            // Kiểm tra khoa được chọn
            if (cb_khoa.SelectedValue == null || Convert.ToInt32(cb_khoa.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn khoa tổ chức sự kiện!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_khoa.Focus();
                return false;
            }

            // Kiểm tra mô tả (tùy chọn nhưng nếu có thì kiểm tra độ dài)
            if (!string.IsNullOrEmpty(txt_description.Text) && txt_description.Text.Length > 1000)
            {
                MessageBox.Show("Mô tả không được vượt quá 1000 ký tự!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_description.Focus();
                return false;
            }

            return true;
        }

        private void ThemSuKien()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    // Kiểm tra xem đã có sự kiện trùng tên và ngày chưa
                    string checkQuery = @"SELECT COUNT(*) FROM Event 
                                         WHERE event_name = @event_name AND event_date = @event_date";
                    
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@event_name", txt_event_name.Text.Trim());
                    checkCommand.Parameters.AddWithValue("@event_date", dtp_event_date.Value.Date);

                    int existingCount = (int)checkCommand.ExecuteScalar();
                    
                    if (existingCount > 0)
                    {
                        MessageBox.Show("Đã có sự kiện với tên và ngày này! Vui lòng chọn tên hoặc ngày khác.", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thêm sự kiện mới (bao gồm khoa_id)
                    string insertQuery = @"INSERT INTO Event (event_name, event_date, description, so_luong_tham_gia, khoa_id) 
                                          VALUES (@event_name, @event_date, @description, @so_luong_tham_gia, @khoa_id)";
                    
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@event_name", txt_event_name.Text.Trim());
                    insertCommand.Parameters.AddWithValue("@event_date", dtp_event_date.Value.Date);
                    insertCommand.Parameters.AddWithValue("@description", 
                        string.IsNullOrWhiteSpace(txt_description.Text) ? (object)DBNull.Value : txt_description.Text.Trim());
                    insertCommand.Parameters.AddWithValue("@so_luong_tham_gia", 0); // Ban đầu là 0
                    insertCommand.Parameters.AddWithValue("@khoa_id", Convert.ToInt32(cb_khoa.SelectedValue));

                    int result = insertCommand.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm sự kiện thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Reset form hoặc đóng form
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm sự kiện!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sự kiện: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi hủy nếu đã nhập dữ liệu
            if (!string.IsNullOrWhiteSpace(txt_event_name.Text) || 
                !string.IsNullOrWhiteSpace(txt_description.Text) ||
                (cb_khoa.SelectedValue != null && Convert.ToInt32(cb_khoa.SelectedValue) != 0))
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
