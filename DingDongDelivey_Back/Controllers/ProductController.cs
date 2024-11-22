using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Product;

namespace DingDongDelivey_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Angular")]
    public class ProductController : Controller
    {
        IProductService service;
        IUnitOfWork unitOfWork;
        private readonly AppSettings _appSettings;

        public IConfiguration Configuration { get; }

        public ProductController(IUnitOfWork repo, IConfiguration configuration)
        {
            unitOfWork = repo;
            this.Configuration = configuration;
            _appSettings = new AppSettings();
            _appSettings.JWT_Secret = Configuration["ApplicationSettings:JWT_Secret"].ToString();
            _appSettings.Client_URL = Configuration["ApplicationSettings:Client_URL"].ToString();
            this.service = new ProductService(_appSettings, unitOfWork);
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {

            Product[] retVal = await service.GetAllProducts();

            return Ok(retVal);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {

            string retVal = await service.AddProduct(product);

            return Ok(retVal);
        }
    }
}
