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
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Donor_Master (Mobile_No,Name,Address,City,Mobile_no2,Email,Area,Coordinator,Location,Active) VALUES (@Mobile_No, @Name,@Address,@City,@Mobile_no2,@Email,@Area,@Coordinator,@Location,@Active)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Mobile_No", donor.Mobile_No);
                cmd.Parameters.AddWithValue("@Name", donor.Name);
                cmd.Parameters.AddWithValue("@Address", donor.Address);
                cmd.Parameters.AddWithValue("@City", donor.City);
                cmd.Parameters.AddWithValue("@Mobile_no2", donor.Mobile_no2);
                cmd.Parameters.AddWithValue("@Email", donor.Email);
                cmd.Parameters.AddWithValue("@Area", donor.Area);
                cmd.Parameters.AddWithValue("@Coordinator", donor.Coordinator);
                cmd.Parameters.AddWithValue("@Location", donor.Location);
                cmd.Parameters.AddWithValue("@Active", donor.Active);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
        public List<Donor> GetAllDonor()
        {
            List<Donor> donors = new List<Donor>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT *from Donor_Master";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        donors.Add(new Donor
                        {
                            Id = reader.GetInt32(0),
                            Mobile_No = reader.GetString(1),
                            Name = reader.GetString(2),
                            Address = reader.GetString(3),
                            City = reader.GetString(4),
                            Mobile_no2 = reader.GetString(5),
                            Email = reader.GetString(6),
                            Area = reader.GetInt32(7),
                            Coordinator = reader.GetInt32(8),
                            Location = reader.GetString(9),
               
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
                            Id = reader.GetInt32(0),
                            Mobile_No = reader.GetString(1),
                            Name = reader.GetString(2),
                            Address = reader.GetString(3),
                            City = reader.GetString(4),
                            Mobile_no2 = reader.GetString(5),
                            Email = reader.GetString(6),
                            Area = reader.GetInt32(7),
                            Coordinator = reader.GetInt32(8),
                            Location = reader.GetString(9),

                            // Active = reader.GetBoolean(10),
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
                string query = "UPDATE Donor_Master SET Mobile_no = @Mobile_no,Name = @Name,Address = @Address,City = @City,Mobile_no2 = @Mobile_no2,Email = @Email,Area = @Area,Coordinator = @Coordinator,Location = @Location, Active = @Active WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Mobile_No", donor.Mobile_No);
                cmd.Parameters.AddWithValue("@Name", donor.Name);
                cmd.Parameters.AddWithValue("@Address", donor.Address);
                cmd.Parameters.AddWithValue("@City", donor.City);
                cmd.Parameters.AddWithValue("@Mobile_no2", donor.Mobile_no2);
                cmd.Parameters.AddWithValue("@Email", donor.Email);
                cmd.Parameters.AddWithValue("@Area", donor.Area);
                cmd.Parameters.AddWithValue("@Coordinator", donor.Coordinator);
                cmd.Parameters.AddWithValue("@Location", donor.Location);
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
                string query = "Delete from Donoe_Master WHERE Id = @Id";
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
