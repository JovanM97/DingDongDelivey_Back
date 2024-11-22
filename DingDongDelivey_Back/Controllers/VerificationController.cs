using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Account;
using DingDongDelivey_Back.Services.Verification;

namespace DingDongDelivey_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Angular")]

    public class VerificationController : Controller
    {

        IVerificationService service;
        IUnitOfWork unitOfWork;
        private readonly AppSettings _appSettings;

        private IMailService mailService;

        public IConfiguration Configuration { get; }

        public VerificationController(IUnitOfWork repo, IConfiguration configuration, IMailService mailService)
        {
            unitOfWork = repo;
            this.Configuration = configuration;
            _appSettings = new AppSettings();
            _appSettings.JWT_Secret = Configuration["ApplicationSettings:JWT_Secret"].ToString();
            _appSettings.Client_URL = Configuration["ApplicationSettings:Client_URL"].ToString();
            this.service = new VerificationService(_appSettings, unitOfWork, mailService);

        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {

            User[] retVal = await service.GetAllUsers();


            return Ok(retVal);
        }

        [HttpGet]
        [Route("AcceptUser/{id?}")]
        public async Task<IActionResult> AcceptUser(int id)
        {

            string retVal = await service.AcceptUser(id);

            return Ok(retVal);
        }

        [HttpGet]
        [Route("RejectUser/{id?}")]
        public async Task<IActionResult> RejectUser(int id)
        {

            string retVal = await service.RejectUser(id);

            return Ok(retVal);
        }
    }
}
