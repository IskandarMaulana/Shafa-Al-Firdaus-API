using System.ComponentModel.DataAnnotations;

namespace Shafa_Al_Firdaus_API.Models
{
    public class JadwalPetugasHarianModel
    {
        [Required(ErrorMessage = "ID Jadwal wajib diisi.")]
        public Guid id_jadwal { get; set; }

        [Required(ErrorMessage = "Kode Petugas wajib diisi.")]
        [MaxLength(10, ErrorMessage = "Kode maksimal 10 karakter.")]
        [RegularExpression("^PTGS[0-9]{6}$", ErrorMessage = "Format Kode Petugas tidak valid.")]
        public string kode { get; set; }

        [Required(ErrorMessage = "Tanggal wajib diisi.")]
        [DataType(DataType.DateTime, ErrorMessage = "Format tanggal tidak valid.")]
        [Range(typeof(DateTime), "1900-01-01", "9999-12-31", ErrorMessage = "Tanggal harus berada di antara 1900-01-01 dan 9999-12-31.")]
        public DateTime tanggal { get; set; }

        [Required(ErrorMessage = "Waktu wajib diisi.")]
        [MaxLength(10, ErrorMessage = "Waktu maksimal 10 karakter.")]
        public string waktu { get; set; }

        [Required(ErrorMessage = "Tugas wajib diisi.")]
        [MaxLength(100, ErrorMessage = "Tugas maksimal 255 karakter.")]
        public string tugas { get; set; }

        [Required(ErrorMessage = "Status wajib diisi.")]
        [Range(0, 2, ErrorMessage = "Status hanya bisa Aktif, Dibatalkan, atau Terlaksana.")]
        public int status { get; set; } = 1;
    }
}
