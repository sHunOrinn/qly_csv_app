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
    public partial class invite_event_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        private int csvId;
        private string tenCuuSV;
        private DataTable originalEventDataTable; // Thêm để lưu dữ liệu gốc
        public int SelectedEventId { get; private set; }

        public invite_event_view(int csvId, string tenCuuSV)
        {
            InitializeComponent();
            this.csvId = csvId;
            this.tenCuuSV = tenCuuSV;
            
            // Hiển thị thông tin cựu sinh viên
            lbl_cuusv_info.Text = $"Cựu sinh viên: {tenCuuSV} (ID: {csvId})";
        }

        private void invite_event_view_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            LoadEvents();
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
                FilterEventsByKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc sự kiện theo khoa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật method LoadEvents để bao gồm thông tin khoa
        private void LoadEvents()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    
                    // Lấy danh sách sự kiện chưa được mời hoặc đã từ chối, bao gồm thông tin khoa
                    string query = @"
                        SELECT e.event_id, e.event_name, e.event_date, e.description, 
                               e.so_luong_tham_gia, k.ten_khoa, k.khoa_id
                        FROM Event e
                        LEFT JOIN Khoa k ON e.khoa_id = k.khoa_id
                        WHERE e.event_id NOT IN (
                            SELECT p.event_id 
                            FROM Participation p 
                            WHERE p.CSV_id = @CSV_id 
                            AND p.status IN (N'Được mời', N'Chấp nhận')
                        )
                        ORDER BY e.event_date DESC";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CSV_id", csvId);
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    
                    // Lưu dữ liệu gốc để lọc
                    originalEventDataTable = dataTable.Copy();
                    
                    // Áp dụng filter mặc định
                    FilterEventsByKhoa();
                    
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có sự kiện nào để mời cựu sinh viên này tham gia.", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_xacnhan.Enabled = false;
                    }
                    else
                    {
                        btn_xacnhan.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sự kiện: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm method lọc sự kiện theo khoa
        private void FilterEventsByKhoa()
        {
            try
            {
                if (originalEventDataTable == null || originalEventDataTable.Rows.Count == 0)
                {
                    dataGridView_events.DataSource = null;
                    btn_xacnhan.Enabled = false;
                    return;
                }

                DataView dv = new DataView(originalEventDataTable);
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
                dataGridView_events.DataSource = filteredTable;

                // Cấu hình lại các cột sau khi set DataSource
                ConfigureDataGridViewColumns();

                // Cập nhật trạng thái button
                btn_xacnhan.Enabled = filteredTable.Rows.Count > 0;

                // Refresh DataGridView
                dataGridView_events.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc sự kiện: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Fallback: hiển thị tất cả dữ liệu gốc
                if (originalEventDataTable != null)
                {
                    dataGridView_events.DataSource = originalEventDataTable;
                    ConfigureDataGridViewColumns();
                }
            }
        }

        // Thêm method để cấu hình các cột DataGridView
        private void ConfigureDataGridViewColumns()
        {
            try
            {
                if (dataGridView_events.Columns["event_date"] != null)
                {
                    dataGridView_events.Columns["event_date"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nhưng không hiển thị MessageBox để tránh spam
                System.Diagnostics.Debug.WriteLine($"Lỗi khi cấu hình cột: {ex.Message}");
            }
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (dataGridView_events.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sự kiện để gửi lời mời!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView_events.SelectedRows[0];
            int eventId = Convert.ToInt32(selectedRow.Cells["event_id"].Value);
            string eventName = selectedRow.Cells["event_name"].Value?.ToString();
            string khoaName = selectedRow.Cells["ten_khoa"].Value?.ToString() ?? "Không xác định";
            
            DialogResult confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn mời {tenCuuSV} tham gia sự kiện:\n" +
                $"'{eventName}'\n" +
                $"Khoa tổ chức: {khoaName}",
                "Xác nhận mời tham gia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (InviteToEvent(eventId, eventName))
                {
                    SelectedEventId = eventId;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private bool InviteToEvent(int eventId, string eventName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    
                    // Kiểm tra xem đã có lời mời chưa
                    string checkQuery = @"
                        SELECT COUNT(*) 
                        FROM Participation 
                        WHERE CSV_id = @CSV_id AND event_id = @event_id";
                    
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@CSV_id", csvId);
                    checkCommand.Parameters.AddWithValue("@event_id", eventId);
                    
                    int existingCount = (int)checkCommand.ExecuteScalar();
                    
                    if (existingCount > 0)
                    {
                        MessageBox.Show("Cựu sinh viên này đã được mời tham gia sự kiện này rồi!", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    // Thêm lời mời mới
                    string insertQuery = @"
                        INSERT INTO Participation (CSV_id, event_id, participation_date, status)
                        VALUES (@CSV_id, @event_id, @participation_date, @status)";
                    
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@CSV_id", csvId);
                    insertCommand.Parameters.AddWithValue("@event_id", eventId);
                    insertCommand.Parameters.AddWithValue("@participation_date", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@status", "Được mời");
                    
                    int result = insertCommand.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        MessageBox.Show($"Đã gửi lời mời thành công!\n{tenCuuSV} đã được mời tham gia sự kiện '{eventName}'.", 
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Không thể gửi lời mời. Vui lòng thử lại!", 
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi lời mời: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
