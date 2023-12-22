using Shafa_Al_Firdaus_API.Context;
using Shafa_Al_Firdaus_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWebAPI.Controllers
{

    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly ShafaContext _context;
        public TokenController(IConfiguration config, ShafaContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("submit")]

        public async Task<IActionResult> Post([FromBody] DkmModel _userData)
        {

            if (_userData != null && _userData.username != null && _userData.password != null)
            {
                var user = await GetUser(_userData.username, _userData.password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("username", user.username),
                        new Claim("email", user.email)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"], 
                        _configuration["Jwt:Audience"], 
                        claims, 
                        expires: DateTime.UtcNow.AddHours(1), 
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Nama Pengguna atau Kata Sandi tidak valid");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<DkmModel> GetUser(string username, string password)
        {
            return await _context.DkmModels.FirstOrDefaultAsync(u => u.username == username && u.password == password);
        }
    }
}