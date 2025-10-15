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

namespace qly_csv_app.UI
{
    public partial class contribute_view : Form
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        private int csvId;
        private string userName;
        private int eventId; // Added to support event-specific filtering
        private string eventName; // Added to display event info

        // Default constructor for designer compatibility
        public contribute_view()
        {
            InitializeComponent();
            InitializeForm();
        }

        // Constructor for user-specific contributions (all events)
        public contribute_view(int csvId, string userName = "") : this()
        {
            this.csvId = csvId;
            this.userName = userName;
            this.eventId = 0; // 0 means show all contributions
        }

        // New constructor for event-specific contributions
        public contribute_view(int csvId, string userName, int eventId, string eventName) : this()
        {
            this.csvId = csvId;
            this.userName = userName;
            this.eventId = eventId;
            this.eventName = eventName;
        }

        private void InitializeForm()
        {
            // Set initial ComboBox selection
            cmb_filter.SelectedIndex = 0;
            
            // Configure DataGridView
            ConfigureContributionGrid(dgv_contributions);
        }

        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadContributionData();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadContributionData();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contribute_view_Load(object sender, EventArgs e)
        {
            LoadContributionData();
        }

        private void LoadContributionData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query;
                    SqlCommand command;

                    if (csvId > 0)
                    {
                        if (eventId > 0)
                        {
                            // Load contributions for specific user and specific event
                            // Cải tiến logic để chỉ lấy đóng góp liên quan đến sự kiện cụ thể
                            query = @"SELECT c.contribution_id, c.contribution_type, c.amount, 
                                            c.contribution_date, c.details, csv.Ten as contributor_name
                                     FROM Contribution c
                                     INNER JOIN CuuSV csv ON c.CSV_id = csv.CSV_id
                                     WHERE c.CSV_id = @csv_id 
                                     AND (
                                         -- Đóng góp được tạo sau khi chấp nhận tham gia sự kiện
                                         c.contribution_date >= (
                                             SELECT p.participation_date 
                                             FROM Participation p 
                                             WHERE p.CSV_id = c.CSV_id 
                                             AND p.event_id = @event_id 
                                             AND p.status = N'Chấp nhận'
                                         )
                                         OR 
                                         -- Đóng góp trong khoảng thời gian gần sự kiện (30 ngày trước đến 7 ngày sau)
                                         c.contribution_date BETWEEN 
                                             DATEADD(day, -30, (SELECT event_date FROM Event WHERE event_id = @event_id)) 
                                             AND 
                                             DATEADD(day, 7, (SELECT event_date FROM Event WHERE event_id = @event_id))
                                     )";

                            // Add filter condition
                            if (cmb_filter.SelectedItem != null && cmb_filter.SelectedItem.ToString() != "Tất cả")
                            {
                                query += " AND c.contribution_type = @contribution_type";
                            }

                            query += " ORDER BY c.contribution_date DESC";

                            command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@csv_id", csvId);
                            command.Parameters.AddWithValue("@event_id", eventId);

                            if (cmb_filter.SelectedItem != null && cmb_filter.SelectedItem.ToString() != "Tất cả")
                            {
                                command.Parameters.AddWithValue("@contribution_type", cmb_filter.SelectedItem.ToString());
                            }

                            // Update info label to show event-specific info
                            string displayName = !string.IsNullOrEmpty(userName) ? userName : "Người dùng";
                            lbl_info.Text = $"Đóng góp của {displayName} cho sự kiện: {eventName}";
                        }
                        else
                        {
                            // Load all contributions for specific user (original logic)
                            query = @"SELECT c.contribution_id, c.contribution_type, c.amount, 
                                            c.contribution_date, c.details, csv.Ten as contributor_name
                                     FROM Contribution c
                                     INNER JOIN CuuSV csv ON c.CSV_id = csv.CSV_id
                                     WHERE c.CSV_id = @csv_id";

                            // Add filter condition
                            if (cmb_filter.SelectedItem != null && cmb_filter.SelectedItem.ToString() != "Tất cả")
                            {
                                query += " AND c.contribution_type = @contribution_type";
                            }

                            query += " ORDER BY c.contribution_date DESC";

                            command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@csv_id", csvId);

                            if (cmb_filter.SelectedItem != null && cmb_filter.SelectedItem.ToString() != "Tất cả")
                            {
                                command.Parameters.AddWithValue("@contribution_type", cmb_filter.SelectedItem.ToString());
                            }

                            // Update info label
                            string displayName = !string.IsNullOrEmpty(userName) ? userName : "Người dùng";
                            lbl_info.Text = $"Tất cả đóng góp của: {displayName}";
                        }
                    }
                    else
                    {
                        // Load all contributions in system (original logic)
                        query = @"SELECT c.contribution_id, c.contribution_type, c.amount, 
                                        c.contribution_date, c.details, csv.Ten as contributor_name
                                 FROM Contribution c
                                 INNER JOIN CuuSV csv ON c.CSV_id = csv.CSV_id";

                        // Add filter condition
                        if (cmb_filter.SelectedItem != null && cmb_filter.SelectedItem.ToString() != "Tất cả")
                        {
                            query += " WHERE c.contribution_type = @contribution_type";
                        }

                        query += " ORDER BY c.contribution_date DESC";

                        command = new SqlCommand(query, connection);

                        if (cmb_filter.SelectedItem != null && cmb_filter.SelectedItem.ToString() != "Tất cả")
                        {
                            command.Parameters.AddWithValue("@contribution_type", cmb_filter.SelectedItem.ToString());
                        }

                        // Update info label
                        lbl_info.Text = "Tất cả đóng góp trong hệ thống";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgv_contributions.DataSource = dataTable;
                    UpdateSummary(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu đóng góp: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureContributionGrid(DataGridView grid)
        {
            // Clear existing columns
            grid.Columns.Clear();

            // Hidden ID column
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                Name = "contribution_id",
                DataPropertyName = "contribution_id",
                HeaderText = "ID",
                Visible = false
            };
            grid.Columns.Add(idColumn);

            // Contributor name column (only show if viewing all contributions)
            if (csvId <= 0)
            {
                DataGridViewTextBoxColumn contributorColumn = new DataGridViewTextBoxColumn
                {
                    Name = "contributor_name",
                    DataPropertyName = "contributor_name",
                    HeaderText = "Người đóng góp",
                    Width = 150,
                    ReadOnly = true
                };
                grid.Columns.Add(contributorColumn);
            }

            // Contribution type column
            DataGridViewTextBoxColumn typeColumn = new DataGridViewTextBoxColumn
            {
                Name = "contribution_type",
                DataPropertyName = "contribution_type",
                HeaderText = "Loại đóng góp",
                Width = 120,
                ReadOnly = true
            };
            grid.Columns.Add(typeColumn);

            // Amount column
            DataGridViewTextBoxColumn amountColumn = new DataGridViewTextBoxColumn
            {
                Name = "amount",
                DataPropertyName = "amount",
                HeaderText = "Số tiền (VND)",
                Width = 150,
                ReadOnly = true
            };
            amountColumn.DefaultCellStyle.Format = "N0";
            amountColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid.Columns.Add(amountColumn);

            // Date column
            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn
            {
                Name = "contribution_date",
                DataPropertyName = "contribution_date",
                HeaderText = "Ngày đóng góp",
                Width = 150,
                ReadOnly = true
            };
            dateColumn.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            grid.Columns.Add(dateColumn);

            // Details column
            DataGridViewTextBoxColumn detailsColumn = new DataGridViewTextBoxColumn
            {
                Name = "details",
                DataPropertyName = "details",
                HeaderText = "Chi tiết",
                Width = 250,
                ReadOnly = true
            };
            grid.Columns.Add(detailsColumn);

            // Set grid properties
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
        }

        private void UpdateSummary(DataTable dataTable)
        {
            decimal totalAmount = 0;
            int totalCount = dataTable.Rows.Count;
            int moneyContributions = 0;
            int otherContributions = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["amount"] != DBNull.Value)
                {
                    totalAmount += Convert.ToDecimal(row["amount"]);
                }

                string type = row["contribution_type"]?.ToString();
                if (type == "Tiền")
                    moneyContributions++;
                else
                    otherContributions++;
            }

            string summaryText = eventId > 0 
                ? $"Đóng góp cho sự kiện '{eventName}': {totalCount} | Tiền: {moneyContributions} ({totalAmount:N0} VNĐ) | Khác: {otherContributions}"
                : $"Tổng: {totalCount} đóng góp | Tiền: {moneyContributions} ({totalAmount:N0} VNĐ) | Khác: {otherContributions}";

            lbl_summary.Text = summaryText;
        }

        // Static method for user contributions (all events)
        public static void ShowUserContributions(int csvId, string userName = "")
        {
            contribute_view form = new contribute_view(csvId, userName);
            form.ShowDialog();
        }

        // New static method for event-specific contributions
        public static void ShowUserContributionsForEvent(int csvId, string userName, int eventId, string eventName)
        {
            contribute_view form = new contribute_view(csvId, userName, eventId, eventName);
            form.ShowDialog();
        }

        // Static method to show all contributions
        public static void ShowAllContributions()
        {
            contribute_view form = new contribute_view();
            form.ShowDialog();
        }
    }
}
