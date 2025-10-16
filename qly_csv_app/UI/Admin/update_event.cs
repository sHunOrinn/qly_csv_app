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
    public partial class update_event : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        private int eventId;
        private string originalEventName;
        private DateTime originalEventDate;
        private string originalDescription;
        private int originalParticipants;
        private int originalKhoaId; // Thêm để lưu khoa gốc

        public update_event()
        {
            InitializeComponent();
        }

        public update_event(int eventId, string eventName, DateTime eventDate, string description, int participants) : this()
        {
            this.eventId = eventId;
            this.originalEventName = eventName;
            this.originalEventDate = eventDate;
            this.originalDescription = description;
            this.originalParticipants = participants;

            LoadKhoa(); // Load danh sách khoa trước
            LoadEventData(); // Sau đó load dữ liệu sự kiện
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

        private void LoadEventData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    
                    // Lấy thông tin sự kiện bao gồm khoa_id
                    string query = @"SELECT event_name, event_date, description, so_luong_tham_gia, khoa_id 
                                    FROM Event WHERE event_id = @event_id";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@event_id", eventId);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txt_event_id.Text = eventId.ToString();
                        txt_event_name.Text = reader["event_name"]?.ToString() ?? originalEventName;
                        dtp_event_date.Value = reader["event_date"] != DBNull.Value ? 
                            Convert.ToDateTime(reader["event_date"]) : originalEventDate;
                        txt_description.Text = reader["description"]?.ToString() ?? originalDescription ?? string.Empty;
                        txt_participants.Text = reader["so_luong_tham_gia"]?.ToString() ?? originalParticipants.ToString();
                        
                        // Set khoa được chọn
                        if (reader["khoa_id"] != DBNull.Value)
                        {
                            originalKhoaId = Convert.ToInt32(reader["khoa_id"]);
                            cb_khoa.SelectedValue = originalKhoaId;
                        }
                        else
                        {
                            originalKhoaId = 0;
                            cb_khoa.SelectedIndex = 0; // Chọn "-- Chọn khoa tổ chức --"
                        }
                    }
                }

                // Set minimum date to today to prevent past dates
                dtp_event_date.MinDate = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sự kiện: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                UpdateEvent();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // Check if there are any changes
            if (HasChanges())
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có thay đổi chưa được lưu. Bạn có chắc chắn muốn hủy?",
                    "Xác nhận hủy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private bool ValidateInput()
        {
            // Validate event name
            if (string.IsNullOrWhiteSpace(txt_event_name.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sự kiện!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_event_name.Focus();
                return false;
            }

            // Validate event name length
            if (txt_event_name.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên sự kiện phải có ít nhất 3 ký tự!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_event_name.Focus();
                return false;
            }

            // Validate event date
            if (dtp_event_date.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày tổ chức không thể là ngày trong quá khứ!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_event_date.Focus();
                return false;
            }

            // Validate khoa selection
            if (cb_khoa.SelectedValue == null || Convert.ToInt32(cb_khoa.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn khoa tổ chức sự kiện!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_khoa.Focus();
                return false;
            }

            // Check if event name already exists (excluding current event)
            if (IsEventNameExists(txt_event_name.Text.Trim()))
            {
                MessageBox.Show("Tên sự kiện đã tồn tại! Vui lòng chọn tên khác.", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_event_name.Focus();
                return false;
            }

            return true;
        }

        private bool IsEventNameExists(string eventName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Event WHERE event_name = @event_name AND event_id != @event_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@event_name", eventName);
                    command.Parameters.AddWithValue("@event_id", eventId);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra tên sự kiện: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool HasChanges()
        {
            int selectedKhoaId = cb_khoa.SelectedValue != null ? Convert.ToInt32(cb_khoa.SelectedValue) : 0;
            
            return txt_event_name.Text.Trim() != originalEventName ||
                   dtp_event_date.Value.Date != originalEventDate.Date ||
                   txt_description.Text.Trim() != (originalDescription ?? string.Empty) ||
                   selectedKhoaId != originalKhoaId;
        }

        private void UpdateEvent()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = @"UPDATE Event 
                                    SET event_name = @event_name, 
                                        event_date = @event_date, 
                                        description = @description,
                                        khoa_id = @khoa_id
                                    WHERE event_id = @event_id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@event_name", txt_event_name.Text.Trim());
                    command.Parameters.AddWithValue("@event_date", dtp_event_date.Value.Date);
                    command.Parameters.AddWithValue("@description", 
                        string.IsNullOrWhiteSpace(txt_description.Text) ? (object)DBNull.Value : txt_description.Text.Trim());
                    command.Parameters.AddWithValue("@khoa_id", Convert.ToInt32(cb_khoa.SelectedValue));
                    command.Parameters.AddWithValue("@event_id", eventId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật sự kiện thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật sự kiện!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sự kiện: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Override ProcessCmdKey to handle Escape key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                btn_cancel_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
