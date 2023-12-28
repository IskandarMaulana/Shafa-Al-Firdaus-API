using Microsoft.AspNetCore.Mvc;
using PRG4_M7_P1_112.Models;
using Shafa_Al_Firdaus_API.Models;

namespace Shafa_Al_Firdaus_API.Controllers
{
    public class ViewDashboardController : Controller
    {
        private readonly JadwalPetugasHarianRepository _jadwalpetugasrepository;
        ResponseModel response = new ResponseModel();

        public ViewDashboardController(IConfiguration configuration)
        {
            _jadwalpetugasrepository = new JadwalPetugasHarianRepository(configuration);
        }

        [HttpGet("/GetViewJadwalPetugas", Name = "GetViewJadwalPetugas")]
        public IActionResult GetViewJadwalPetugas()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _jadwalpetugasrepository.getAllJadwalPetugasView();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpGet("/GetViewPengumuman", Name = "GetViewPengumuman")]
        public IActionResult GetViewPengumuman()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _jadwalpetugasrepository.getAllPengumumanView();
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
