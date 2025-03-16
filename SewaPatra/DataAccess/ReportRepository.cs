using Microsoft.Data.SqlClient;
using SewaPatra.Models;
using SewaPatra.Models.ReportModels;

namespace SewaPatra.DataAccess
{
    public class ReportRepository
    {
        private readonly string _connectionString;
        public ReportRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public List<SewaPatraIssueRegister> GetSewaPatraIssueRegister()
        {
            List<SewaPatraIssueRegister> sewaPatraIssueRegister = new List<SewaPatraIssueRegister>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT TranId, CONVERT(VARCHAR(10),Entered_Date,103) As [Date], SPI.Donor As DonorId,DM.Name As DonorName,DMA.Area_name As DonorArea, SPI.Coordinator As CoordinatorId,CM.Name As CoordinatorName,CMA.Area_name As CoordinatorArea, 
                                    DonationBox As BoxId,Db.Box_Number As DonationBox,CONVERT(VARCHAR(10),Issue_Date,103) As IssueDate, Recurring, Due_Date As DueDate, Remarks 
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
                        sewaPatraIssueRegister.Add(new SewaPatraIssueRegister
                        {
                            TranId = reader["TranId"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"]).ToString("dd/MM/yyyy"),
                            DonorId = Convert.ToInt32(reader["DonorId"]),
                            DonorName = reader["DonorName"].ToString(),
                            DonorArea = reader["DonorArea"].ToString(),
                            CoordinatorId = Convert.ToInt32(reader["CoordinatorId"]),
                            CoordinatorName = reader["CoordinatorName"].ToString(),
                            CoordinatorArea = reader["CoordinatorArea"].ToString(),
                            BoxId = reader["BoxId"].ToString(),
                            DonationBox = reader["DonationBox"].ToString(),
                            IssueDate = Convert.ToDateTime(reader["IssueDate"]).ToString("dd/MM/yyyy"),
                            Recurring = reader["Recurring"].ToString(),
                            DueDate = Convert.ToDateTime(reader["DueDate"]).ToString("dd/MM/yyyy"),
                            Remarks = reader["Remarks"].ToString()
                        });
                    }
                }
            }
            return sewaPatraIssueRegister;
        }
    }
}