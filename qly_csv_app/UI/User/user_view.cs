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

namespace qly_csv_app.UI.User
{
    public partial class user_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        private int currentUserId;
        private int currentCsvId;
        private string currentUserName;
        private int eventId;

        public user_view()
        {
            InitializeComponent();
            HideAllPanels();
        }

        public user_view(int userId, string userName) : this()
        {
            currentUserId = userId;
            currentUserName = userName;
            
            SetWelcomeText(userName);
        }

        private void SetWelcomeText(string userName)
        {
            string welcomeText = $"Xin chào,\n{userName}";
            
            lbl_welcome.AutoSize = false;
            lbl_welcome.Size = new Size(190, 60); 
            lbl_welcome.TextAlign = ContentAlignment.TopLeft;
            
            lbl_welcome.Text = welcomeText;
        }

        private void user_view_Load(object sender, EventArgs e)
        {
            try
            {
                // Check if we have valid user ID
                if (currentUserId <= 0)
                {
                    MessageBox.Show("Thông tin người dùng không hợp lệ!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Initialize DataGridView first to remove designer bindings
                InitializeDataGridView();
                
                LoadUserInfo();
                ShowPanel(panel_loimoi); // Hiển thị panel lời mời mặc định
                LoadInvitations();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDataGridView()
        {
            // Remove designer bindings and columns for invitations
            dataGridView_invitations.DataSource = null;
            dataGridView_invitations.Columns.Clear();
            dataGridView_invitations.AutoGenerateColumns = false;
            
            // Set basic properties for invitations DataGridView
            dataGridView_invitations.AllowUserToAddRows = false;
            dataGridView_invitations.AllowUserToDeleteRows = false;
            dataGridView_invitations.ReadOnly = true;
            dataGridView_invitations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_invitations.MultiSelect = false;
            dataGridView_invitations.BackgroundColor = Color.White;
            dataGridView_invitations.BorderStyle = BorderStyle.Fixed3D;

            // Initialize accepted events DataGridView
            dataGridView_accepted_events.DataSource = null;
            dataGridView_accepted_events.Columns.Clear();
            dataGridView_accepted_events.AutoGenerateColumns = false;
            dataGridView_accepted_events.AllowUserToAddRows = false;
            dataGridView_accepted_events.AllowUserToDeleteRows = false;
            dataGridView_accepted_events.ReadOnly = true;
            dataGridView_accepted_events.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_accepted_events.MultiSelect = false;
            dataGridView_accepted_events.BackgroundColor = Color.White;
            dataGridView_accepted_events.BorderStyle = BorderStyle.Fixed3D;

            // Add double-click event handler for accepted events
            dataGridView_accepted_events.CellDoubleClick += DataGridView_accepted_events_CellDoubleClick;
        }

        private void DataGridView_accepted_events_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if a valid row is double-clicked
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView_accepted_events.Rows.Count)
                {
                    DataGridViewRow selectedRow = dataGridView_accepted_events.Rows[e.RowIndex];
                    
                    // Check if the required columns exist and have values
                    if (dataGridView_accepted_events.Columns["event_id"] == null ||
                        dataGridView_accepted_events.Columns["event_name"] == null ||
                        selectedRow.Cells["event_id"].Value == null ||
                        selectedRow.Cells["event_name"].Value == null)
                    {
                        MessageBox.Show("Không thể xác định thông tin sự kiện!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int eventId = Convert.ToInt32(selectedRow.Cells["event_id"].Value);
                    string eventName = selectedRow.Cells["event_name"].Value.ToString();

                    // Show contribution information form
                    ShowEventContributionInfo(eventId, eventName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý thông tin sự kiện: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowEventContributionInfo(int eventId, string eventName)
        {
            // Xóa tham số eventName vì không còn liên kết sự kiện cụ thể
            //contribute_view.ShowUserContributions(currentCsvId, currentUserName);
            contribute_view.ShowUserContributionsForEvent(currentCsvId, currentUserName, eventId, eventName);
        }


        private void LoadUserInfo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = @"SELECT u.CSV_id, c.Ten, c.NgaySinh, c.MSSV, c.DC, c.email, c.phone
                                    FROM [User] u
                                    INNER JOIN CuuSV c ON u.CSV_id = c.CSV_id
                                    WHERE u.user_id = @user_id";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", currentUserId);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        currentCsvId = Convert.ToInt32(reader["CSV_id"]);
                        txt_hoten.Text = reader["Ten"]?.ToString();
                        
                        // Handle potential null date
                        if (reader["NgaySinh"] != DBNull.Value)
                        {
                            dtp_ngaysinh.Value = Convert.ToDateTime(reader["NgaySinh"]);
                        }
                        
                        txt_mssv.Text = reader["MSSV"]?.ToString();
                        txt_diachi.Text = reader["DC"]?.ToString();
                        txt_email.Text = reader["email"]?.ToString();
                        txt_phone.Text = reader["phone"]?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin người dùng!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin người dùng: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInvitations()
        {
            try
            {
                // Check if currentCsvId is valid
                if (currentCsvId <= 0)
                {
                    label_loimoi_title.Text = "Danh sách lời mời - Chưa có thông tin cá nhân";
                    CreateEmptyInvitationDataTable();
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = @"SELECT p.participation_id, e.event_name, e.event_date, 
                                   e.description, p.participation_date, p.status
                            FROM Participation p
                            INNER JOIN Event e ON p.event_id = e.event_id
                            WHERE p.CSV_id = @csv_id and p.status IN (N'Được mời', N'Từ chối')
                            ORDER BY p.participation_date DESC";
            
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@csv_id", currentCsvId);
            
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
            
                    if (dataTable.Rows.Count > 0)
                    {
                        // Check if we have the expected columns
                        bool hasExpectedColumns = dataTable.Columns.Contains("event_name") && 
                                        dataTable.Columns.Contains("event_date") && 
                                        dataTable.Columns.Contains("description");
                
                        if (!hasExpectedColumns)
                        {
                            MessageBox.Show($"Cấu trúc dữ liệu không đúng. Các cột có sẵn: {string.Join(", ", dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName))}", 
                                "Lỗi cấu trúc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            CreateEmptyInvitationDataTable();
                            return;
                        }
                    }
            
                    dataGridView_invitations.DataSource = dataTable;
            
                    if (dataTable.Rows.Count == 0)
                    {
                        // Show a message if no invitations found
                        label_loimoi_title.Text = "Danh sách lời mời - Chưa có lời mời nào";
                        // Create empty DataTable with proper structure to avoid column errors
                        CreateEmptyInvitationDataTable();
                    }
                    else
                    {
                        label_loimoi_title.Text = $"Danh sách lời mời ({dataTable.Rows.Count} lời mời)";
                
                        // Always configure the DataGridView after setting the data source
                        ConfigureInvitationDataGridView();
                        CustomizeRowDisplay();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lời mời: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_loimoi_title.Text = "Danh sách lời mời - Lỗi khi tải dữ liệu";
                CreateEmptyInvitationDataTable();
            }
        }

        // Load accepted events method
        private void LoadAcceptedEvents()
        {
            try
            {
                if (currentCsvId <= 0)
                {
                    label_accepted_events_title.Text = "Danh sách sự kiện tham gia - Chưa có thông tin cá nhân";
                    CreateEmptyAcceptedEventsDataTable();
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = @"SELECT p.participation_id, e.event_id, e.event_name, e.event_date, 
                                           e.description, p.participation_date, p.status, p.feedback,
                                           CASE 
                                               WHEN e.event_date < CAST(GETDATE() AS DATE) THEN N'Đã diễn ra'
                                               WHEN e.event_date = CAST(GETDATE() AS DATE) THEN N'Đang diễn ra'
                                               ELSE N'Sắp diễn ra'
                                           END AS event_status
                                    FROM Participation p
                                    INNER JOIN Event e ON p.event_id = e.event_id
                                    WHERE p.CSV_id = @csv_id AND p.status = N'Chấp nhận'
                                    ORDER BY e.event_date DESC";
            
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@csv_id", currentCsvId);
            
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
            
                    dataGridView_accepted_events.DataSource = dataTable;
                    
                    if (dataTable.Rows.Count == 0)
                    {
                        label_accepted_events_title.Text = "Danh sách sự kiện tham gia - Chưa tham gia sự kiện nào";
                        CreateEmptyAcceptedEventsDataTable();
                    }
                    else
                    {
                        label_accepted_events_title.Text = $"Danh sách sự kiện tham gia ({dataTable.Rows.Count} sự kiện)";
                        
                        ConfigureAcceptedEventsDataGridView();
                        CustomizeAcceptedEventsDisplay();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sự kiện tham gia: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_accepted_events_title.Text = "Danh sách sự kiện tham gia - Lỗi khi tải dữ liệu";
                CreateEmptyAcceptedEventsDataTable();
            }
        }

        private void CreateEmptyAcceptedEventsDataTable()
        {
            DataTable emptyTable = new DataTable();
            emptyTable.Columns.Add("participation_id", typeof(int));
            emptyTable.Columns.Add("event_id", typeof(int));
            emptyTable.Columns.Add("event_name", typeof(string));
            emptyTable.Columns.Add("event_date", typeof(DateTime));
            emptyTable.Columns.Add("description", typeof(string));
            emptyTable.Columns.Add("participation_date", typeof(DateTime));
            emptyTable.Columns.Add("status", typeof(string));
            emptyTable.Columns.Add("feedback", typeof(string));
            emptyTable.Columns.Add("event_status", typeof(string));
            
            dataGridView_accepted_events.DataSource = emptyTable;
            ConfigureAcceptedEventsDataGridView();
        }

        private void ConfigureAcceptedEventsDataGridView()
        {
            try
            {
                dataGridView_accepted_events.AutoGenerateColumns = false;
                dataGridView_accepted_events.Columns.Clear();
        
                // Hidden columns
                DataGridViewTextBoxColumn participationIdColumn = new DataGridViewTextBoxColumn
                {
                    Name = "participation_id",
                    DataPropertyName = "participation_id",
                    HeaderText = "ID Tham Gia",
                    Visible = false
                };
                dataGridView_accepted_events.Columns.Add(participationIdColumn);

                DataGridViewTextBoxColumn eventIdColumn = new DataGridViewTextBoxColumn
                {
                    Name = "event_id",
                    DataPropertyName = "event_id",
                    HeaderText = "ID Sự Kiện",
                    Visible = false
                };
                dataGridView_accepted_events.Columns.Add(eventIdColumn);

                // Visible columns
                DataGridViewTextBoxColumn eventNameColumn = new DataGridViewTextBoxColumn
                {
                    Name = "event_name",
                    DataPropertyName = "event_name",
                    HeaderText = "Tên Sự Kiện",
                    Width = 150,
                    ReadOnly = true
                };
                dataGridView_accepted_events.Columns.Add(eventNameColumn);

                DataGridViewTextBoxColumn eventDateColumn = new DataGridViewTextBoxColumn
                {
                    Name = "event_date",
                    DataPropertyName = "event_date",
                    HeaderText = "Ngày tổ chức",
                    Width = 100,
                    ReadOnly = true
                };
                eventDateColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView_accepted_events.Columns.Add(eventDateColumn);

                DataGridViewTextBoxColumn eventStatusColumn = new DataGridViewTextBoxColumn
                {
                    Name = "event_status",
                    DataPropertyName = "event_status",
                    HeaderText = "Tình trạng",
                    Width = 100,
                    ReadOnly = true
                };
                dataGridView_accepted_events.Columns.Add(eventStatusColumn);

                DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn
                {
                    Name = "description",
                    DataPropertyName = "description",
                    HeaderText = "Mô Tả",
                    Width = 150,
                    ReadOnly = true
                };
                dataGridView_accepted_events.Columns.Add(descriptionColumn);

                DataGridViewTextBoxColumn participationDateColumn = new DataGridViewTextBoxColumn
                {
                    Name = "participation_date",
                    DataPropertyName = "participation_date",
                    HeaderText = "Ngày Tham Gia",
                    Width = 100,
                    ReadOnly = true
                };
                participationDateColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView_accepted_events.Columns.Add(participationDateColumn);

                // Set additional DataGridView properties
                dataGridView_accepted_events.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView_accepted_events.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView_accepted_events.MultiSelect = false;
                dataGridView_accepted_events.AllowUserToAddRows = false;
                dataGridView_accepted_events.AllowUserToDeleteRows = false;
                dataGridView_accepted_events.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cấu hình DataGridView sự kiện tham gia: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Customize accepted events display
        private void CustomizeAcceptedEventsDisplay()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView_accepted_events.Rows)
                {
                    if (!row.IsNewRow && dataGridView_accepted_events.Columns["event_status"] != null && 
                        row.Cells["event_status"].Value != null)
                    {
                        string eventStatus = row.Cells["event_status"].Value.ToString();
                        switch (eventStatus)
                        {
                            case "Đã diễn ra":
                                row.DefaultCellStyle.BackColor = Color.LightGray;
                                row.DefaultCellStyle.ForeColor = Color.Black;
                                break;
                            case "Đang diễn ra":
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                                row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                                break;
                            case "Sắp diễn ra":
                                row.DefaultCellStyle.BackColor = Color.LightBlue;
                                row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tùy chỉnh hiển thị sự kiện tham gia: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateEmptyInvitationDataTable()
        {
            DataTable emptyTable = new DataTable();
            emptyTable.Columns.Add("participation_id", typeof(int));
            emptyTable.Columns.Add("event_name", typeof(string));
            emptyTable.Columns.Add("event_date", typeof(DateTime));
            emptyTable.Columns.Add("description", typeof(string));
            emptyTable.Columns.Add("participation_date", typeof(DateTime));
            emptyTable.Columns.Add("status", typeof(string));
            
            dataGridView_invitations.DataSource = emptyTable;
            ConfigureInvitationDataGridView();
        }

        private void ConfigureInvitationDataGridView()
        {
            try
            {
                dataGridView_invitations.AutoGenerateColumns = false;
                dataGridView_invitations.Columns.Clear();
        
                DataGridViewTextBoxColumn participationIdColumn = new DataGridViewTextBoxColumn
                {
                    Name = "participation_id",
                    DataPropertyName = "participation_id",
                    HeaderText = "ID Tham Gia",
                    Visible = false
                };
                dataGridView_invitations.Columns.Add(participationIdColumn);

                DataGridViewTextBoxColumn eventNameColumn = new DataGridViewTextBoxColumn
                {
                    Name = "event_name",
                    DataPropertyName = "event_name",
                    HeaderText = "Tên Sự Kiện",
                    Width = 150,
                    ReadOnly = true
                };
                dataGridView_invitations.Columns.Add(eventNameColumn);

                DataGridViewTextBoxColumn eventDateColumn = new DataGridViewTextBoxColumn
                {
                    Name = "event_date",
                    DataPropertyName = "event_date",
                    HeaderText = "Ngày tổ chức",
                    Width = 100,
                    ReadOnly = true
                };
                eventDateColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView_invitations.Columns.Add(eventDateColumn);

                DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn
                {
                    Name = "description",
                    DataPropertyName = "description",
                    HeaderText = "Mô Tả",
                    Width = 180,
                    ReadOnly = true
                };
                dataGridView_invitations.Columns.Add(descriptionColumn);

                DataGridViewTextBoxColumn participationDateColumn = new DataGridViewTextBoxColumn
                {
                    Name = "participation_date",
                    DataPropertyName = "participation_date",
                    HeaderText = "Ngày Mời",
                    Width = 100,
                    ReadOnly = true
                };
                participationDateColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView_invitations.Columns.Add(participationDateColumn);

                DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn
                {
                    Name = "status",
                    DataPropertyName = "status",
                    HeaderText = "Trạng Thái",
                    Width = 100,
                    ReadOnly = true
                };
                dataGridView_invitations.Columns.Add(statusColumn);

                // Set additional DataGridView properties
                dataGridView_invitations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView_invitations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView_invitations.MultiSelect = false;
                dataGridView_invitations.AllowUserToAddRows = false;
                dataGridView_invitations.AllowUserToDeleteRows = false;
                dataGridView_invitations.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cấu hình DataGridView: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeRowDisplay()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView_invitations.Rows)
                {
                    if (!row.IsNewRow && dataGridView_invitations.Columns["status"] != null && 
                        row.Cells["status"].Value != null)
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tùy chỉnh hiển thị: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideAllPanels()
        {
            panel_loimoi.Visible = false;
            panel_thongtin.Visible = false;
            panel_sukienthamgia.Visible = false; // Add the new panel
        }

        private void ShowPanel(Panel panelToShow)
        {
            HideAllPanels();
            panelToShow.Visible = true;
            panelToShow.BringToFront();
        }

        private void btn_danhsachloimoi_Click(object sender, EventArgs e)
        {
            ShowPanel(panel_loimoi);
            LoadInvitations();
        }

        // NEW: Button click event for accepted events
        private void btn_danhsachsukienthamgia_Click(object sender, EventArgs e)
        {
            ShowPanel(panel_sukienthamgia);
            LoadAcceptedEvents();
        }

        private void btn_thongtincanhan_Click(object sender, EventArgs e)
        {
            //txt_hoten.Enabled = false;
            //dtp_ngaysinh.Enabled = false;
            txt_mssv.Enabled = false;
            txt_email.Enabled = false;
            //txt_diachi.Enabled = false;
            //txt_phone.Enabled = false;
            ShowPanel(panel_thongtin);
        }

        private void btn_chapnhan_Click(object sender, EventArgs e)
        {
            UpdateInvitationStatus("Chấp nhận");
        }

        private void btn_tuchoi_Click(object sender, EventArgs e)
        {
            UpdateInvitationStatus("Từ chối");
        }

        private void UpdateInvitationStatus(string newStatus)
        {
            try
            {
                if (dataGridView_invitations.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một lời mời để cập nhật!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGridView_invitations.SelectedRows[0];
                
                // Check if the required columns exist and have values
                if (dataGridView_invitations.Columns["status"] == null || 
                    dataGridView_invitations.Columns["participation_id"] == null ||
                    selectedRow.Cells["status"].Value == null ||
                    selectedRow.Cells["participation_id"].Value == null)
                {
                    MessageBox.Show("Không thể xác định thông tin lời mời!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                string currentStatus = selectedRow.Cells["status"].Value.ToString();
                
                if (currentStatus != "Được mời")
                {
                    MessageBox.Show("Chỉ có thể cập nhật trạng thái cho lời mời chưa phản hồi!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int participationId = Convert.ToInt32(selectedRow.Cells["participation_id"].Value);
                string eventName = selectedRow.Cells["event_name"]?.Value?.ToString() ?? "Không xác định";

                if (newStatus == "Chấp nhận")
                {
                    // First update the participation status
                    if (UpdateParticipationInDatabase(participationId, newStatus))
                    {
                        int eventId = GetEventIdFromParticipation(participationId);
                        donggop_view contributionForm = new donggop_view(currentCsvId, eventName, participationId, eventId);
                        DialogResult contributionResult = contributionForm.ShowDialog();
                        
                        if (contributionResult == DialogResult.Cancel)
                        {
                            // User cancelled, participation was rolled back in the contribution form
                            LoadInvitations(); // Reload to show updated status
                            return;
                        }
                        
                        // Whether they contributed or not, the participation is accepted
                        MessageBox.Show($"Đã chấp nhận tham gia sự kiện '{eventName}'!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadInvitations(); // Reload data
                    }
                }
                else
                {
                    // For rejection, just confirm and update
                    DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn {newStatus.ToLower()} lời mời tham gia sự kiện '{eventName}'?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (UpdateParticipationInDatabase(participationId, newStatus))
                        {
                            MessageBox.Show($"Đã {newStatus.ToLower()} lời mời thành công!", "Thành công", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadInvitations(); // Reload data
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetEventIdFromParticipation(int participationId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "SELECT event_id FROM Participation WHERE participation_id = @participation_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@participation_id", participationId);

                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        private bool UpdateParticipationInDatabase(int participationId, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "UPDATE Participation SET status = @status WHERE participation_id = @participation_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@participation_id", participationId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btn_capnhat_thongtin_Click(object sender, EventArgs e)
        {
            if (ValidatePersonalInfo())
            {
                UpdatePersonalInfo();
            }
        }

        private void btn_doimatkhau_Click(object sender, EventArgs e)
        {
            change_password_view changePasswordForm = new change_password_view(currentUserId);
            DialogResult result = changePasswordForm.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Đăng xuất sau khi đổi mật khẩu
                this.Close();

            }
        }

        private bool ValidatePersonalInfo()
        {
            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txt_hoten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_hoten.Focus();
                return false;
            }

            // Kiểm tra độ dài họ tên
            if (txt_hoten.Text.Trim().Length < 2)
            {
                MessageBox.Show("Họ và tên phải có ít nhất 2 ký tự!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_hoten.Focus();
                return false;
            }

            // Kiểm tra số điện thoại (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(txt_phone.Text))
            {
                if (txt_phone.Text.Length != 10 || !txt_phone.Text.StartsWith("0") || !txt_phone.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_phone.Focus();
                    return false;
                }
            }

            // Kiểm tra ngày sinh hợp lệ
            if (dtp_ngaysinh.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_ngaysinh.Focus();
                return false;
            }

            // Kiểm tra tuổi tối thiểu
            int age = DateTime.Now.Year - dtp_ngaysinh.Value.Year;
            if (DateTime.Now.DayOfYear < dtp_ngaysinh.Value.DayOfYear)
                age--;

            if (age < 22)
            {
                MessageBox.Show("Cựu sinh viên phải từ 22 tuổi trở lên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_ngaysinh.Focus();
                return false;
            }

            return true;
        }

        private void UpdatePersonalInfo()
        {
            //txt_hoten.Enabled = true;
            //dtp_ngaysinh.Enabled = true;
            //txt_diachi.Enabled = true;
            //txt_phone.Enabled = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = @"UPDATE CuuSV 
                                    SET Ten = @Ten, NgaySinh = @NgaySinh, DC = @DC, phone = @phone
                                    WHERE CSV_id = @CSV_id";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ten", txt_hoten.Text.Trim());
                    command.Parameters.AddWithValue("@NgaySinh", dtp_ngaysinh.Value.Date);
                    command.Parameters.AddWithValue("@DC", string.IsNullOrWhiteSpace(txt_diachi.Text) ? (object)DBNull.Value : txt_diachi.Text.Trim());
                    command.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(txt_phone.Text) ? (object)DBNull.Value : txt_phone.Text.Trim());
                    command.Parameters.AddWithValue("@CSV_id", currentCsvId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin cá nhân thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Update welcome label if name changed
                        currentUserName = txt_hoten.Text.Trim();
                        SetWelcomeText(currentUserName);
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
