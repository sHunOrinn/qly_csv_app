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
using qly_csv_app.UI;

namespace qly_csv_app.UI.Admin
{
    public partial class csv_invited_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        private int eventId;
        private string eventName;

        public csv_invited_view(int eventId, string eventName, DateTime eventDate)
        {
            InitializeComponent();
            this.eventId = eventId;
            this.eventName = eventName;
            
            // Hiển thị thông tin sự kiện
            lbl_event_info.Text = $"Sự kiện: {eventName} (ID: {eventId})";
            this.Text = $"Danh sách được mời - {eventName}";
        }

        private void csv_invited_view_Load(object sender, EventArgs e)
        {
            LoadInvitedAlumni();
        }

        private void LoadInvitedAlumni()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    
                    // Lấy danh sách cựu sinh viên đã được mời tham gia sự kiện này
                    string query = @"
                        SELECT 
                            c.CSV_id,
                            c.Ten,
                            c.MSSV,
                            c.email,
                            c.phone,
                            p.participation_date,
                            p.status
                        FROM CuuSV c
                        INNER JOIN Participation p ON c.CSV_id = p.CSV_id
                        WHERE p.event_id = @event_id
                        ORDER BY p.participation_date DESC, c.Ten";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@event_id", eventId);
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    
                    dataGridView_csv.DataSource = dataTable;
                    
                    // Cập nhật thông tin thống kê
                    UpdateStatistics(dataTable);
                    
                    // Tùy chỉnh hiển thị theo trạng thái
                    CustomizeRowDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách cựu sinh viên: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics(DataTable dataTable)
        {
            int totalInvitations = dataTable.Rows.Count;
            int acceptedCount = 0;
            int pendingCount = 0;
            int rejectedCount = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                string status = row["status"]?.ToString();
                switch (status)
                {
                    case "Chấp nhận":
                        acceptedCount++;
                        break;
                    case "Được mời":
                        pendingCount++;
                        break;
                    case "Từ chối":
                        rejectedCount++;
                        break;
                }
            }

            lbl_thongke.Text = $"Tổng: {totalInvitations} | Chấp nhận: {acceptedCount} | Chờ phản hồi: {pendingCount} | Từ chối: {rejectedCount}";
            
            if (totalInvitations == 0)
            {
                label1.Text = "Chưa có cựu sinh viên nào được mời tham gia sự kiện này.";
                label1.ForeColor = Color.Gray;
            }
        }

        private void CustomizeRowDisplay()
        {
            // Tùy chỉnh màu sắc theo trạng thái
            foreach (DataGridViewRow row in dataGridView_csv.Rows)
            {
                if (row.Cells["status"].Value != null)
                {
                    string status = row.Cells["status"].Value.ToString();
                    switch (status)
                    {
                        case "Chấp nhận":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                            break;
                        case "Từ chối":
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                            break;
                        case "Được mời":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                            break;
                    }
                }
            }
        }

        //Sự kiện double click vào 1 dòng trong datagridview
        private void dataGridView_csv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView_csv.Rows.Count)
                {
                    DataGridViewRow selectedRow = dataGridView_csv.Rows[e.RowIndex];
                    
                    // Check if required cells have values - Use designer column names
                    if (selectedRow.Cells["csv_id"].Value == null || selectedRow.Cells["ten_csv"].Value == null)
                    {
                        MessageBox.Show("Không thể xác định thông tin cựu sinh viên!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    int csvId = Convert.ToInt32(selectedRow.Cells["csv_id"].Value);
                    string csvName = selectedRow.Cells["ten_csv"].Value.ToString();

                    // Hiển thị đóng góp cụ thể cho sự kiện này
                    ShowContributionsForThisEvent(csvId, csvName, eventId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý thông tin sự kiện: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowContributionsForThisEvent(int csvId, string csvName, int eventId)
        {
            contribute_view.ShowUserContributionsForEvent(csvId, csvName, eventId, eventName);
            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(connectString))
            //    {
            //        connection.Open();

            //        // Tìm đóng góp liên quan đến sự kiện này
            //        string query = @"
            //            SELECT c.contribution_id, c.contribution_type, c.amount, 
            //                   c.contribution_date, c.details, csv.Ten as contributor_name,
            //                   p.participation_date, p.status as participation_status,
            //                p.event_id
            //            FROM Contribution c
            //            JOIN CuuSV csv ON c.CSV_id = csv.CSV_id
            //            JOIN Participation p ON c.CSV_id = p.CSV_id AND p.event_id = @event_id
            //            WHERE c.CSV_id = @csv_id
            //            ORDER BY c.contribution_date DESC";

            //        SqlCommand command = new SqlCommand(query, connection);
            //        command.Parameters.AddWithValue("@csv_id", csvId);
            //        command.Parameters.AddWithValue("@event_id", eventId);

            //        SqlDataAdapter adapter = new SqlDataAdapter(command);
            //        DataTable contributionTable = new DataTable();
            //        adapter.Fill(contributionTable);

            //        if (contributionTable.Rows.Count > 0)
            //        {
            //            // Có đóng góp, hiển thị form contribute_view với dữ liệu cụ thể
            //            ShowCustomContributionView(csvId, csvName, contributionTable);
            //        }
            //        else
            //        {
            //            MessageBox.Show($"{csvName} chưa có đóng góp nào cho sự kiện '{eventName}'.", 
            //                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi tải thông tin đóng góp: " + ex.Message, "Lỗi", 
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void ShowCustomContributionView(int csvId, string csvName, DataTable contributionData)
        {
            // Tạo form contribute_view tùy chỉnh
            contribute_view contributionForm = new contribute_view();
            
            // Thiết lập thông tin cho form
            contributionForm.Text = $"Đóng góp cho sự kiện: {eventName}";
            
            // Sử dụng reflection để thiết lập dữ liệu 
            typeof(contribute_view).GetField("csvId", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(contributionForm, csvId);
            typeof(contribute_view).GetField("userName", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(contributionForm, csvName);
            typeof(contribute_view).GetField("eventId", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(contributionForm, eventId);
            typeof(contribute_view).GetField("eventName", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(contributionForm, eventName);
            
            // Hoặc đơn giản hơn, gọi method đã có sẵn
            contribute_view.ShowUserContributionsForEvent(csvId, csvName, eventId, eventName);
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
