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

            LoadEventData();
        }

        private void LoadEventData()
        {
            try
            {
                txt_event_id.Text = eventId.ToString();
                txt_event_name.Text = originalEventName;
                dtp_event_date.Value = originalEventDate;
                txt_description.Text = originalDescription ?? string.Empty;
                txt_participants.Text = originalParticipants.ToString();

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
            return txt_event_name.Text.Trim() != originalEventName ||
                   dtp_event_date.Value.Date != originalEventDate.Date ||
                   txt_description.Text.Trim() != (originalDescription ?? string.Empty);
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
                                        description = @description
                                    WHERE event_id = @event_id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@event_name", txt_event_name.Text.Trim());
                    command.Parameters.AddWithValue("@event_date", dtp_event_date.Value.Date);
                    command.Parameters.AddWithValue("@description", 
                        string.IsNullOrWhiteSpace(txt_description.Text) ? (object)DBNull.Value : txt_description.Text.Trim());
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
