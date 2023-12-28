using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.SqlClient;

namespace Shafa_Al_Firdaus_API.Models
{
    public class JadwalPetugasHarianRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public JadwalPetugasHarianRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        /*------------------------- View Jadwal Petugas Harian ---------------------*/
        public List<JadwalPetugasHarianViewModel> getAllJadwalPetugasView()
        {
            List<JadwalPetugasHarianViewModel> jadwalList = new List<JadwalPetugasHarianViewModel>();

            try
            {
                string query = "SELECT * FROM jadwal_petugas_view ORDER BY tanggal ASC";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    JadwalPetugasHarianViewModel petugas = new JadwalPetugasHarianViewModel
                    {
                        tanggal = Convert.ToDateTime(reader["tanggal"].ToString()),
                        nama = reader["nama"].ToString(),
                        waktu = reader["waktu"].ToString(),
                        tugas = reader["tugas"].ToString(),
                        status = Convert.ToInt32(reader["status"].ToString())
                    };
                    jadwalList.Add(petugas);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return jadwalList;
        }

        /*------------------------- View Pengumuman Harian ---------------------*/
        public List<PengumumanViewModel> getAllPengumumanView()
        {
            List<PengumumanViewModel> pengumumanList = new List<PengumumanViewModel>();

            try
            {
                string query = "SELECT * FROM pengumuman_view ORDER BY tanggal_mulai ASC";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PengumumanViewModel pengumuman = new PengumumanViewModel
                    {
                        judul = reader["judul"].ToString(),
                        jenis = Convert.ToInt32(reader["jenis"].ToString()),
                        isi = reader["isi"].ToString(),
                        tanggal_mulai = Convert.ToDateTime(reader["tanggal_mulai"].ToString()),
                        tanggal_selesai = Convert.ToDateTime(reader["tanggal_selesai"].ToString()),
                        status = Convert.ToInt32(reader["status"].ToString())
                    };
                    pengumumanList.Add(pengumuman);
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

        public List<JadwalPetugasHarianModel> getAllData()
        {
            List<JadwalPetugasHarianModel> jadwalList = new List<JadwalPetugasHarianModel>();

            try
            {
                string query = "Select * from jadwal_petugas_harian jph join petugas_harian ph on jph.kode = ph.kode ORDER BY jph.tanggal ASC";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    JadwalPetugasHarianModel petugas = new JadwalPetugasHarianModel
                    {
                        id_jadwal = Guid.Parse(reader["id_jadwal"].ToString()),
                        kode = reader["nama"].ToString(),
                        tanggal = Convert.ToDateTime(reader["tanggal"].ToString()),
                        waktu = reader["waktu"].ToString(),
                        tugas = reader["tugas"].ToString(),
                        status = Convert.ToInt32(reader["status"].ToString())
                    };
                    jadwalList.Add(petugas);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return jadwalList;
        }

        public JadwalPetugasHarianModel getData(string id_jadwal)
        {
            JadwalPetugasHarianModel jadwalModel = new JadwalPetugasHarianModel();
            try
            {
                string query = "SELECT * FROM jadwal_petugas_harian WHERE id_jadwal = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_jadwal);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                jadwalModel.id_jadwal = Guid.Parse(reader["id_jadwal"].ToString());
                jadwalModel.kode = reader["kode"].ToString();
                jadwalModel.tanggal = Convert.ToDateTime(reader["tanggal"].ToString());
                jadwalModel.waktu = reader["waktu"].ToString();
                jadwalModel.tugas = reader["tugas"].ToString();
                jadwalModel.status = Convert.ToInt32(reader["status"].ToString());

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return jadwalModel;
        }

        public void insertData(JadwalPetugasHarianModel jadwalPetugasHarianModel)
        {
            try
            {
                string query = "INSERT INTO jadwal_petugas_harian VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", jadwalPetugasHarianModel.id_jadwal);
                command.Parameters.AddWithValue("@p2", jadwalPetugasHarianModel.kode);
                command.Parameters.AddWithValue("@p3", jadwalPetugasHarianModel.tanggal);
                command.Parameters.AddWithValue("@p4", jadwalPetugasHarianModel.waktu);
                command.Parameters.AddWithValue("@p5", jadwalPetugasHarianModel.tugas);
                command.Parameters.AddWithValue("@p6", jadwalPetugasHarianModel.status);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void updateStatus(string id_jadwal, int status)
        {
            try
            {
                string query = "UPDATE jadwal_petugas_harian SET status = @p2 WHERE id_jadwal = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_jadwal);
                command.Parameters.AddWithValue("@p2", status);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void updateData(JadwalPetugasHarianModel jadwalPetugasHarianModel)
        {
            try
            {
                string query = "UPDATE jadwal_petugas_harian SET kode = @p2, tanggal = @p3, waktu = @p4, tugas = @p5 WHERE id_jadwal = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", jadwalPetugasHarianModel.id_jadwal);
                command.Parameters.AddWithValue("@p2", jadwalPetugasHarianModel.kode);
                command.Parameters.AddWithValue("@p3", jadwalPetugasHarianModel.tanggal);
                command.Parameters.AddWithValue("@p4", jadwalPetugasHarianModel.waktu);
                command.Parameters.AddWithValue("@p5", jadwalPetugasHarianModel.tugas);
                command.Parameters.AddWithValue("@p6", jadwalPetugasHarianModel.status);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public void deleteData(string id_jadwal)
        {
            try
            {
                string query = "DELETE FROM jadwal_petugas_harian WHERE id_jadwal = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_jadwal);

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
