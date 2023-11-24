namespace Shafa_Al_Firdaus_API.Models
{
    public class JadwalPetugasHarianModel
    {
        public Guid id_jadwal { get; set; }
        public string nim { get; set; }
        public DateTime tanggal { get; set; }
        public string waktu { get; set; }
        public string tugas { get; set; }
    }
}
