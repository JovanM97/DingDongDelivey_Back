using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Account;

namespace DingDongDelivey_Back.Services.NewOrder
{
    public class NewOrderService : INewOrderService
    {
        private IUnitOfWork unitOfWork;
        private AppSettings appSettings;
        TokenService tokenService;
        ValidateService validateService;

        public NewOrderService(AppSettings appSettings, IUnitOfWork unitOfWork)
        {
            //this.manager = manager;
            this.appSettings = appSettings;
            tokenService = new TokenService();
            this.unitOfWork = unitOfWork;
            validateService = new ValidateService();
        }

        public async Task<Models.Product[]> GetAllProducts()
        {
            var AllProducts = unitOfWork.ProductRepository.GetAll();

            Models.Product[] products = AllProducts.Cast<Models.Product>().ToArray();

            return products;
        }

        public async Task<string> ConfirmOrder(int id, Models.Order order)
        {
            User u = unitOfWork.UserRepository.Get(id);
            if (u.hasOrder)
            {
                return "Denied";
            }

            Models.Order o = new Models.Order();
            o.buyer = u;
            o.buyerId = u.userId;
            o.deliverymanId = 0;
            o.isAccepted = false;
            o.isDelivered = false;
            o.orderAddress = order.orderAddress;
            o.orderComment = order.orderComment;

            foreach (var item in order.orderItems)
            {
                item.OrderId = o.orderId;
            }
            o.orderItems = order.orderItems;
            o.orderPrice = order.orderPrice;

            u.hasOrder = true;

            unitOfWork.OrderRepository.Add(o);
            unitOfWork.UserRepository.Update(u);



            return "Success";
        }

        public async Task<User> GetUserInfo(string username)
        {
            User u = checkUsername(username);

            return u;
        }

        private User checkUsername(string username)
        {
            var AllUser = unitOfWork.UserRepository.GetAll();
            foreach (var temp in AllUser)
            {
                if (temp.username == username)
                    return temp;
            }
            return null;
        }
    }
}
