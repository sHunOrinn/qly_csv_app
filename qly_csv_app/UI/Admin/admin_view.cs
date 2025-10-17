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
            LoadKhoa(); // Load danh sách khoa cho bộ lọc
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
            // TODO: This line of code loads data into the 'quanLy_CSVDataSet.Khoa' table. You can move, or remove it, as needed.
            this.khoaTableAdapter.Fill(this.quanLy_CSVDataSet.Khoa);
            try
            {
                LoadCuuSVData();
                
                LoadEventData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCuuSVData()
        {
            try
            {
                //this.cuuSVTableAdapter.Fill(this.quanLy_CSVDataSet.CuuSV);
                //originalDataTable = this.quanLy_CSVDataSet.CuuSV.Copy();
                //txt_timkiem.Clear(); // Xóa text tìm kiếm
                SqlConnection connection = new SqlConnection(connectString);
                connection.Open();
                string query = @"SELECT c.CSV_id, c.Ten, c.NgaySinh, c.MSSV, c.DC, c.email, c.phone,
                                   kh.ten_khoa_hoc, n.ten_nganh, k.ten_khoa
                            FROM CuuSV c
                            LEFT JOIN KhoaHoc kh ON c.khoa_hoc_id = kh.khoa_hoc_id
                            LEFT JOIN Nganh n ON kh.nganh_id = n.nganh_id
                            LEFT JOIN Khoa k ON n.khoa_id = k.khoa_id
                            ORDER BY c.Ten";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                originalDataTable = dataTable.Copy();

                FilterCuuSVByKhoa();

                ConfigureCuuSVDataGridView();

                txt_timkiem.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //lọc các cựu sinh viên theo khoa
        private void comboBox_fillkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_fillkhoa.SelectedItem == null)
                    return;

                FilterCuuSVByKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                    emptyRow["ten_khoa"] = "-- Chọn khoa --";
                    dt.Rows.InsertAt(emptyRow, 0);

                    comboBox_fillkhoa.DisplayMember = "ten_khoa";
                    comboBox_fillkhoa.ValueMember = "khoa_id";
                    comboBox_fillkhoa.DataSource = dt;
                    comboBox_fillkhoa.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khoa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterCuuSVByKhoa()
        {
            try
            {
                // Kiểm tra dữ liệu gốc
                if (originalDataTable == null || originalDataTable.Rows.Count == 0)
                {
                    LoadCuuSVData(); // Load lại dữ liệu nếu chưa có
                    return;
                }

                // Kiểm tra ComboBox có dữ liệu không
                if (comboBox_fillkhoa.DataSource == null || comboBox_fillkhoa.Items.Count == 0)
                {
                    LoadKhoa(); // Load lại danh sách khoa nếu cần
                    return;
                }

                DataView dv = new DataView(originalDataTable);
                string filterInfo = "Tất cả khoa";

                // Kiểm tra giá trị được chọn với nhiều điều kiện an toàn hơn
                bool isAllSelected = comboBox_fillkhoa.SelectedValue == null ||
                                   comboBox_fillkhoa.SelectedValue == DBNull.Value ||
                                   comboBox_fillkhoa.SelectedIndex <= 0 ||
                                   Convert.ToInt32(comboBox_fillkhoa.SelectedValue) == 0;

                if (isAllSelected)
                {
                    // Hiển thị tất cả cựu sinh viên
                    dv.RowFilter = string.Empty;
                    filterInfo = "Tất cả khoa";
                }
                else
                {
                    // Lọc theo khoa được chọn
                    try
                    {
                        DataRowView selectedRow = comboBox_fillkhoa.SelectedItem as DataRowView;
                        if (selectedRow != null && selectedRow["ten_khoa"] != null && selectedRow["ten_khoa"] != DBNull.Value)
                        {
                            string selectedKhoaName = selectedRow["ten_khoa"].ToString().Trim();

                            if (!string.IsNullOrEmpty(selectedKhoaName))
                            {
                                // Escape single quotes để tránh SQL injection trong RowFilter
                                string escapedKhoaName = selectedKhoaName.Replace("'", "''");

                                // Lọc theo tên khoa với điều kiện kiểm tra null an toàn hơn
                                dv.RowFilter = $"(ten_khoa IS NOT NULL) AND (ISNULL(ten_khoa, '') <> '') AND (ten_khoa = '{escapedKhoaName}')";
                                filterInfo = selectedKhoaName;
                            }
                            else
                            {
                                // Nếu tên khoa rỗng, hiển thị tất cả
                                dv.RowFilter = string.Empty;
                                filterInfo = "Tất cả khoa";
                            }
                        }
                        else
                        {
                            // Nếu không thể lấy được thông tin khoa, hiển thị tất cả
                            dv.RowFilter = string.Empty;
                            filterInfo = "Tất cả khoa";
                        }
                    }
                    catch (Exception filterEx)
                    {
                        // Log lỗi chi tiết hơn và fallback về hiển thị tất cả
                        System.Diagnostics.Debug.WriteLine($"Lỗi khi tạo filter: {filterEx.Message}");
                        dv.RowFilter = string.Empty;
                        filterInfo = "Tất cả khoa";
                    }
                }

                // Cập nhật DataGridView với dữ liệu đã lọc
                DataTable filteredTable = dv.ToTable();
                dataGridView1.DataSource = filteredTable;

                // Hiển thị thông tin số lượng với format đẹp hơn
                int totalCount = dv.Count;
                label2.Text = $"Danh sách cựu SV ({filterInfo}: {totalCount:N0} người)";

                // Refresh DataGridView để đảm bảo hiển thị chính xác
                dataGridView1.Refresh();

                // Tự động resize columns nếu cần
                if (totalCount > 0 && dataGridView1.Columns.Count > 0)
                {
                    // Chỉ auto-resize khi có dữ liệu
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                }

            }
            catch (Exception ex)
            {
                // Xử lý lỗi với thông báo chi tiết hơn
                string errorMessage = $"Lỗi khi áp dụng bộ lọc khoa: {ex.Message}";
                System.Diagnostics.Debug.WriteLine(errorMessage);

                MessageBox.Show(errorMessage, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Fallback: hiển thị tất cả dữ liệu gốc
                try
                {
                    if (originalDataTable != null)
                    {
                        dataGridView1.DataSource = originalDataTable;
                        label2.Text = $"Danh sách cựu SV (Tất cả khoa: {originalDataTable.Rows.Count:N0} người)";

                        // Reset ComboBox về vị trí đầu tiên
                        if (comboBox_fillkhoa.Items.Count > 0)
                        {
                            comboBox_fillkhoa.SelectedIndex = 0;
                        }
                    }
                }
                catch (Exception fallbackEx)
                {
                    System.Diagnostics.Debug.WriteLine($"Lỗi khi fallback: {fallbackEx.Message}");
                    // Nếu fallback cũng lỗi, reload toàn bộ dữ liệu
                    LoadCuuSVData();
                }
            }
        }

        private void ConfigureCuuSVDataGridView()
        {
            try
            {
                // Thiết lập AutoGenerateColumns = false để tự quản lý columns
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();

                // Thêm các cột theo thứ tự mong muốn
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "cSVidDataGridViewTextBoxColumn",
                    DataPropertyName = "CSV_id",
                    HeaderText = "ID",
                    Width = 50,
                    ReadOnly = true
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "tenDataGridViewTextBoxColumn",
                    DataPropertyName = "Ten",
                    HeaderText = "Họ Tên",
                    Width = 150,
                    ReadOnly = true
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ngaySinhDataGridViewTextBoxColumn",
                    DataPropertyName = "NgaySinh",
                    HeaderText = "Ngày Sinh",
                    Width = 100,
                    ReadOnly = true
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "mSSVDataGridViewTextBoxColumn",
                    DataPropertyName = "MSSV",
                    HeaderText = "MSSV",
                    Width = 80,
                    ReadOnly = true
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "dCDataGridViewTextBoxColumn",
                    DataPropertyName = "DC",
                    HeaderText = "Địa Chỉ",
                    Width = 120,
                    ReadOnly = true
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "emailDataGridViewTextBoxColumn",
                    DataPropertyName = "email",
                    HeaderText = "Email",
                    Width = 150,
                    ReadOnly = true
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "phoneDataGridViewTextBoxColumn",
                    DataPropertyName = "phone",
                    HeaderText = "Điện Thoại",
                    Width = 100,
                    ReadOnly = true
                });

                // Thêm cột mới: Khóa học
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "khoaHocDataGridViewTextBoxColumn",
                    DataPropertyName = "ten_khoa_hoc",
                    HeaderText = "Khóa Học",
                    Width = 100,
                    ReadOnly = true
                });

                // Thêm cột mới: Tên Ngành
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "tenNganhDataGridViewTextBoxColumn",
                    DataPropertyName = "ten_nganh",
                    HeaderText = "Tên Ngành",
                    Width = 120,
                    ReadOnly = true
                });

                // Thêm cột mới: Tên Khoa
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "tenKhoaDataGridViewTextBoxColumn",
                    DataPropertyName = "ten_khoa",
                    HeaderText = "Tên Khoa",
                    Width = 120,
                    ReadOnly = true
                });

                // Định dạng cột ngày sinh
                if (dataGridView1.Columns["ngaySinhDataGridViewTextBoxColumn"] != null)
                {
                    dataGridView1.Columns["ngaySinhDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cấu hình DataGridView: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEventData()
        {
            try
            {
                //// Load data into the DataSet first
                //this.eventTableAdapter.Fill(this.quanLy_CSVDataSet.Event);
                
                //// Set the binding source to use the updated DataSet
                //eventBindingSource.DataSource = this.quanLy_CSVDataSet;
                //eventBindingSource.DataMember = "Event";
                
                //// Make sure the DataGridView uses the binding source
                //dataGridView_events.DataSource = eventBindingSource;
                
                //// Copy data for search functionality
                //using (SqlConnection connection = new SqlConnection(connectString))
                //{
                //    connection.Open();
                //    string query = @"SELECT event_id, event_name, event_date, so_luong_tham_gia, description
                //                    FROM Event 
                //                    ORDER BY event_date DESC";
                    
                //    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                //    DataTable dataTable = new DataTable();
                //    adapter.Fill(dataTable);
                //    originalEventDataTable = dataTable.Copy();
                //}
                SqlConnection connection = new SqlConnection(connectString);
                connection.Open();

                string query = @"SELECT e.event_id, e.event_name, e.event_date, e.so_luong_tham_gia, 
                                   e.description, k.ten_khoa, k.khoa_id
                            FROM Event e
                            LEFT JOIN Khoa k ON e.khoa_id = k.khoa_id
                            ORDER BY e.event_date DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Cập nhật DataGridView với dữ liệu mới
                dataGridView_events.DataSource = dataTable;

                // Lưu trữ dữ liệu gốc để tìm kiếm
                originalEventDataTable = dataTable.Copy();

                // Cấu hình lại các cột
                ConfigureEventDataGridView();

                txt_timkiem_event.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sự kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureEventDataGridView()
{
    try
    {
        // Thiết lập AutoGenerateColumns = false để tự quản lý columns
        dataGridView_events.AutoGenerateColumns = false;
        dataGridView_events.Columns.Clear();

        // Thêm các cột theo thứ tự mong muốn
        dataGridView_events.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "eventidDataGridViewTextBoxColumn",
            DataPropertyName = "event_id",
            HeaderText = "ID",
            Width = 50,
            ReadOnly = true
        });

        dataGridView_events.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "eventnameDataGridViewTextBoxColumn",
            DataPropertyName = "event_name",
            HeaderText = "Tên Sự Kiện",
            Width = 200,
            ReadOnly = true
        });

        dataGridView_events.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "eventdateDataGridViewTextBoxColumn",
            DataPropertyName = "event_date",
            HeaderText = "Ngày tổ chức",
            Width = 120,
            ReadOnly = true
        });

        dataGridView_events.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "soluongthamgiaDataGridViewTextBoxColumn",
            DataPropertyName = "so_luong_tham_gia",
            HeaderText = "Số lượng tham gia",
            Width = 130,
            ReadOnly = true
        });

        // Thêm cột mới: Khoa tổ chức
        dataGridView_events.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "tenKhoaDataGridViewTextBoxColumn",
            DataPropertyName = "ten_khoa",
            HeaderText = "Khoa tổ chức",
            Width = 150,
            ReadOnly = true
        });

        dataGridView_events.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "descriptionDataGridViewTextBoxColumn",
            DataPropertyName = "description",
            HeaderText = "Mô tả",
            Width = 250,
            ReadOnly = true
        });

        // Hidden column for khoa_id
        dataGridView_events.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "khoaIdDataGridViewTextBoxColumn",
            DataPropertyName = "khoa_id",
            HeaderText = "Khoa ID",
            Visible = false
        });

        // Định dạng cột ngày
        if (dataGridView_events.Columns["eventdateDataGridViewTextBoxColumn"] != null)
        {
            dataGridView_events.Columns["eventdateDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi khi cấu hình DataGridView Events: " + ex.Message, "Lỗi", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            TimKiemCuuSV();
        }

        private void btn_timkiem_event_Click(object sender, EventArgs e)
        {
            TimKiemEvent();
        }

        private void TimKiemCuuSV()
        {
            string tuKhoa = txt_timkiem.Text.Trim();
            
            if (string.IsNullOrEmpty(tuKhoa))
            {
                // Nếu không có từ khóa, tải lại tất cả dữ liệu
                LoadCuuSVData();
                return;
            }

            try
            {
                DataView dv = new DataView(originalDataTable);
                
                // Tìm kiếm theo ID, tên, MSSV, tên khoa, tên ngành
                if (int.TryParse(tuKhoa, out int csvId))
                {
                    // Nếu từ khóa là số, tìm theo ID hoặc các trường text
                    string filter = $"CSV_id = {csvId}";
                    
                    // Thêm điều kiện tìm kiếm text an toàn
                    if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        filter += $" OR Ten LIKE '%{tuKhoa.Replace("'", "''")}%' OR MSSV LIKE '%{tuKhoa.Replace("'", "''")}%'";

                        // Kiểm tra null trước khi tìm kiếm
                        filter += $" OR (ten_khoa IS NOT NULL AND ten_khoa LIKE '%{tuKhoa.Replace("'", "''")}%')";
                        filter += $" OR (ten_nganh IS NOT NULL AND ten_nganh LIKE '%{tuKhoa.Replace("'", "''")}%')";
                        filter += $" OR (ten_khoa_hoc IS NOT NULL AND ten_khoa_hoc LIKE '%{tuKhoa.Replace("'", "''")}%')";
                    }
                    
                    dv.RowFilter = filter;
                }
                else
                {
                    // Nếu từ khóa là văn bản, tìm theo các trường text
                    string filter = $"Ten LIKE '%{tuKhoa.Replace("'", "''")}%' OR MSSV LIKE '%{tuKhoa.Replace("'", "''")}%'";

                    // Kiểm tra null trước khi tìm kiếm
                    filter += $" OR (ten_khoa IS NOT NULL AND ten_khoa LIKE '%{tuKhoa.Replace("'", "''")}%')";
                    filter += $" OR (ten_nganh IS NOT NULL AND ten_nganh LIKE '%{tuKhoa.Replace("'", "''")}%')";
                    filter += $" OR (ten_khoa_hoc IS NOT NULL AND ten_khoa_hoc LIKE '%{tuKhoa.Replace("'", "''")}%')";
                    
                    dv.RowFilter = filter;
                }

                dataGridView1.DataSource = dv.ToTable();
                
                if (dv.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy cựu sinh viên nào với từ khóa: '{tuKhoa}'", 
                        "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Fallback: load lại dữ liệu gốc nếu có lỗi
                LoadCuuSVData();
            }
        }

        private void TimKiemEvent()
        {
            string tuKhoa = txt_timkiem_event.Text.Trim();
            
            if (string.IsNullOrEmpty(tuKhoa))
            {
                // Nếu không có từ khóa, tải lại tất cả dữ liệu
                LoadEventData();
                return;
            }

            try
            {
                DataView dv = new DataView(originalEventDataTable);
                
                // Tìm kiếm theo ID, tên sự kiện, mô tả hoặc tên khoa
                if (int.TryParse(tuKhoa, out int eventId))
                {
                    // Nếu từ khóa là số, tìm theo ID hoặc các trường text
                    string filter = $"event_id = {eventId}";
                    
                    if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        filter += $" OR event_name LIKE '%{tuKhoa.Replace("'", "''")}%'";
                        filter += $" OR (description IS NOT NULL AND description LIKE '%{tuKhoa.Replace("'", "''")}%')";
                        filter += $" OR (ten_khoa IS NOT NULL AND ten_khoa LIKE '%{tuKhoa.Replace("'", "''")}%')";
                    }
                    
                    dv.RowFilter = filter;
                }
                else
                {
                    // Nếu từ khóa là văn bản, tìm theo tên sự kiện, mô tả hoặc tên khoa
                    string filter = $"event_name LIKE '%{tuKhoa.Replace("'", "''")}%'";
                    filter += $" OR (description IS NOT NULL AND description LIKE '%{tuKhoa.Replace("'", "''")}%')";
                    filter += $" OR (ten_khoa IS NOT NULL AND ten_khoa LIKE '%{tuKhoa.Replace("'", "''")}%')";
                    
                    dv.RowFilter = filter;
                }

                // Cập nhật DataGridView với kết quả tìm kiếm
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
                // Fallback: load lại dữ liệu gốc nếu có lỗi
                LoadEventData();
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
                            // Xóa tất cả đóng góp liên quan đến sự kiện trước
                            string deleteContributionQuery = "DELETE FROM Contribution WHERE event_id = @event_id";
                            SqlCommand deleteContributionCmd = new SqlCommand(deleteContributionQuery, connection, transaction);
                            deleteContributionCmd.Parameters.AddWithValue("@event_id", eventId);
                            deleteContributionCmd.ExecuteNonQuery();

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
