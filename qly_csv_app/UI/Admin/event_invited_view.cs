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
        private DataTable originalInvitationDataTable; // Thêm để lưu dữ liệu gốc

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
            LoadKhoa();
            LoadInvitedEvents();
        }

        // Thêm method để load danh sách khoa
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

                    // Thêm dòng "Tất cả khoa" ở đầu
                    DataRow allRow = dt.NewRow();
                    allRow["khoa_id"] = 0;
                    allRow["ten_khoa"] = "-- Tất cả khoa --";
                    dt.Rows.InsertAt(allRow, 0);

                    comboBox_khoa.DisplayMember = "ten_khoa";
                    comboBox_khoa.ValueMember = "khoa_id";
                    comboBox_khoa.DataSource = dt;
                    comboBox_khoa.SelectedIndex = 0; // Chọn "Tất cả khoa" mặc định
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khoa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm event handler cho ComboBox khoa
        private void comboBox_khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FilterInvitationsByKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc lời mời theo khoa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật method LoadInvitedEvents để bao gồm thông tin khoa
        private void LoadInvitedEvents()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    
                    // Lấy danh sách các sự kiện đã được mời, bao gồm thông tin khoa
                    string query = @"
                        SELECT 
                            e.event_id,
                            e.event_name,
                            e.event_date,
                            p.participation_date,
                            p.status,
                            e.description,
                            k.ten_khoa,
                            k.khoa_id
                        FROM Event e
                        INNER JOIN Participation p ON e.event_id = p.event_id
                        LEFT JOIN Khoa k ON e.khoa_id = k.khoa_id
                        WHERE p.CSV_id = @CSV_id
                        ORDER BY p.participation_date DESC, e.event_date DESC";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CSV_id", csvId);
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    
                    // Lưu dữ liệu gốc để lọc
                    originalInvitationDataTable = dataTable.Copy();
                    
                    // Áp dụng filter mặc định
                    FilterInvitationsByKhoa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lời mời: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm method lọc lời mời theo khoa
        private void FilterInvitationsByKhoa()
        {
            try
            {
                if (originalInvitationDataTable == null || originalInvitationDataTable.Rows.Count == 0)
                {
                    dataGridView_invitations.DataSource = null;
                    UpdateStatistics(new DataTable());
                    return;
                }

                DataView dv = new DataView(originalInvitationDataTable);
                string rowFilter = string.Empty;

                // Lọc theo khoa nếu không chọn "Tất cả khoa"
                if (comboBox_khoa?.SelectedValue != null)
                {
                    int selectedKhoaId = Convert.ToInt32(comboBox_khoa.SelectedValue);
                    
                    if (selectedKhoaId > 0) // Chọn khoa cụ thể
                    {
                        DataRowView selectedKhoaRow = comboBox_khoa.SelectedItem as DataRowView;
                        if (selectedKhoaRow != null && selectedKhoaRow["ten_khoa"] != null)
                        {
                            string selectedKhoaName = selectedKhoaRow["ten_khoa"].ToString().Trim();
                            string escapedKhoaName = selectedKhoaName.Replace("'", "''");
                            rowFilter = $"(ten_khoa IS NOT NULL) AND (ten_khoa = '{escapedKhoaName}')";
                        }
                    }
                    // Nếu selectedKhoaId = 0, hiển thị tất cả (không filter)
                }

                dv.RowFilter = rowFilter;

                // Cập nhật DataGridView với dữ liệu đã lọc
                DataTable filteredTable = dv.ToTable();
                dataGridView_invitations.DataSource = filteredTable;

                // Cập nhật thông tin thống kê với dữ liệu đã lọc
                UpdateStatistics(filteredTable);
                
                // Tùy chỉnh hiển thị theo trạng thái
                CustomizeRowDisplay();

                // Cấu hình format cột ngày
                ConfigureDataGridViewColumns();

                // Refresh DataGridView
                dataGridView_invitations.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc lời mời: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Fallback: hiển thị tất cả dữ liệu gốc
                if (originalInvitationDataTable != null)
                {
                    dataGridView_invitations.DataSource = originalInvitationDataTable;
                    UpdateStatistics(originalInvitationDataTable);
                    CustomizeRowDisplay();
                    ConfigureDataGridViewColumns();
                }
            }
        }

        // Thêm method để cấu hình các cột DataGridView
        private void ConfigureDataGridViewColumns()
        {
            try
            {
                if (dataGridView_invitations.Columns["event_date"] != null)
                {
                    dataGridView_invitations.Columns["event_date"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                
                if (dataGridView_invitations.Columns["participation_date"] != null)
                {
                    dataGridView_invitations.Columns["participation_date"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nhưng không hiển thị MessageBox để tránh spam
                System.Diagnostics.Debug.WriteLine($"Lỗi khi cấu hình cột: {ex.Message}");
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

            // Cập nhật thông tin thống kê với thông tin lọc
            string filterInfo = "";
            if (comboBox_khoa?.SelectedValue != null && Convert.ToInt32(comboBox_khoa.SelectedValue) > 0)
            {
                DataRowView selectedKhoaRow = comboBox_khoa.SelectedItem as DataRowView;
                if (selectedKhoaRow != null && selectedKhoaRow["ten_khoa"] != null)
                {
                    filterInfo = $" ({selectedKhoaRow["ten_khoa"]})";
                }
            }

            lbl_thongke.Text = $"Tổng{filterInfo}: {totalInvitations} | Chấp nhận: {acceptedCount} | Chờ phản hồi: {pendingCount} | Từ chối: {rejectedCount}";
            
            if (totalInvitations == 0)
            {
                label1.Text = comboBox_khoa?.SelectedValue != null && Convert.ToInt32(comboBox_khoa.SelectedValue) > 0 
                    ? "Cựu sinh viên này chưa được mời tham gia sự kiện nào của khoa này."
                    : "Cựu sinh viên này chưa được mời tham gia sự kiện nào.";
                label1.ForeColor = Color.Gray;
            }
            else
            {
                label1.Text = "Danh sách các sự kiện đã được mời:";
                label1.ForeColor = Color.FromArgb(64, 64, 64);
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
