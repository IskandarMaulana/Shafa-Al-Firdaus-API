using System.ComponentModel.DataAnnotations;

namespace Shafa_Al_Firdaus_API.Models
{
    public class PengumumanModel
    {
        [Required(ErrorMessage = "ID Pengumuman wajib diisi.")]
        public Guid id_pengumuman{ get; set; }

        [Required(ErrorMessage = "Kode Petugas wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Kode maksimal 50 karakter.")] 
        public string judul { get; set; }

        [Required(ErrorMessage = "Jenis Pengumuman wajib diisi.")]
        [Range(0, 2, ErrorMessage = "Jenis Pengumuman hanya bisa Kegiatan, Pemberitahuan, atau Teks Berjalan.")]
        public int jenis { get; set; }

        [Required(ErrorMessage = "Isi Pengumuman wajib diisi.")]
        [MaxLength(300, ErrorMessage = "Isi Pengumuman maksimal 300 karakter.")]
        public string isi { get; set; }

        [Required(ErrorMessage = "Tanggal Mulai wajib diisi.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Format tanggal tidak valid.")]
        [Range(typeof(DateTime), "2000-01-01", "9999-12-31", ErrorMessage = "Tanggal Mulai harus berada di antara 2000-01-01 dan 9999-12-31.")]
        public DateTime tanggal_mulai { get; set; }

        [Required(ErrorMessage = "Tanggal Selesai wajib diisi.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Format tanggal tidak valid.")]
        [Range(typeof(DateTime), "2000-01-01", "9999-12-31", ErrorMessage = "Tanggal Selesai harus berada di antara 2000-01-01 dan 9999-12-31.")]
        public DateTime tanggal_selesai { get; set; }

        [Required(ErrorMessage = "Status Pengumuman wajib diisi.")]
        [Range(0, 3, ErrorMessage = "Status Pengumuman hanya bisa Tayang, Tidak Tayang, Dijadwalkan atau Berakhir.")]
        public int status { get; set; }
    }
}
