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
using Microsoft.Extensions.Logging;

namespace qly_csv_app.UI.User
{
    public partial class donggop_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        private int csvId;
        private string eventName;
        private int participationId;
        private int eventId;

        public donggop_view()
        {
            InitializeComponent();
        }

        public donggop_view(int csvId, string eventName, int participationId) : this()
        {
            this.csvId = csvId;
            this.eventName = eventName;
            this.participationId = participationId;
        }

        public donggop_view(int csvId, string eventName, int participationId, int eventId) : this(csvId, eventName, participationId)
        {
            this.csvId = csvId;
            this.eventName = eventName;
            this.participationId = participationId;
            this.eventId = eventId;
        }

        private void donggop_view_Load(object sender, EventArgs e)
        {
            lbl_event_info.Text = $"Sự kiện: {eventName}";
            
            // Set default values
            rb_tien.Checked = true;
            txt_amount.Text = "0";
            txt_details.Text = "";
            
            // Update label visibility based on contribution type
            UpdateAmountLabelVisibility();
        }

        private void rb_tien_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAmountLabelVisibility();
        }

        private void rb_khac_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAmountLabelVisibility();
        }

        private void UpdateAmountLabelVisibility()
        {
            if (rb_tien.Checked)
            {
                label2.Text = "Số tiền *";
                label2.Visible = true;
                txt_amount.Visible = true;
                txt_amount.Enabled = true;
            }
            else
            {
                label2.Text = "Giá trị ước tính";
                label2.Visible = true;
                txt_amount.Visible = true;
                txt_amount.Enabled = true;
                txt_amount.Text = "0";
            }
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và dấu thập phân
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Chỉ cho phép một dấu thập phân
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SaveContribution();
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra số tiền
            if (string.IsNullOrWhiteSpace(txt_amount.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền/giá trị đóng góp!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_amount.Focus();
                return false;
            }

            if (!decimal.TryParse(txt_amount.Text, out decimal amount) || amount < 0)
            {
                MessageBox.Show("Số tiền/giá trị phải là số hợp lệ và >= 0!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_amount.Focus();
                return false;
            }

            // Nếu là đóng góp tiền, số tiền phải > 0
            if (rb_tien.Checked && amount <= 0)
            {
                MessageBox.Show("Số tiền đóng góp phải lớn hơn 0!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_amount.Focus();
                return false;
            }

            // Kiểm tra chi tiết đóng góp (đặc biệt quan trọng với đóng góp "khác")
            if (rb_khac.Checked && string.IsNullOrWhiteSpace(txt_details.Text))
            {
                MessageBox.Show("Vui lòng mô tả chi tiết về đóng góp của bạn!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_details.Focus();
                return false;
            }

            return true;
        }

        private void SaveContribution()
        {
            try
            {
                string contributionType = rb_tien.Checked ? "Tiền" : "khác";
                decimal amount = decimal.Parse(txt_amount.Text);
                string details = txt_details.Text.Trim();

                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Contribution (CSV_id, contribution_type, amount, contribution_date, details, event_id) 
                                    VALUES (@CSV_id, @contribution_type, @amount, @contribution_date, @details, @event_id)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CSV_id", csvId);
                    command.Parameters.AddWithValue("@contribution_type", contributionType);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@contribution_date", DateTime.Now);
                    command.Parameters.AddWithValue("@details", string.IsNullOrEmpty(details) ? (object)DBNull.Value : details);
                    command.Parameters.AddWithValue("@event_id", eventId);

                    int result = command.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        string message = rb_tien.Checked 
                            ? $"Cảm ơn bạn đã đóng góp {amount:N0} VND cho sự kiện '{eventName}'!"
                            : $"Cảm ơn bạn đã đóng góp {details} cho sự kiện '{eventName}'!";

                        MessageBox.Show(message, "Đóng góp thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể lưu thông tin đóng góp!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đóng góp: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_khongdonggop_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn không muốn đóng góp cho sự kiện này?", 
                "Xác nhận", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn hủy việc chấp nhận tham gia sự kiện này?", 
                "Xác nhận hủy", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Rollback participation status to "Được mời"
                RollbackParticipation();
            }
        }

        private void RollbackParticipation()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "UPDATE Participation SET status = N'Được mời' WHERE participation_id = @participation_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@participation_id", participationId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đã hủy việc chấp nhận tham gia sự kiện!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy tham gia: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
