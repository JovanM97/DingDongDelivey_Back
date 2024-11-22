using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Services.NewOrder
{
    interface INewOrderService
    {
        public Task<Models.Product[]> GetAllProducts();
        public Task<string> ConfirmOrder(int id, Models.Order order);
        public Task<User> GetUserInfo(string username);
    }
}
