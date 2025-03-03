using Microsoft.Data.SqlClient;
using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class ReceiptVoucherRepository
    {
        private readonly string _connectionString;
        public ReceiptVoucherRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool InsertReceiptVoucher(ReceiptVoucher receiptVoucher)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO ReceiptVoucher (R_TranId, Date, Sewapatra_No, Donor, Coordinator, Amount, Next_DueDate, Remarks) 
                                 VALUES (@R_TranId,@Date,@Sewapatra_No,@Donor,@Coordinator,@Amount,@NextDueDate,@remarks)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@R_TranId", receiptVoucher.R_TranId);
                cmd.Parameters.AddWithValue("@Date", receiptVoucher.Date);
                cmd.Parameters.AddWithValue("@Sewapatra_No", receiptVoucher.Sewapatra_No);
                cmd.Parameters.AddWithValue("@Donor", receiptVoucher.Donor);
                cmd.Parameters.AddWithValue("@Coordinator", receiptVoucher.Coordinator);
                cmd.Parameters.AddWithValue("@Amount", receiptVoucher.Amount);
                cmd.Parameters.AddWithValue("@NextDueDate", receiptVoucher.Next_DueDate);
                cmd.Parameters.AddWithValue("@remarks", receiptVoucher.Remarks);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
        public List<ReceiptVoucher> GetAllReceiptVoucher()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM ReceiptVoucher";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ReceiptVoucher> receiptVouchers = new List<ReceiptVoucher>();
                if (reader.Read())
                {
                    receiptVouchers.Add(new ReceiptVoucher
                    {
                        R_TranId = reader["R_TranId"].ToString(),
                        Date = Convert.ToDateTime(reader["Date"]),
                        Sewapatra_No = Convert.ToInt32(reader["Sewapatra_No"]),
                        Donor = Convert.ToInt32(reader["Donor"]),
                        Coordinator = Convert.ToInt32(reader["Coordinator"]),
                        Amount = reader["Amount"].ToString(),
                        Next_DueDate = reader["Next_DueDate"].ToString(),
                        Remarks = reader["Remarks"].ToString()  
                    });
                }
                conn.Close();
                return receiptVouchers;
            }
        }
    }
}
