using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDongDelivey_Back.Services.Product
{
    interface IProductService
    {
        public Task<string> AddProduct(Models.Product p);
        public Task<Models.Product[]> GetAllProducts();
    }
}
