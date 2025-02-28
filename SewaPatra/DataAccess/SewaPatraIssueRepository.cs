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
    }
}
