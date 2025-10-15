using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace qly_csv_app.Repository
{
    internal class dangNhap
    {
        public string connectString = ConfigurationManager.ConnectionStrings["sa"].ConnectionString;
        
        public string KiemTraDangNhap(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                string query = @"SELECT role_type 
                                FROM [User] 
                                WHERE username = @username AND password = @password AND is_active = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result?.ToString(); // Trả về role_type hoặc null nếu không tìm thấy
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi kết nối hoặc truy vấn
                    Console.WriteLine("Lỗi kết nối hoặc truy vấn: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
