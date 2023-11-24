using System.Data.SqlClient;
namespace Shafa_Al_Firdaus_API.Models
{
    public class DkmRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public DkmRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<DkmModel> getAllData()
        {
            List<DkmModel> anggotaList = new List<DkmModel>();

            try
            {
                string query = "SELECT * FROM dkm";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DkmModel anggota = new DkmModel
                    {
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString()
                    };
                    anggotaList.Add(anggota);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return anggotaList;
        }

        public DkmModel getData(string username)
        {
            DkmModel anggotaModel = new DkmModel();
            try
            {
                string query = "SELECT * FROM dkm WHERE username = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", username);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                
                anggotaModel.username = reader["username"].ToString();
                anggotaModel.password = reader["password"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return anggotaModel;
        }

        /*public void insertData(DkmModel dkmModel)
        {
            try
            {
                string query = "INSERT INTO dkm VALUES (@p1, @p2)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", dkmModel.username);
                command.Parameters.AddWithValue("@p2", dkmModel.password);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }*/

        public void updateData(DkmModel dkmModel)
        {
            try
            {
                string query = "UPDATE dkm SET password = @p2 WHERE username = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", dkmModel.username);
                command.Parameters.AddWithValue("@p2", dkmModel.password);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /*public void deleteData(string username)
        {
            try
            {
                string query = "DELETE FROM dkm WHERE username = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", username);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }*/
    }
}
