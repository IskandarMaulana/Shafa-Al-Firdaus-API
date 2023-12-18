using System.ComponentModel.DataAnnotations;

namespace Shafa_Al_Firdaus_API.Models
{
    public class JadwalPetugasHarianModel
    {
        [Key]
        [Required(ErrorMessage = "ID Jadwal wajib diisi.")]
        public Guid id_jadwal { get; set; }

        [Required(ErrorMessage = "Kode Petugas wajib diisi.")]
        [MaxLength(10, ErrorMessage = "Kode maksimal 10 karakter.")]
        [RegularExpression("^PTGS[0-9]{6}$", ErrorMessage = "Format Kode Petugas tidak valid.")]
        public string kode { get; set; }

        [Required(ErrorMessage = "Tanggal wajib diisi.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd  HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Format tanggal tidak valid.")]
        [Range(typeof(DateTime), "2000-01-01", "9999-12-31", ErrorMessage = "Tanggal harus berada di antara 2000-01-01 dan 9999-12-31.")]
        public DateTime tanggal { get; set; }

        [Required(ErrorMessage = "Waktu wajib diisi.")]
        [MaxLength(10, ErrorMessage = "Waktu maksimal 10 karakter.")]
        [RegularExpression("^[a-zA-Z' ]*$", ErrorMessage = "Waktu hanya boleh berupa huruf, spasi, dan tanda tertentu (').")]
        public string waktu { get; set; }

        [Required(ErrorMessage = "Tugas wajib diisi.")]
        [MaxLength(250, ErrorMessage = "Tugas maksimal 250 karakter.")]
        public string tugas { get; set; }

        [Required(ErrorMessage = "Status wajib diisi.")]
        [Range(0, 2, ErrorMessage = "Status hanya bisa Aktif, Dibatalkan, atau Terlaksana.")]
        public int status { get; set; } = 1;
    }
}
