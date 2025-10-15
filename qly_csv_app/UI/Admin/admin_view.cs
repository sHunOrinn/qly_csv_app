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
using qly_csv_app.UI.User;

namespace qly_csv_app.UI.Admin
{
    public partial class admin_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        private DataTable originalDataTable; // Lưu trữ dữ liệu gốc
        private DataTable originalEventDataTable; // Lưu trữ dữ liệu sự kiện gốc
        private int currentAdminUserId; // Thêm field để lưu ID admin hiện tại

        public admin_view()
        {
            InitializeComponent();
            // Ẩn tất cả panels khi khởi tạo
            HideAllPanels();
            
            // Thêm sự kiện double-click cho DataGridView cựu sinh viên
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            
            // Thêm sự kiện cho panel sự kiện
            dataGridView_events.CellDoubleClick += DataGridView_events_CellDoubleClick;
            btn_timkiem_event.Click += btn_timkiem_event_Click;
            txt_timkiem_event.KeyPress += Txt_timkiem_event_KeyPress;
            btn_them_event.Click +=Btn_them_event_Click;
            btn_xoa_event.Click += btn_xoa_event_Click;
            btn_capnhat_event.Click += btn_capnhat_event_Click;
            btn_themadmin.Click += btn_themadmin_Click;
            btn_them_admin_new.Click += btn_them_admin_new_Click;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng double-click vào một row hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                
                // Lấy thông tin cựu sinh viên
                int csvId = Convert.ToInt32(selectedRow.Cells["cSVidDataGridViewTextBoxColumn"].Value);
                string tenCuuSV = selectedRow.Cells["tenDataGridViewTextBoxColumn"].Value?.ToString();
                
                // Mở form hiển thị danh sách sự kiện đã được mời
                event_invited_view invitedForm = new event_invited_view(csvId, tenCuuSV);
                invitedForm.ShowDialog();
            }
        }

        private void DataGridView_events_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng double-click vào một row hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_events.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView_events.Rows[e.RowIndex];
                
                try
                {
                    // Use the designer column names since we're using the binding source
                    if (dataGridView_events.Columns.Contains("eventidDataGridViewTextBoxColumn") && 
                        selectedRow.Cells["eventidDataGridViewTextBoxColumn"].Value != null &&
                        dataGridView_events.Columns.Contains("eventnameDataGridViewTextBoxColumn") &&
                        dataGridView_events.Columns.Contains("eventdateDataGridViewTextBoxColumn") &&
                        selectedRow.Cells["eventdateDataGridViewTextBoxColumn"].Value != null)
                    {
                        // Lấy thông tin sự kiện using designer column names
                        int eventId = Convert.ToInt32(selectedRow.Cells["eventidDataGridViewTextBoxColumn"].Value);
                        string eventName = selectedRow.Cells["eventnameDataGridViewTextBoxColumn"]?.Value?.ToString() ?? "Không xác định";
                        DateTime eventDate = Convert.ToDateTime(selectedRow.Cells["eventdateDataGridViewTextBoxColumn"].Value);
                        
                        // Mở form hiển thị danh sách cựu sinh viên đã được mời
                        csv_invited_view csvForm = new csv_invited_view(eventId, eventName, eventDate);
                        csvForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xác định thông tin sự kiện từ dòng được chọn!", 
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý thông tin sự kiện: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HideAllPanels()
        {
            panel_cuusinhvien.Visible = false;
            panel_sukien.Visible = false;
            panel_themadmin.Visible = false;
        }

        private void ShowPanel(Panel panelToShow)
        {
            // Ẩn tất cả panels trước
            HideAllPanels();
            // Hiển thị panel được chọn
            panelToShow.Visible = true;
            panelToShow.BringToFront();
        }

        private void btn_danhsachcuusinhvien_Click(object sender, EventArgs e)
        {
            ShowPanel(panel_cuusinhvien);
            LoadCuuSVData(); // Tải lại dữ liệu khi mở panel
        }

        private void btn_danhsachsukien_Click(object sender, EventArgs e)
        {
            ShowPanel(panel_sukien);
            LoadEventData(); // Tải dữ liệu sự kiện
        }

        private void btn_themadmin_Click(object sender, EventArgs e)
        {
            ShowPanel(panel_themadmin);
            LoadAdminData(); // Load admin data when opening panel
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            // Đóng form admin và quay về form đăng nhập
            this.Close();
        }

        private void admin_view_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLy_CSVDataSet.Event' table. You can move, or remove it, as needed.
            this.eventTableAdapter.Fill(this.quanLy_CSVDataSet.Event);
            // TODO: This line of code loads data into the 'quanLy_CSVDataSet.CuuSV' table. You can move, or remove it, as needed.
            this.cuuSVTableAdapter.Fill(this.quanLy_CSVDataSet.CuuSV);
            // Lưu trữ dữ liệu gốc để tìm kiếm
            originalDataTable = this.quanLy_CSVDataSet.CuuSV.Copy();
        }

        private void LoadCuuSVData()
        {
            try
            {
                this.cuuSVTableAdapter.Fill(this.quanLy_CSVDataSet.CuuSV);
                originalDataTable = this.quanLy_CSVDataSet.CuuSV.Copy();
                txt_timkiem.Clear(); // Xóa text tìm kiếm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEventData()
        {
            try
            {
                // Load data into the DataSet first
                this.eventTableAdapter.Fill(this.quanLy_CSVDataSet.Event);
                
                // Set the binding source to use the updated DataSet
                eventBindingSource.DataSource = this.quanLy_CSVDataSet;
                eventBindingSource.DataMember = "Event";
                
                // Make sure the DataGridView uses the binding source
                dataGridView_events.DataSource = eventBindingSource;
                
                // Copy data for search functionality
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = @"SELECT event_id, event_name, event_date, so_luong_tham_gia, description
                                    FROM Event 
                                    ORDER BY event_date DESC";
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    originalEventDataTable = dataTable.Copy();
                }
                
                txt_timkiem_event.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sự kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void ConfigureEventDataGridView()
        //{
        //    if (dataGridView_events.Columns.Count > 0)
        //    {
        //        dataGridView_events.Columns["event_id"].HeaderText = "ID";
        //        dataGridView_events.Columns["event_id"].Width = 50;
                
        //        dataGridView_events.Columns["event_name"].HeaderText = "Tên Sự Kiện";
        //        dataGridView_events.Columns["event_name"].Width = 200;
                
        //        dataGridView_events.Columns["event_date"].HeaderText = "Ngày Diễn Ra";
        //        dataGridView_events.Columns["event_date"].Width = 120;

        //        dataGridView_events.Columns["so_luong_tham_gia"].HeaderText = "Số Lượng Tham Gia";
        //        dataGridView_events.Columns["so_luong_tham_gia"].Width = 130;

        //        dataGridView_events.Columns["description"].HeaderText = "Mô Tả";
        //        dataGridView_events.Columns["description"].Width = 218;
        //    }
        //}

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            TimKiemCuuSV();
        }

        private void btn_timkiem_event_Click(object sender, EventArgs e)
        {
            TimKiemEvent();
        }

        private void TimKiemEvent()
        {
            string tuKhoa = txt_timkiem_event.Text.Trim();
            
            if (string.IsNullOrEmpty(tuKhoa))
            {
                // Nếu không có từ khóa, hiển thị tất cả dữ liệu từ binding source
                LoadEventData(); // Reload to show all data
                return;
            }

            try
            {
                DataView dv = new DataView(originalEventDataTable);
                
                // Tìm kiếm theo ID hoặc tên sự kiện
                if (int.TryParse(tuKhoa, out int eventId))
                {
                    // Nếu từ khóa là số, tìm theo ID
                    dv.RowFilter = $"event_id = {eventId} OR event_name LIKE '%{tuKhoa}%'";

                    // Nếu từ khóa là số âm, tìm theo ID và mô tả
                    if (eventId < 0)
                    {
                        dv.RowFilter = $"event_id = {eventId} OR description LIKE '%{Math.Abs(eventId)}%'";
                    }
                }
                else
                {
                    // Nếu từ khóa là văn bản, tìm theo tên
                    dv.RowFilter = $"event_name LIKE '%{tuKhoa}%' OR description LIKE '%{tuKhoa}%'";
                }

                // For search results, temporarily use DataTable instead of binding source
                dataGridView_events.DataSource = dv.ToTable();
                
                if (dv.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy sự kiện nào với từ khóa: '{tuKhoa}'", 
                        "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_timkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiemCuuSV();
                e.Handled = true;
            }
        }

        private void Txt_timkiem_event_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiemEvent();
                e.Handled = true;
            }
        }

        private void TimKiemCuuSV()
        {
            string tuKhoa = txt_timkiem.Text.Trim();
            
            if (string.IsNullOrEmpty(tuKhoa))
            {
                // Nếu không có từ khóa, hiển thị tất cả dữ liệu
                cuuSVBindingSource.DataSource = originalDataTable;
                return;
            }

            try
            {
                DataView dv = new DataView(originalDataTable);
                
                // Tìm kiếm theo ID hoặc tên
                if (int.TryParse(tuKhoa, out int csvId))
                {
                    // Nếu từ khóa là số, tìm theo ID
                    dv.RowFilter = $"CSV_id = {csvId} OR Ten LIKE '%{tuKhoa}%'";
                }
                else
                {
                    // Nếu từ khóa là văn bản, tìm theo tên
                    dv.RowFilter = $"Ten LIKE '%{tuKhoa}%'";
                }

                cuuSVBindingSource.DataSource = dv.ToTable();
                
                if (dv.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy cựu sinh viên nào với từ khóa: '{tuKhoa}'", 
                        "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_themcuusinhvien_Click(object sender, EventArgs e)
        {
            add_csv_view addForm = new add_csv_view();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Reload data if a new student was added successfully
                LoadCuuSVData();
            }
        }

        private void Btn_them_event_Click(object sender, EventArgs e)
        {
            add_event_view addEventForm = new add_event_view();
            if (addEventForm.ShowDialog() == DialogResult.OK)
            {
                LoadEventData();
            }
        }

        private void btn_xoacuusinhvien_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một cựu sinh viên để xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int csvId = Convert.ToInt32(selectedRow.Cells["cSVidDataGridViewTextBoxColumn"].Value);
            string tenCuuSV = selectedRow.Cells["tenDataGridViewTextBoxColumn"].Value?.ToString();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa cựu sinh viên: {tenCuuSV} (ID: {csvId})?", 
                "Xác nhận xóa", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                XoaCuuSV(csvId);
            }
        }

        private void btn_xoa_event_Click(object sender, EventArgs e)
        {
            if (dataGridView_events.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sự kiện để xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView_events.SelectedRows[0];
            
            try
            {
                // Use designer column names
                if (dataGridView_events.Columns.Contains("eventidDataGridViewTextBoxColumn") && 
                    selectedRow.Cells["eventidDataGridViewTextBoxColumn"].Value != null)
                {
                    int eventId = Convert.ToInt32(selectedRow.Cells["eventidDataGridViewTextBoxColumn"].Value);
                    string eventName = selectedRow.Cells["eventnameDataGridViewTextBoxColumn"]?.Value?.ToString() ?? "Không xác định";

                    DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa sự kiện: '{eventName}' (ID: {eventId})?\n\nLưu ý: Tất cả lời mời liên quan sẽ bị xóa!", 
                        "Xác nhận xóa", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        XoaEvent(eventId);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xác định ID sự kiện!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý thông tin sự kiện: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaCuuSV(int csvId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "DELETE FROM CuuSV WHERE CSV_id = @CSV_id";
                    //xóa tài khoản liên quan
                    string deleteUserQuery = "DELETE FROM [User] WHERE CSV_id = @CSV_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CSV_id", csvId);

                    int rowsAffected = command.ExecuteNonQuery();
                    
                    if (rowsAffected > 0)
                    {
                        // Xóa tài khoản người dùng liên quan
                        SqlCommand deleteUserCommand = new SqlCommand(deleteUserQuery, connection);
                        deleteUserCommand.Parameters.AddWithValue("@CSV_id", csvId);
                        deleteUserCommand.ExecuteNonQuery();

                        MessageBox.Show("Xóa cựu sinh viên thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCuuSVData(); // Tải lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa cựu sinh viên!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa cựu sinh viên: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaEvent(int eventId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Xóa tất cả participation trước
                            string deleteParticipationQuery = "DELETE FROM Participation WHERE event_id = @event_id";
                            SqlCommand deleteParticipationCmd = new SqlCommand(deleteParticipationQuery, connection, transaction);
                            deleteParticipationCmd.Parameters.AddWithValue("@event_id", eventId);
                            deleteParticipationCmd.ExecuteNonQuery();

                            // Xóa sự kiện
                            string deleteEventQuery = "DELETE FROM Event WHERE event_id = @event_id";
                            SqlCommand deleteEventCmd = new SqlCommand(deleteEventQuery, connection, transaction);
                            deleteEventCmd.Parameters.AddWithValue("@event_id", eventId);
                                
                            int rowsAffected = deleteEventCmd.ExecuteNonQuery();
                            
                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show("Xóa sự kiện thành công!", "Thành công", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadEventData(); // Tải lại dữ liệu
                            }
                            else
                            {
                                transaction.Rollback();
                                MessageBox.Show("Không thể xóa sự kiện!", "Lỗi", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sự kiện: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_capnhat_event_Click(object sender, EventArgs e)
        {
            if (dataGridView_events.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sự kiện để cập nhật!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btn_moithamgiasukien_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một cựu sinh viên để mời tham gia sự kiện!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int csvId = Convert.ToInt32(selectedRow.Cells["cSVidDataGridViewTextBoxColumn"].Value);
            string tenCuuSV = selectedRow.Cells["tenDataGridViewTextBoxColumn"].Value?.ToString();

            // Mở form chọn sự kiện để mời
            invite_event_view inviteForm = new invite_event_view(csvId, tenCuuSV);
            
            if (inviteForm.ShowDialog() == DialogResult.OK)
            {
                // Lời mời đã được gửi thành công
                // Có thể thêm logic refresh data nếu cần
            }
        }

        private void btn_them_admin_new_Click(object sender, EventArgs e)
        {
            add_admin_view addAdminForm = new add_admin_view();
            if (addAdminForm.ShowDialog() == DialogResult.OK)
            {
                // Reload admin data if a new admin was added successfully
                LoadAdminData();
            }
        }

        private void LoadAdminData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = @"SELECT user_id, username, role_type, is_active, 
                                       CASE 
                                           WHEN is_active = 1 THEN N'Hoạt động' 
                                           ELSE N'Không hoạt động' 
                                       END AS status_text
                                FROM [User] 
                                WHERE role_type = N'admin'
                                ORDER BY username";
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    
                    dataGridView_admins.DataSource = dataTable;
                    
                    // Configure columns
                    ConfigureAdminDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu admin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureAdminDataGridView()
        {
            if (dataGridView_admins.Columns.Count > 0)
            {
                dataGridView_admins.Columns["user_id"].HeaderText = "ID";
                dataGridView_admins.Columns["user_id"].Width = 50;
                
                dataGridView_admins.Columns["username"].HeaderText = "Tên Tài Khoản";
                dataGridView_admins.Columns["username"].Width = 200;
                
                dataGridView_admins.Columns["role_type"].HeaderText = "Vai Trò";
                dataGridView_admins.Columns["role_type"].Width = 100;
                
                dataGridView_admins.Columns["is_active"].Visible = false; // Hide the boolean column
                
                dataGridView_admins.Columns["status_text"].HeaderText = "Trạng Thái";
                dataGridView_admins.Columns["status_text"].Width = 120;
            }
        }

        private void btn_capnhat_event_Click_1(object sender, EventArgs e)
        {
            if (dataGridView_events.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sự kiện để cập nhật!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView_events.SelectedRows[0];

            try
            {
                // Check if the required columns exist and have values
                if (dataGridView_events.Columns.Contains("eventidDataGridViewTextBoxColumn") &&
                    selectedRow.Cells["eventidDataGridViewTextBoxColumn"].Value != null &&
                    dataGridView_events.Columns.Contains("eventnameDataGridViewTextBoxColumn") &&
                    dataGridView_events.Columns.Contains("eventdateDataGridViewTextBoxColumn") &&
                    selectedRow.Cells["eventdateDataGridViewTextBoxColumn"].Value != null)
                {
                    // Get event information using designer column names
                    int eventId = Convert.ToInt32(selectedRow.Cells["eventidDataGridViewTextBoxColumn"].Value);
                    string eventName = selectedRow.Cells["eventnameDataGridViewTextBoxColumn"]?.Value?.ToString() ?? "";
                    DateTime eventDate = Convert.ToDateTime(selectedRow.Cells["eventdateDataGridViewTextBoxColumn"].Value);
                    string description = selectedRow.Cells["descriptionDataGridViewTextBoxColumn"]?.Value?.ToString() ?? "";
                    int participants = Convert.ToInt32(selectedRow.Cells["soluongthamgiaDataGridViewTextBoxColumn"]?.Value ?? 0);

                    // Open update form
                    update_event updateForm = new update_event(eventId, eventName, eventDate, description, participants);

                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        // Reload data if event was updated successfully
                        LoadEventData();
                        MessageBox.Show("Sự kiện đã được cập nhật thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xác định thông tin sự kiện từ dòng được chọn!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form cập nhật sự kiện: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_doimk_Click(object sender, EventArgs e)
        {
            change_password_view changePassForm = new change_password_view(currentAdminUserId);
            changePassForm.Show();
        }
    }
}
