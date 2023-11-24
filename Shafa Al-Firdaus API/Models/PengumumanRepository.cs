using System.Data.SqlClient;

namespace Shafa_Al_Firdaus_API.Models
{
    public class PengumumanRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public PengumumanRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<PengumumanModel> getAllData()
        {
            List<PengumumanModel> pengumumanList = new List<PengumumanModel>();

            try
            {
                string query = "SELECT * FROM pengumuman";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PengumumanModel petugas = new PengumumanModel
                    {
                        id_pengumuman = Guid.Parse(reader["id_pengumuman"].ToString()),
                        judul = reader["judul"].ToString(),
                        jenis = Convert.ToInt32(reader["jenis"].ToString()),
                        isi = reader["isi"].ToString(),
                        tanggal_mulai = Convert.ToDateTime(reader["tanggal_mulai"].ToString()),
                        tanggal_selesai = Convert.ToDateTime(reader["tanggal_selesai"].ToString())

                    };
                    pengumumanList.Add(petugas);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pengumumanList;
        }

        public PengumumanModel getData(string id_pengumuman)
        {
            PengumumanModel jadwalModel = new PengumumanModel();
            try
            {
                string query = "SELECT * FROM pengumuman WHERE id_pengumuman = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_pengumuman);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                jadwalModel.id_pengumuman = Guid.Parse(reader["id_pengumuman"].ToString());
                jadwalModel.judul = reader["judul"].ToString();
                jadwalModel.jenis = Convert.ToInt32(reader["jenis"].ToString());
                jadwalModel.isi = reader["isi"].ToString();
                jadwalModel.tanggal_mulai = Convert.ToDateTime(reader["tanggal_mulai"].ToString());
                jadwalModel.tanggal_selesai = Convert.ToDateTime(reader["tanggal_selesai"].ToString());

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return jadwalModel;
        }

        public void insertData(PengumumanModel pengumumanModel)
        {
            try
            {
                string query = "INSERT INTO pengumuman VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", pengumumanModel.id_pengumuman);
                command.Parameters.AddWithValue("@p2", pengumumanModel.judul);
                command.Parameters.AddWithValue("@p3", pengumumanModel.jenis);
                command.Parameters.AddWithValue("@p4", pengumumanModel.isi);
                command.Parameters.AddWithValue("@p5", pengumumanModel.tanggal_mulai);
                command.Parameters.AddWithValue("@p6", pengumumanModel.tanggal_selesai);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void updateData(PengumumanModel pengumumanModel)
        {
            try
            {
                string query = "UPDATE pengumuman SET judul = @p2, jenis = @p3, isi = @p4, tanggal_mulai = @p5, tanggal_selesai = @p6 WHERE id_pengumuman = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", pengumumanModel.id_pengumuman);
                command.Parameters.AddWithValue("@p2", pengumumanModel.judul);
                command.Parameters.AddWithValue("@p3", pengumumanModel.jenis);
                command.Parameters.AddWithValue("@p4", pengumumanModel.isi);
                command.Parameters.AddWithValue("@p5", pengumumanModel.tanggal_mulai);
                command.Parameters.AddWithValue("@p6", pengumumanModel.tanggal_selesai);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteData(string id_pengumuman)
        {
            try
            {
                string query = "DELETE FROM pengumuman WHERE id_pengumuman = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_pengumuman);

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
