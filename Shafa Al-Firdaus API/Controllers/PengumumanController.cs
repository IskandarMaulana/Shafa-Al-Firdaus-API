using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG4_M7_P1_112.Models;
using Shafa_Al_Firdaus_API.Models;

namespace Shafa_Al_Firdaus_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PengumumanController : Controller
    {
        private readonly PengumumanRepository _pengumumanRepository;
        ResponseModel response = new ResponseModel();

        public PengumumanController(IConfiguration configuration)
        {
            _pengumumanRepository = new PengumumanRepository(configuration);
        }

        [HttpGet("/GetAllPengumuman", Name = "GetAllPengumuman")]
        public IActionResult GetAllPengumuman()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _pengumumanRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpGet("/GetPengumuman", Name = "GetPengumuman")]
        public IActionResult GetPengumuman(string id_pengumuman)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _pengumumanRepository.getData(id_pengumuman);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpPost("/InsertPengumuman", Name = "InsertPengumuman")]
        public IActionResult InsertPengumuman([FromBody] PengumumanModel pengumumanModel)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                pengumumanModel.id_pengumuman = Guid.NewGuid();
                response.data = pengumumanModel;
                _pengumumanRepository.insertData(pengumumanModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpPut("/UpdatePengumuman", Name = "UpdatePengumuman")]
        public IActionResult UpdateDkm([FromBody] PengumumanModel jadwalPetugasHarianModel)
        {
            PengumumanModel jadwal = new PengumumanModel();

            jadwal.id_pengumuman = jadwalPetugasHarianModel.id_pengumuman;
            jadwal.judul = jadwalPetugasHarianModel.judul;
            jadwal.jenis = jadwalPetugasHarianModel.jenis;
            jadwal.isi = jadwalPetugasHarianModel.isi;
            jadwal.tanggal_mulai = jadwalPetugasHarianModel.tanggal_mulai;
            jadwal.tanggal_selesai = jadwalPetugasHarianModel.tanggal_selesai;
            jadwal.status = jadwalPetugasHarianModel.status;

            try
            {
                response.status = 200;
                response.message = "Success";
                _pengumumanRepository.updateData(jadwal);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpDelete("/DeletePengumuman", Name = "DeletePengumuman")]
        public IActionResult DeletePengumuman(string id_pengumuman)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _pengumumanRepository.deleteData(id_pengumuman);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpPatch("/UpdateStatusPengumuman", Name = "UpdateStatusPengumuman")]
        public IActionResult UpdateStatusPengumuman(string id_pengumuman, int newStatus)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _pengumumanRepository.updateStatus(id_pengumuman, newStatus);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpPatch("/UpdateStatusPengumumanSelesai", Name = "UpdateStatusPengumumanSelesai")]
        public IActionResult UpdateStatusPengumumanSelesai(string id_pengumuman, int newStatus)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _pengumumanRepository.updateStatusselesai(id_pengumuman, newStatus);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
    }
}

