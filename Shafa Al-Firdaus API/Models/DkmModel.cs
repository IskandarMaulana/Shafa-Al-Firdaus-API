using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shafa_Al_Firdaus_API.Models
{
    [Table("dkm")]
    public class DkmModel
    {
        [Key]
        [Required(ErrorMessage = "Nama Pengguna Wajib Diisi.")]
        [MaxLength(50, ErrorMessage = "Nama Pengguna maksimal 50 karakter.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Kata Sandi Wajib Diisi.")]
        [MaxLength(50, ErrorMessage = "Kata Sandi maksimal 50 karakter")]
        public string password { get; set; }

        [Required(ErrorMessage = "Email Wajib Diisi.")]
        [MaxLength(50, ErrorMessage = "Email maksimal 50 karakter")]
        public string email { get; set; }
    }
}
