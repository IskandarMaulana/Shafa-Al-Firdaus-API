using Microsoft.AspNetCore.Mvc;
using PRG4_M7_P1_112.Models;
using Shafa_Al_Firdaus_API.Models;

namespace Shafa_Al_Firdaus_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JadwalPetugasHarianController : Controller
    {
        private readonly JadwalPetugasHarianRepository _jadwalRepository;
        ResponseModel response = new ResponseModel();

        public JadwalPetugasHarianController(IConfiguration configuration)
        {
            _jadwalRepository = new JadwalPetugasHarianRepository(configuration);
        }

        [HttpGet("/GetAllJadwalPetugasHarian", Name = "GetAllJadwalPetugasHarian")]
        public IActionResult GetAllJadwalPetugasHarian()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _jadwalRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpGet("/GetJadwalPetugasHarian", Name = "GetJadwalPetugasHarian")]
        public IActionResult GetJadwalPetugasHarian(string id_jadwal)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _jadwalRepository.getData(id_jadwal);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }

        

        [HttpPost("/InsertJadwalPetugasHarian", Name = "InsertJadwalPetugasHarian")]
        public IActionResult InsertJadwalPetugasHarian([FromBody] JadwalPetugasHarianModel jadwalPetugasHarianModel)
        {
            try
            {
                response.status = 200;
                response.message = "Success";

                jadwalPetugasHarianModel.id_jadwal = Guid.NewGuid();
                _jadwalRepository.insertData(jadwalPetugasHarianModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpPut("/UpdateStatus", Name = "UpdateStatus")]
        public IActionResult UpdateStatus(string id_jadwal, int status)
        {
            JadwalPetugasHarianModel jadwal = new JadwalPetugasHarianModel();

            try
            {
                response.status = 200;
                response.message = "Success";
                _jadwalRepository.updateStatus(id_jadwal, status);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpPut("/UpdateJadwalPetugasHarian", Name = "UpdateJadwalPetugasHarian")]
        public IActionResult UpdateDkm([FromBody] JadwalPetugasHarianModel jadwalPetugasHarianModel)
        {
            JadwalPetugasHarianModel jadwal = new JadwalPetugasHarianModel();

            jadwal.id_jadwal = jadwalPetugasHarianModel.id_jadwal;
            jadwal.kode = jadwalPetugasHarianModel.kode;
            jadwal.tanggal = jadwalPetugasHarianModel.tanggal;
            jadwal.waktu = jadwalPetugasHarianModel.waktu;
            jadwal.tugas = jadwalPetugasHarianModel.tugas;
            jadwal.status = jadwalPetugasHarianModel.status;

            try
            {
                response.status = 200;
                response.message = "Success";
                _jadwalRepository.updateData(jadwal);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpDelete("/DeleteJadwalPetugasHarian", Name = "DeleteJadwalPetugasHarian")]
        public IActionResult DeleteJadwalPetugasHarian(string id_jadwal)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _jadwalRepository.deleteData(id_jadwal);
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
