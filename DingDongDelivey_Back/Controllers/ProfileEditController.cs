using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.ProfileEdit;

namespace DingDongDelivey_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Angular")]
    public class ProfileEditController : Controller
    {
        IProfileEditService service;
        IUnitOfWork unitOfWork;
        private readonly AppSettings _appSettings;

        public IConfiguration Configuration { get; }

        public ProfileEditController(IUnitOfWork repo, IConfiguration configuration)
        {
            unitOfWork = repo;
            this.Configuration = configuration;
            _appSettings = new AppSettings();
            _appSettings.JWT_Secret = Configuration["ApplicationSettings:JWT_Secret"].ToString();
            _appSettings.Client_URL = Configuration["ApplicationSettings:Client_URL"].ToString();
            this.service = new ProfileEditService(_appSettings, unitOfWork);
        }

        [HttpGet]
        [Route("GetUserInfo/{username?}")]
        public async Task<IActionResult> GetUserInfo(string username)
        {

            User retVal = await service.GetUserInfo(username);

            return Ok(retVal);
        }

        [HttpPut]
        [Route("SaveUserInfo/{id?}")]
        public async Task<IActionResult> SaveUserInfo(int id, [FromBody] User user)
        {

            string retVal = await service.SaveUserInfo(id, user);

            if (retVal == "Success")
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }

        }
    }
}
