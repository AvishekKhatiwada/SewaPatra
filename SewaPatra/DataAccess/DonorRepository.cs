using Microsoft.Data.SqlClient;
using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class DonorRepository
    {
        private readonly string _connectionString;
        public DonorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool InsertDonor(Donor donor)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Donor_Master (Mobile_No,Name,Address,City,Mobile_no2,Email,Area,Coordinator,Active) VALUES (@Mobile_No, @Name,@Address,@City,@Mobile_no2,@Email,@Area,@Coordinator,@Active)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Mobile_No", donor.Mobile_No);
                    cmd.Parameters.AddWithValue("@Name", donor.Name);
                    cmd.Parameters.AddWithValue("@Address", donor.Address);
                    cmd.Parameters.AddWithValue("@City", donor.City);
                    cmd.Parameters.AddWithValue("@Mobile_no2", donor.Mobile_no2);
                    cmd.Parameters.AddWithValue("@Email", donor.Email);
                    cmd.Parameters.AddWithValue("@Area", donor.Area);
                    cmd.Parameters.AddWithValue("@Coordinator", donor.Coordinator);
                    //cmd.Parameters.AddWithValue("@Location", donor.Location);
                    cmd.Parameters.AddWithValue("@Active", donor.Active);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public List<Donor> GetAllDonor()
        {
            List<Donor> donors = new List<Donor>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT DM.Id, DM.Mobile_no, DM.Name, DM.Address, DM.City, Mobile_no2, DM.Email, Area, Coordinator, Location, DM.Active, AM.Area_name, CM.Name AS CoordinatorName
                                    from Donor_Master DM
                                    INNER JOIN Area_Master AM ON AM.ID=Dm.Area
                                    INNER JOIN Coordinator_master CM ON CM.ID=DM.Coordinator
                                    WHERE DM.Active='true'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        donors.Add(new Donor
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Mobile_No = reader["Mobile_No"].ToString(),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            Mobile_no2 = reader["Mobile_No2"].ToString(),
                            Email = reader["Email"].ToString(),
                            AreaName = reader["Area_name"].ToString(),
                            //Location = reader["Location"].ToString(),
                            CoordinatorName = reader["CoordinatorName"].ToString(),
                            Area = Convert.ToInt32(reader["Area"]),
                            Coordinator = Convert.ToInt32(reader["Coordinator"])
                            //Location = reader.GetString(9),               
                            // Active = reader.GetBoolean(10),


                        });
                    }
                }
            }
            return donors;
        }
        public Donor GetDonorById(int id)
        {
            Donor donor = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Donor_Master WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        donor = new Donor
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Mobile_No = reader["Mobile_No"].ToString(),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            Mobile_no2 = reader["Mobile_No2"].ToString(),
                            Email = reader["Email"].ToString(),                            
                            Area = Convert.ToInt32(reader["Area"]),
                            Coordinator = Convert.ToInt32(reader["Coordinator"]),
                            Active = Convert.ToBoolean(reader["Active"])
                        };
                    }
                }
            }
            return donor;
        }
        public bool UpdateDonor(Donor donor)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Donor_Master SET Mobile_no = @Mobile_no,Name = @Name,Address = @Address,City = @City,Mobile_no2 = @Mobile_no2,Email = @Email,Area = @Area,Coordinator = @Coordinator, Active = @Active WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", donor.Id);
                cmd.Parameters.AddWithValue("@Mobile_No", donor.Mobile_No);
                cmd.Parameters.AddWithValue("@Name", donor.Name);
                cmd.Parameters.AddWithValue("@Address", donor.Address);
                cmd.Parameters.AddWithValue("@City", donor.City);
                cmd.Parameters.AddWithValue("@Mobile_no2", donor.Mobile_no2);
                cmd.Parameters.AddWithValue("@Email", donor.Email);
                cmd.Parameters.AddWithValue("@Area", donor.Area);
                cmd.Parameters.AddWithValue("@Coordinator", donor.Coordinator);
                //cmd.Parameters.AddWithValue("@Location", donor.Location);
                cmd.Parameters.AddWithValue("@Active", donor.Active);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
        }
        public bool DeleteDonor(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "Update Donor_master Set Active = 0 WHERE Id = @Id";
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
