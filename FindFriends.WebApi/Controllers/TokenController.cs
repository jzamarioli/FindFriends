using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using FindFriends.Domain.Entities;

namespace apiUsuarios.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Usuario request)
        {            
            // fixed values: 'user' e 'pwd'
            if (request.Username == "user" && request.Password=="pwd")
            {
                var claims = new[]
                {
                     new Claim(ClaimTypes.Name, request.Username)
                };
                
                var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

               var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 

               var token = new JwtSecurityToken(
                    issuer: "jzamarioli", 
                    audience: "jzamarioli",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Invalid Credentials...");
        }
    }
}