using System.ComponentModel.DataAnnotations;

namespace Shafa_Al_Firdaus_API.Models
{
    public class PengumumanViewModel
    {
        public string judul { get; set; }
        public int jenis { get; set; }
        public string isi { get; set; }
        public DateTime tanggal_mulai { get; set; } = DateTime.Now;
        public DateTime tanggal_selesai { get; set; } = DateTime.Now;
        public int status { get; set; }
    }
}
