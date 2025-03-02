using Microsoft.Data.SqlClient;
using SewaPatra.BusinessLayer;
using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class PaymentVoucherRepository
    {
        private readonly string _connectionString;
        public PaymentVoucherRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool InsertPaymentVoucher(PaymentVoucher paymentVoucher)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO PaymentVoucher (P_TranId, Date, Ledger_Name, Coordinator, Amount, Remarks) 
                                 VALUES (@P_TranId,@Date,@Ledger_Name,@Coordinator,@Amount,@remarks)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@P_TranId", paymentVoucher.P_TranId);
                cmd.Parameters.AddWithValue("@Date", paymentVoucher.Date);
                cmd.Parameters.AddWithValue("@Ledger_Name", paymentVoucher.Ledger_Name);
                cmd.Parameters.AddWithValue("@Coordinator", paymentVoucher.Coordinator);
                cmd.Parameters.AddWithValue("@Amount", paymentVoucher.Amount);
                cmd.Parameters.AddWithValue("@Remarks", paymentVoucher.Remarks);            
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
        public List<PaymentVoucher> GetAllPaymentVoucher()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM PaymentVoucher";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<PaymentVoucher> paymentVouchers = new List<PaymentVoucher>();
                if (reader.Read())
                {
                    paymentVouchers.Add(new PaymentVoucher
                    {
                        P_TranId = reader["P_TranId"].ToString(),
                        Date = Convert.ToDateTime(reader["Date"]),
                        Ledger_Name = reader["Ledger_Name"].ToString(),
                        Coordinator = Convert.ToInt32(reader["Coordinator"]),
                        Amount = reader["Amount"].ToString(),
                        Remarks = reader["Remarks"].ToString()
                    });
                }
                conn.Close();
                return paymentVouchers;
            }
        }
        public PaymentVoucher GetAllPaymentVoucherById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM PaymentVoucher WHERE P_TranId = @P_TranId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@P_TranId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                PaymentVoucher paymentVoucher = new PaymentVoucher();
                if (reader.Read())
                {
                    paymentVoucher.P_TranId = reader["P_TranId"].ToString();
                    paymentVoucher.Date = Convert.ToDateTime(reader["Date"]);
                    paymentVoucher.Ledger_Name = reader["Ledger_Name"].ToString();
                    paymentVoucher.Coordinator = Convert.ToInt32(reader["Coordinator"]);
                    paymentVoucher.Amount = reader["Amount"].ToString();
                    paymentVoucher.Remarks = reader["Remarks"].ToString();
                }
                conn.Close();
                return paymentVoucher;
            }
        }
        public bool UpdatePaymentVoucher(PaymentVoucher paymentVoucher)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE PaymentVoucher SET Date = @Date, Ledger_Name = @Ledger_Name, Coordinator = @Coordinator, Amount = @Amount, Remarks = @Remarks WHERE P_TranId = @P_TranId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@P_TranId", paymentVoucher.P_TranId);
                cmd.Parameters.AddWithValue("@Date", paymentVoucher.Date);
                cmd.Parameters.AddWithValue("@Ledger_Name", paymentVoucher.Ledger_Name);
                cmd.Parameters.AddWithValue("@Coordinator", paymentVoucher.Coordinator);
                cmd.Parameters.AddWithValue("@Amount", paymentVoucher.Amount);
                cmd.Parameters.AddWithValue("@Remarks", paymentVoucher.Remarks);                     
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
        public bool DeletePaymentVoucher(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"DELETE FROM PaymentVoucher WHERE P_TranId = @P_TranId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@P_TranId", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
    }
}
