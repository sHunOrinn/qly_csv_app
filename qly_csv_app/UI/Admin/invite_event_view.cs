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
            LoadEvents();
        }

        private void LoadEvents()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    
                    // Lấy danh sách sự kiện chưa được mời hoặc đã từ chối
                    string query = @"
                        SELECT e.event_id, e.event_name, e.event_date, e.description, e.so_luong_tham_gia
                        FROM Event e
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
                    
                    dataGridView_events.DataSource = dataTable;
                    
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
            
            DialogResult confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn mời {tenCuuSV} tham gia sự kiện:\n'{eventName}'?",
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
