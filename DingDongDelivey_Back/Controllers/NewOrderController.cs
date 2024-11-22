using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.NewOrder;

namespace DingDongDelivey_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Angular")]
    public class NewOrderController : Controller
    {
        INewOrderService service;
        IUnitOfWork unitOfWork;
        private readonly AppSettings _appSettings;

        public IConfiguration Configuration { get; }

        public NewOrderController(IUnitOfWork repo, IConfiguration configuration)
        {
            unitOfWork = repo;
            this.Configuration = configuration;
            _appSettings = new AppSettings();
            _appSettings.JWT_Secret = Configuration["ApplicationSettings:JWT_Secret"].ToString();
            _appSettings.Client_URL = Configuration["ApplicationSettings:Client_URL"].ToString();
            this.service = new NewOrderService(_appSettings, unitOfWork);

        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {

            Product[] retVal = await service.GetAllProducts();

            return Ok(retVal);
        }

        [HttpPut]
        [Route("ConfirmOrder/{id?}")]
        public async Task<IActionResult> ConfirmOrder(int id, [FromBody] Order order)
        {

            string retVal = await service.ConfirmOrder(id, order);

            String token = "";
            String msg = retVal;
            String username = "";

            return Ok(new { token, msg, username });
        }

        [HttpGet]
        [Route("GetUserInfo/{username?}")]
        public async Task<IActionResult> GetUserInfo(string username)
        {

            User retVal = await service.GetUserInfo(username);

            return Ok(retVal);
        }
    }
}
