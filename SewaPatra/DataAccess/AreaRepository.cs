using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class AreaRepository
    {
        private readonly string _connectionString;

        public AreaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool InsertArea(Area area)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Area_Master (Area_name, Area_type, Under) VALUES (@Area_name, @Area_type, @Under)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Area_name", area.Area_name);
                cmd.Parameters.AddWithValue("@Area_type", area.Area_type);
                cmd.Parameters.AddWithValue("@Under", area.Under);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
        public List<Area> GetAllAreas()
        {
            List<Area> areas = new List<Area>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Area_name, Area_type, Under FROM Area_Master";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        areas.Add(new Area
                        {
                            Id = reader.GetInt32(0),
                            Area_name = reader.GetString(1),
                            Area_type = reader.GetString(2),
                            Under = reader.GetString(3)
                        });
                    }
                }
            }
            return areas;
        }
        public Area GetAreaById(int id)
        {
            Area area = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Area_name, Area_type, Under FROM Area_Master WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        area = new Area
                        {
                            Id = reader.GetInt32(0),
                            Area_name = reader.GetString(1),
                            Area_type = reader.GetString(2),
                            Under = reader.GetString(3)
                        };
                    }
                }
            }
            return area;
        }
        public bool UpdateArea(Area area)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Area_Master SET Area_name = @Area_name, Area_type = @Area_type, Under = @Under WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", area.Id);
                cmd.Parameters.AddWithValue("@Area_name", area.Area_name);
                cmd.Parameters.AddWithValue("@Area_type", area.Area_type);
                cmd.Parameters.AddWithValue("@Under", area.Under);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
        }
        public bool DeleteArea(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Area_Master WHERE Id = @Id";
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
