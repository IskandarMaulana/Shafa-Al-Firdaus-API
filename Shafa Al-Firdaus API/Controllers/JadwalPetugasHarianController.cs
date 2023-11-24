using Microsoft.AspNetCore.Mvc;
using PRG4_M7_P1_112.Models;
using Shafa_Al_Firdaus_API.Models;

namespace Shafa_Al_Firdaus_API.Controllers
{
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
        public IActionResult InsertJadwalPetugasHarian([FromBody] JadwalPetugasHarianModel petugasHarianModel)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _jadwalRepository.insertData(petugasHarianModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpPut("/UpdateJadwalPetugasHarian", Name = "UpdateJadwalPetugasHarian")]
        public IActionResult UpdateDkm([FromBody] JadwalPetugasHarianModel petugasHarianModel)
        {
            JadwalPetugasHarianModel petugas = new JadwalPetugasHarianModel();

            petugas.id_jadwal = petugasHarianModel.id_jadwal;
            petugas.nim = petugasHarianModel.nim;
            petugas.tanggal = petugasHarianModel.tanggal;
            petugas.waktu = petugasHarianModel.waktu;
            petugas.tugas = petugasHarianModel.tugas;

            try
            {
                response.status = 200;
                response.message = "Success";
                _jadwalRepository.updateData(petugas);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpDelete("/DeleteJadwalPetugasHarian", Name = "DeleteJadwalPetugasHarian")]
        public IActionResult DeleteJadwalPetugasHarian(string nim)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _jadwalRepository.deleteData(nim);
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
