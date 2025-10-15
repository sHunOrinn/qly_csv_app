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
    public partial class event_invited_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        private int csvId;
        private string tenCuuSV;

        public event_invited_view(int csvId, string tenCuuSV)
        {
            InitializeComponent();
            this.csvId = csvId;
            this.tenCuuSV = tenCuuSV;
            
            // Hiển thị thông tin cựu sinh viên
            lbl_cuusv_info.Text = $"Cựu sinh viên: {tenCuuSV} (ID: {csvId})";
        }

        private void event_invited_view_Load(object sender, EventArgs e)
        {
            LoadInvitedEvents();
        }

        private void LoadInvitedEvents()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    
                    // Lấy danh sách các sự kiện đã được mời
                    string query = @"
                        SELECT 
                            e.event_id,
                            e.event_name,
                            e.event_date,
                            p.participation_date,
                            p.status,
                            e.description
                        FROM Event e
                        INNER JOIN Participation p ON e.event_id = p.event_id
                        WHERE p.CSV_id = @CSV_id
                        ORDER BY p.participation_date DESC, e.event_date DESC";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CSV_id", csvId);
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    
                    dataGridView_invitations.DataSource = dataTable;
                    
                    // Cập nhật thông tin thống kê
                    UpdateStatistics(dataTable);
                    
                    // Tùy chỉnh hiển thị theo trạng thái
                    CustomizeRowDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lời mời: " + ex.Message, 
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
                label1.Text = "Cựu sinh viên này chưa được mời tham gia sự kiện nào.";
                label1.ForeColor = Color.Gray;
            }
        }

        private void CustomizeRowDisplay()
        {
            // Tùy chỉnh màu sắc theo trạng thái
            foreach (DataGridViewRow row in dataGridView_invitations.Rows)
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

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
