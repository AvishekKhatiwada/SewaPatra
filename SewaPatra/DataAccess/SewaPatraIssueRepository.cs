using Microsoft.Data.SqlClient;
using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class SewaPatraIssueRepository
    {
        private readonly string _connectionString;
        public SewaPatraIssueRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool InsertSewaPatraIssue(SewaPatraIssue sewaPatraIssue)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO SewaPatraIssue (TranId, Entered_Date, Donor, Coordinator, DonationBox, Issue_Date, Recurring, Due_Date, Remarks) 
                                 VALUES (@TranId,@EnteredDate,@Donor,@Coordinator,@DonationBox,@IssueDate,@recurring,@DueDate,@remarks)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TranId", sewaPatraIssue.TranId);
                cmd.Parameters.AddWithValue("@EnteredDate", sewaPatraIssue.Entered_Date);
                cmd.Parameters.AddWithValue("@Donor", sewaPatraIssue.Donor);
                cmd.Parameters.AddWithValue("@Coordinator", sewaPatraIssue.Coordinator);
                cmd.Parameters.AddWithValue("@DonationBox", sewaPatraIssue.DonationBox);
                cmd.Parameters.AddWithValue("@IssueDate", sewaPatraIssue.Issue_Date);
                cmd.Parameters.AddWithValue("@recurring", sewaPatraIssue.Recurring);
                cmd.Parameters.AddWithValue("@DueDate", sewaPatraIssue.Due_Date);
                cmd.Parameters.AddWithValue("@remarks", sewaPatraIssue.Remarks);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
        public List<SewaPatraIssue> GetAllSewaPatraIssue()
        {
            List<SewaPatraIssue> sewaPatraIssue = new List<SewaPatraIssue>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT TranId, Entered_Date, SPI.Donor As DonorId,DM.Name As DonorName,DMA.Area_name As DonorArea, SPI.Coordinator As CoordinatorId,CM.Name As CoordinatorName,CMA.Area_name As CoordinatorArea, 
                                    DonationBox As BoxId,Db.Box_Number As DonationBox,Issue_Date As IssueDate, Recurring, Due_Date As DueDate, Remarks 
                                    FROM SewaPatraIssue SPI
                                    INNER JOIN Donor_master DM ON DM.Id=SPI.Donor
                                    INNER Join Area_Master DMA ON DM.Area=DMA.Id
                                    INNER JOIN Coordinator_master CM ON CM.Id=SPI.Coordinator
                                    INNER JOIN Area_Master CMA ON CM.Area_Under=CMA.Id 
                                    INNER JOIN DonationBox DB ON Db.Id=SPI.DonationBox
                                    WHERE 1=1 ORDER BY Entered_Date";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sewaPatraIssue.Add(new SewaPatraIssue
                        {
                            TranId = reader["TranId"].ToString(),
                            Entered_Date = Convert.ToDateTime(reader["Entered_Date"]),
                            Donor = Convert.ToInt32(reader["DonorId"]),
                            Coordinator = Convert.ToInt32(reader["CoordinatorId"]),
                            DonationBox = Convert.ToInt32(reader["BoxId"]),
                            Issue_Date = Convert.ToDateTime(reader["IssueDate"]),
                            Recurring = reader["Recurring"].ToString(),
                            Due_Date = Convert.ToDateTime(reader["DueDate"]),
                            Remarks = reader["Remarks"].ToString(),
                            DonorName = reader["DonorName"].ToString(),
                            Coordinatorname = reader["CoordinatorName"].ToString(),
                            DonationBoxName = reader["DonationBox"].ToString()
                        });
                    }
                }
                conn.Close();
                return sewaPatraIssue;
            }
        }
        public SewaPatraIssue GetSewaPatraIssueById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM SewaPatraIssue WHERE TranId = @TranId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TranId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                SewaPatraIssue sewaPatraIssue = new SewaPatraIssue();
                if (reader.Read())
                {
                    sewaPatraIssue.TranId = reader["TranId"].ToString();
                    sewaPatraIssue.Entered_Date = Convert.ToDateTime(reader["Entered_Date"]);
                    sewaPatraIssue.Donor = Convert.ToInt32(reader["Donor"]);
                    sewaPatraIssue.Coordinator = Convert.ToInt32(reader["Coordinator"]);
                    sewaPatraIssue.DonationBox = Convert.ToInt32(reader["DonationBox"]);
                    sewaPatraIssue.Issue_Date = Convert.ToDateTime(reader["Issue_Date"]);
                    sewaPatraIssue.Recurring = reader["Recurring"].ToString();
                    sewaPatraIssue.Due_Date = Convert.ToDateTime(reader["Due_Date"]);
                    sewaPatraIssue.Remarks = reader["Remarks"].ToString();
                }
                conn.Close();
                return sewaPatraIssue;
            }
        }
        public bool UpdateSewaPatraIssue(SewaPatraIssue sewaPatraIssue)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE SewaPatraIssue SET Entered_Date = @EnteredDate, Donor = @Donor, Coordinator = @Coordinator, DonationBox = @DonationBox, Issue_Date = @IssueDate, Recurring = @recurring, Due_Date = @DueDate, Remarks = @remarks WHERE TranId = @TranId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TranId", sewaPatraIssue.TranId);
                cmd.Parameters.AddWithValue("@EnteredDate", sewaPatraIssue.Entered_Date);
                cmd.Parameters.AddWithValue("@Donor", sewaPatraIssue.Donor);
                cmd.Parameters.AddWithValue("@Coordinator", sewaPatraIssue.Coordinator);
                cmd.Parameters.AddWithValue("@DonationBox", sewaPatraIssue.DonationBox);
                cmd.Parameters.AddWithValue("@IssueDate", sewaPatraIssue.Issue_Date);
                cmd.Parameters.AddWithValue("@recurring", sewaPatraIssue.Recurring);
                cmd.Parameters.AddWithValue("@DueDate", sewaPatraIssue.Due_Date);
                cmd.Parameters.AddWithValue("@remarks", sewaPatraIssue.Remarks);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
        public bool DeleteSewaPatraIssue(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"DELETE FROM SewaPatraIssue WHERE TranId = @TranId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TranId", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
    }
}
