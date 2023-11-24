using System.Data.SqlClient;

namespace Shafa_Al_Firdaus_API.Models
{
    public class PetugasHarianRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public PetugasHarianRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<PetugasHarianModel> getAllData()
        {
            List<PetugasHarianModel> petugasList = new List<PetugasHarianModel>();

            try
            {
                string query = "SELECT * FROM petugas_harian";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PetugasHarianModel petugas = new PetugasHarianModel
                    {
                        nim = reader["nim"].ToString(),
                        nama = reader["nama"].ToString(),
                        prodi = Convert.ToInt32(reader["prodi"].ToString()),
                        nomor_telepon = reader["nomor_telepon"].ToString(),
                        status = Convert.ToInt32(reader["status"].ToString())
                    };
                    petugasList.Add(petugas);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return petugasList;
        }

        public PetugasHarianModel getData(string nim)
        {
            PetugasHarianModel petugasModel = new PetugasHarianModel();
            try
            {
                string query = "SELECT * FROM petugas_harian WHERE nim = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", nim);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                petugasModel.nim = reader["nim"].ToString();
                petugasModel.nama = reader["nama"].ToString();
                petugasModel.prodi = Convert.ToInt32(reader["prodi"].ToString());
                petugasModel.nomor_telepon = reader["nomor_telepon"].ToString();
                petugasModel.status = Convert.ToInt32(reader["status"].ToString());

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return petugasModel;
        }

        public void insertData(PetugasHarianModel petugasHarianModel)
        {
            try
            {
                string query = "INSERT INTO petugas_harian VALUES (@p1, @p2, @p3, @p4, @p5)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", petugasHarianModel.nim);
                command.Parameters.AddWithValue("@p2", petugasHarianModel.nama);
                command.Parameters.AddWithValue("@p3", petugasHarianModel.prodi);
                command.Parameters.AddWithValue("@p4", petugasHarianModel.nomor_telepon);
                command.Parameters.AddWithValue("@p5", petugasHarianModel.status);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void updateData(PetugasHarianModel petugasHarianModel)
        {
            try
            {
                string query = "UPDATE petugas_harian SET nama = @p2, prodi = @p3, nomor_telepon = @p4, status = @p5 WHERE nim = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", petugasHarianModel.nim);
                command.Parameters.AddWithValue("@p2", petugasHarianModel.nama);
                command.Parameters.AddWithValue("@p3", petugasHarianModel.prodi);
                command.Parameters.AddWithValue("@p4", petugasHarianModel.nomor_telepon);
                command.Parameters.AddWithValue("@p5", petugasHarianModel.status);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteData(string nim)
        {
            try
            {
                string query = "DELETE FROM petugas_harian WHERE nim = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", nim);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
