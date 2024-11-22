using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Register;

namespace DingDongDelivey_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Angular")]
    public class RegisterController : Controller
    {
        IRegisterService service;
        IUnitOfWork unitOfWork;
        private readonly AppSettings _appSettings;

        public IConfiguration Configuration { get; }

        public RegisterController(IUnitOfWork repo, IConfiguration configuration)
        {
            unitOfWork = repo;
            this.Configuration = configuration;
            _appSettings = new AppSettings();
            _appSettings.JWT_Secret = Configuration["ApplicationSettings:JWT_Secret"].ToString();
            _appSettings.Client_URL = Configuration["ApplicationSettings:Client_URL"].ToString();
            this.service = new RegisterService(_appSettings, unitOfWork);

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            String[] retVal = await service.Register(user);
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
    }
}
