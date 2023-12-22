using System.ComponentModel.DataAnnotations;

namespace Shafa_Al_Firdaus_API.Models
{
    public class JadwalPetugasHarianViewModel
    {
        public DateTime tanggal { get; set; }
        public string nama { get; set; }
        public string waktu { get; set; }
        public string tugas { get; set; }
        public int status { get; set; } = 1;
    }
}
