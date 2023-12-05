namespace Shafa_Al_Firdaus_API.Models
{
    public class PengumumanModel
    {
        public Guid id_pengumuman{ get; set; }
        public string judul { get; set; }
        public int jenis { get; set; }
        public string isi { get; set; }
        public DateTime tanggal_mulai { get; set; }
        public DateTime tanggal_selesai { get; set; }

        public int status { get; set; }
    }
}
