using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Coordinator_master (Name, Mobile_No, Alternate_Mobile_No,Address,City,Email,Area_Under,Active,CreatedAt) VALUES (@Name, @Mobile_No, @Alternate_Mobile_No,@Address,@City,@Email,@Area_Under,@Active,@CreatedAt)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", coordinator.Name);
                cmd.Parameters.AddWithValue("@Mobile_No", coordinator.Mobile_No);
                cmd.Parameters.AddWithValue("@Alternate_Mobile_No", coordinator.Alternate_Mobile_No);
                cmd.Parameters.AddWithValue("@Address", coordinator.Address);
                cmd.Parameters.AddWithValue("@City", coordinator.City);
                cmd.Parameters.AddWithValue("@Email", coordinator.Email);
                cmd.Parameters.AddWithValue("@Area_Under", coordinator.Area_Under);
                cmd.Parameters.AddWithValue("@Active", coordinator.Active);
                cmd.Parameters.AddWithValue("@CreatedAt", coordinator.CreatedAt);
               
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
        public List<Coordinator> GetAllCoordinator()
        {
            List<Coordinator> coordinator = new List<Coordinator>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT CM.ID, Name, Mobile_No, Alternate_Mobile_No, [Address], City, Email, Area_Under, AM.Area_name , Active, CreatedAt 
                                    from Coordinator_master CM
                                    INNER JOIN Area_Master AM ON AM.ID=Cm.Area_Under Where CM.Active='true'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        coordinator.Add(new Coordinator
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            Mobile_No = reader["Mobile_No"].ToString(),
                            Alternate_Mobile_No = reader["Alternate_Mobile_No"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            Email = reader["Email"].ToString(),
                            Area_Under = Convert.ToInt32(reader["Area_Under"]),
                            AreaName = reader["Area_name"].ToString(),
                            //Active = reader.GetBoolean(8),
                        });
                    }
                }
            }
            return coordinator;
        }
        public Coordinator GetCoordinatorById(int id)
        {
            Coordinator coordinator = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Coordinator_master WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        coordinator = new Coordinator
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            Mobile_No = reader["Mobile_No"].ToString(),
                            Alternate_Mobile_No = reader["Alternate_Mobile_No"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            Email = reader["Email"].ToString(),
                            Area_Under = Convert.ToInt32(reader["Area_Under"]),
                            Active = Convert.ToBoolean(reader["Active"])
                        };
                    }
                }
            }
            return coordinator;
        }
        public bool UpdateArea(Coordinator coordinator)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Coordinator_master SET Name = @Name, Mobile_No = @Mobile_No, Alternate_Mobile_No = @Alternate_Mobile_No,Address=@Address,City=@City,Email=@Email,Area_Under=@Area_Under,Active=@Active WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", coordinator.Id);
                cmd.Parameters.AddWithValue("@Name", coordinator.Name);
                cmd.Parameters.AddWithValue("@Mobile_No", coordinator.Mobile_No);
                cmd.Parameters.AddWithValue("@Alternate_Mobile_No", coordinator.Alternate_Mobile_No);
                cmd.Parameters.AddWithValue("@Email", coordinator.Email);
                cmd.Parameters.AddWithValue("@Area_Under", coordinator.Area_Under);
                cmd.Parameters.AddWithValue("@Address", coordinator.Address);
                cmd.Parameters.AddWithValue("@City", coordinator.City);
                cmd.Parameters.AddWithValue("@Active", coordinator.Active);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
        public bool DeleteCoordinator(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "Update Coordinator_master Set Active = 0 WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
        }


    }
}













































//using Microsoft.Data.SqlClient;
//using SewaPatra.Models;

//namespace SewaPatra.DataAccess
//{
//    public class CoordinatorRepository
//    {
//        private readonly string _connectionString;

//        public CoordinatorRepository(IConfiguration configuration)
//        {
//            _connectionString = configuration.GetConnectionString("DefaultConnection");
//        }
//        public bool InsertCoordinator(Coordinator coordinator) 
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            {
//                string sql = @"INSERT INTO Coordinator (Name, Address, City, Mobile_No, Alt_Mobile_no, Email, Area, location, Active) 
//                                VALUES (@Name, @Address, @City, @Mobile_No, @Alt_Mobile_no, @Email, @Area, @location, @Active)";
//                SqlCommand cmd = new SqlCommand(sql, connection);
//                cmd.Parameters.AddWithValue("@Name", coordinator.Name);
//                cmd.Parameters.AddWithValue("@Address", coordinator.Address);
//                cmd.Parameters.AddWithValue("@City", coordinator.City);
//                cmd.Parameters.AddWithValue("@Mobile_No", coordinator.Mobile_No);
//                cmd.Parameters.AddWithValue("@Alt_Mobile_no", coordinator.Alt_Mobile_no);
//                cmd.Parameters.AddWithValue("@Email", coordinator.Email);
//                cmd.Parameters.AddWithValue("@Area", coordinator.Area);
//                cmd.Parameters.AddWithValue("@location", coordinator.location);
//                cmd.Parameters.AddWithValue("@Active", coordinator.Active);
//                connection.Open();
//                int count = cmd.ExecuteNonQuery();
//                connection.Close();
//                return count > 0;
//            }
//        }
//    }
//}
