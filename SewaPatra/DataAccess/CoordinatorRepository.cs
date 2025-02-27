using Microsoft.Data.SqlClient;
using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class CoordinatorRepository
    {
        private readonly string _connectionString;

        public CoordinatorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool InsertCoordinator(Coordinator coordinator) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Coordinator (Name, Address, City, Mobile_No, Alt_Mobile_no, Email, Area, location, Active) 
                                VALUES (@Name, @Address, @City, @Mobile_No, @Alt_Mobile_no, @Email, @Area, @location, @Active)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Name", coordinator.Name);
                cmd.Parameters.AddWithValue("@Address", coordinator.Address);
                cmd.Parameters.AddWithValue("@City", coordinator.City);
                cmd.Parameters.AddWithValue("@Mobile_No", coordinator.Mobile_No);
                cmd.Parameters.AddWithValue("@Alt_Mobile_no", coordinator.Alt_Mobile_no);
                cmd.Parameters.AddWithValue("@Email", coordinator.Email);
                cmd.Parameters.AddWithValue("@Area", coordinator.Area);
                cmd.Parameters.AddWithValue("@location", coordinator.location);
                cmd.Parameters.AddWithValue("@Active", coordinator.Active);
                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count > 0;
            }
        }
    }
}
