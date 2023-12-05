using System.ComponentModel.DataAnnotations;

namespace Shafa_Al_Firdaus_API.Models
{
    public class PetugasHarianModel
    {
        [Required(ErrorMessage = "Kode Petugas wajib diisi.")]
        [MaxLength(10, ErrorMessage = "Kode maksimal 10 karakter.")]
        [RegularExpression("^PTGS[0-9]{6}$", ErrorMessage = "Format Kode Petugas tidak valid.")]
        public string kode { get; set; }

        [Required(ErrorMessage = "Nama Petugas wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Nama Petugas maksimal 30 karakter.")]
        [RegularExpression("^[a-zA-Z' -]*$", ErrorMessage = "Nama Petugas hanya boleh berupa huruf, spasi, dan tanda tertentu ('-).")]
        public string nama { get; set; }

        [Required(ErrorMessage = "Nomor Telepon Petugas wajib diisi.")]
        [MaxLength(13, ErrorMessage = "Nomor Telepon Petugas maksimal 13 karakter.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nomor Telepon Petugas hanya boleh berupa angka.")]
        public string nomor_telepon { get; set; }

        [Required(ErrorMessage = "Status Petugas wajib diisi.")]
        [Range(0, 1, ErrorMessage = "Status Petugas hanya bisa Aktif atau Tidak Aktif.")]
        public int status { get; set; } = 1;

    }
}
