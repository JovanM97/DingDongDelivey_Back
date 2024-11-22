using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDongDelivey_Back.Services.Order
{
    interface IOrderService
    {
        public Task<Models.Order[]> GetAllOrders(string username);
        public Task<string> GetOrderUser(int id);
        public Task<Models.Order> GetCurrentOrder(string username);
        public Task<string> CheckOrderTime(string id);
        public Task<Models.Order[]> GetAllDeliveryOrders();
        public Task<string> AcceptOrder(int id, string username);
    }
}
