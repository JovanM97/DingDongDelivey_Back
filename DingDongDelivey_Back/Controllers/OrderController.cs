using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Order;
using DingDongDelivey_Back.Services.Verification;

namespace DingDongDelivey_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Angular")]
    public class OrderController : Controller
    {
        IOrderService service;
        IUnitOfWork unitOfWork;
        private readonly AppSettings _appSettings;

        public IConfiguration Configuration { get; }

        public OrderController(IUnitOfWork repo, IConfiguration configuration)
        {
            unitOfWork = repo;
            this.Configuration = configuration;
            _appSettings = new AppSettings();
            _appSettings.JWT_Secret = Configuration["ApplicationSettings:JWT_Secret"].ToString();
            _appSettings.Client_URL = Configuration["ApplicationSettings:Client_URL"].ToString();
            this.service = new OrderService(_appSettings, unitOfWork);

        }

        [HttpGet]
        [Route("GetAllOrders/{username?}")]
        public async Task<IActionResult> GetAllOrders(string username)
        {

            Order[] orders = await service.GetAllOrders(username);

            return Ok(orders);
        }

        [HttpGet]
        [Route("GetOrderUser/{id?}")]
        public async Task<IActionResult> GetOrderUser(int id)
        {

            string res = await service.GetOrderUser(id);
            
            String token = "";
            String msg = res;
            String username = "";

            return Ok(new { token, msg, username });
        }

        [HttpGet]
        [Route("GetCurrentOrder/{username?}")]
        public async Task<IActionResult> GetCurrentOrder(string username)
        {

            Order res = await service.GetCurrentOrder(username);

            return Ok(res);
        }

        [HttpGet]
        [Route("CheckOrderTime/{username?}")]
        public async Task<IActionResult> CheckOrderTime(string username)
        {

            string res = await service.CheckOrderTime(username);

            String token = "";
            String msg = res;

            return Ok(new { token, msg, username });
        }

        [HttpGet]
        [Route("GetAllDeliveryOrders")]
        public async Task<IActionResult> GetAllDeliveryOrders()
        {

            Order[] res = await service.GetAllDeliveryOrders();

            return Ok(res);
        }

        [HttpPut]
        [Route("AcceptOrder/{id?}/{username?}")]
        public async Task<IActionResult> AcceptOrder(int id, string username)
        {

            string res = await service.AcceptOrder(id, username);

            return Ok(res);
        }
    }
}
