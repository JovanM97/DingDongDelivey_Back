using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Login;

namespace DingDongDelivey_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Angular")]
    public class LoginController : ControllerBase
    {
        ILoginService service;
        IUnitOfWork unitOfWork;
        private readonly AppSettings _appSettings;

        public IConfiguration Configuration { get; }

        public LoginController(IUnitOfWork repo, IConfiguration configuration)
        {
            unitOfWork = repo;
            this.Configuration = configuration;
            _appSettings = new AppSettings();
            _appSettings.JWT_Secret = Configuration["ApplicationSettings:JWT_Secret"].ToString();
            _appSettings.Client_URL = Configuration["ApplicationSettings:Client_URL"].ToString();
            this.service = new LoginService(_appSettings, unitOfWork);

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel credentials)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(new { message = "Username and password have to be supplied" });

            //if (string.IsNullOrWhiteSpace(credentials.Username))
            //    return BadRequest(new { message = "Username not supplied" });
            //if (string.IsNullOrWhiteSpace(credentials.Password))
            //    return BadRequest(new { message = "Password not supplied" });

            String[] retVal = await service.Login(credentials.email, credentials.password);
            String token = retVal[0];
            String msg = retVal[1];
            String username = retVal[2];

            if (!token.Equals("Error"))
            {
                return Ok(new { token, msg, username });
            }
            else
            {
                return BadRequest(new { token, msg });
            }

        }

        [HttpPost]
        [Route("SocialLogin")]
        public async Task<IActionResult> SocialLogin([FromBody] User credentials)
        {
            var test = _appSettings.JWT_Secret;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            String[] retVal = await service.SocialLogin(credentials);
            String msg = retVal[1];
            String username = retVal[2];

            return Ok(new { token, msg, username });
        }


    }
}
