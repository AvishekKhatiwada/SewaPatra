using Microsoft.Data.SqlClient;
using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class DonationBoxRepository
    {
        private readonly string _connectionString;

        public DonationBoxRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public bool InsertDonationBox(DonationBox donationBox)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO DonationBox (Box_Number, Active) VALUES (@Box_Number, @Active)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Box_Number", donationBox.Box_Number);
                cmd.Parameters.AddWithValue("@Active", donationBox.Active);              

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
        public List<DonationBox> GetAllDonationBox()
        {
            List<DonationBox> donationBoxes = new List<DonationBox>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * from DonationBox";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        donationBoxes.Add(new DonationBox
                        {
                            Id = reader.GetInt32(0),
                            Box_Number = reader.GetString(1),
                            //Active = reader.GetBoolean(8),


                        });
                    }
                }
            }
            return donationBoxes;
        }
        public DonationBox GetDonationBoxById(int id)
        {
            DonationBox donationBox = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM DonationBox WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        donationBox = new DonationBox
                        {
                            Id = reader.GetInt32(0),
                            Box_Number = reader.GetString(1),
                            //Active = reader.GetBoolean(8),
                        };
                    }
                }
            }
            return donationBox;
        }
        public bool UpdateDonationBox(DonationBox donationBox)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE DonationBox SET Box_Number = @Box_Number, Active = @Active WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", donationBox.Id);
                cmd.Parameters.AddWithValue("@Box_Number", donationBox.Box_Number);
                cmd.Parameters.AddWithValue("@Active", donationBox.Active);
                


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
                string query = "Delete from DonationBox WHERE Id = @Id";
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
