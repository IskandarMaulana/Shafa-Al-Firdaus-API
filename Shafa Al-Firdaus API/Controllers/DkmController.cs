using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG4_M7_P1_112.Models;
using Shafa_Al_Firdaus_API.Models;

namespace Shafa_Al_Firdaus_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DkmController : Controller
    {
        private readonly DkmRepository _dkmrepository;
        ResponseModel response = new ResponseModel();

        public DkmController(IConfiguration configuration)
        {
            _dkmrepository = new DkmRepository(configuration);
        }

        [HttpGet("/GetAllDkm", Name = "GetAllDkm")]
        public IActionResult GetAllDkm()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _dkmrepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpGet("/GetDkm", Name = "GetDkm")]
        public IActionResult GetDkm(string username)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _dkmrepository.getData(username);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        /*[HttpPost("/InsertDkm", Name = "InsertDkm")]
        public IActionResult InsertAnggota([FromBody] DkmModel dkmModel)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _dkmrepository.insertData(dkmModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }*/
        [HttpPut("/UpdateDkm", Name = "UpdateDkm")]
        public IActionResult UpdateDkm([FromBody] DkmModel dkmModel)
        {
            DkmModel dkm = new DkmModel();

            dkm.username = dkmModel.username;
            dkm.password = dkmModel.password;
            
            try
            {
                response.status = 200;
                response.message = "Success";
                _dkmrepository.updateData(dkm);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        /*[HttpDelete("/DeleteDkm", Name = "DeleteDkm")]
        public IActionResult DeleteDkm(string username)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _dkmrepository.deleteData(username);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }*/
    }
}
