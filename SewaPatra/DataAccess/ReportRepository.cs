using Microsoft.Data.SqlClient;
using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class ReportRepository
    {
        private readonly string _connectionString;
        public ReportRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public List<DonorReport> GetDonorReport()
        {
            List<DonorReport> donor = new List<DonorReport>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "Select DM.*,CM.Name AS [Coordinator Name],AM.Area_name from Donor_master DM " +
                    "Inner Join Area_Master AM On Am.ID=Dm.Area Inner Join Coordinator_master CM ON CM.ID=DM.Coordinator";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        donor.Add(new DonorReport
                        {
                            Id = reader.GetInt32(0),
                            Mobile_no = reader.GetString(1),
                            Name = reader.GetString(2),
                            Address = reader.GetString(3),
                            City = reader.GetString(4),
                            // Mobile_no2 = reader.GetString(5),
                            Email = reader.GetString(6),
                            Area = reader.GetString(7),
                            Coordinator = reader.GetString(8),
                            Location = reader.GetString(9),
                            Active = reader.GetString(10),
                            Coordinator_Name = reader.GetString(11),
                            Area_name = reader.GetString(3),
                        });
                    }
                }
            }
            return donor;
        }
    }
}