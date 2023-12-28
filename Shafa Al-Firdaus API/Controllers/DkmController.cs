using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG4_M7_P1_112.Models;
using Shafa_Al_Firdaus_API.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

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
        [HttpPost("/SendOtp")]
        public IActionResult SendOtp(string to, string otp)
        {
            try
            {
                const string subject = "Kode OTP untuk Verifikasi";
                string body = $"Hi DKM!\n\nKode OTP Anda adalah: {otp}.\n\nMasukkan Kode ini untuk verifikasi mengubah Kata Sandi Anda.";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Iskandar Maulana", "0320220112@polytechnic.astra.ac.id"));
                message.To.Add(new MailboxAddress("DKM Asy-Syabab", to));
                message.Subject = subject;

                var textPart = new TextPart("plain")
                {
                    Text = body
                };

                var multipart = new Multipart("mixed");
                multipart.Add(textPart);

                message.Body = multipart;

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("0320220112@polytechnic.astra.ac.id", "Vat44064");

                    client.Send(message);
                    client.Disconnect(true);
                }
                
                /*var fromAddress = "mynameiskandar410@gmail.com";

                const string fromPassword = "iskandar2468";

                var client = new SmtpClient("smtp.gmail.com", 465)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress, fromPassword)
                };

                var mailMessage = new MailMessage(from: fromAddress, to: to, subject, body);

                client.Send(mailMessage);*/
                //_emailService.SendEmail(to, subject, body);

                return Ok(new { Message = "Email sent successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Failed to send email.", Error = ex.Message });
            }
        }
    }
}
