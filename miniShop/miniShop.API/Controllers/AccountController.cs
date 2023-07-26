using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using miniShop.Application.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace miniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            var user = userService.ValidateUser(userLoginModel.UserName, userLoginModel.Password);
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-kripto-icin-onemli"));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                     issuer: "cimtas.com.tr",
                     audience: "cimtas.mobil",
                     claims: claims,
                     notBefore: DateTime.Now,
                     expires: DateTime.Now.AddDays(1),
                     signingCredentials: credential

                    );

                //Cookie'ye yazamayacağına göre, istemciye gönder
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });



            }
            return BadRequest(new { message = "hatalı giriş" });


        }
    }
}
