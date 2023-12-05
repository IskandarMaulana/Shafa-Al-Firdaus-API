using System.ComponentModel.DataAnnotations;

namespace Shafa_Al_Firdaus_API.Models
{
    public class DkmModel
    {
        [Required(ErrorMessage = "Nama Pengguna Wajib Diisi.")]
        [MaxLength(50, ErrorMessage = "Nama Pengguna maksimal 50 karakter.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Kata Sandi Wajib Diisi.")]
        [MaxLength(50, ErrorMessage = "Kata Sandi maksimal 50 karakter")]
        public string password { get; set; }
    }
}
