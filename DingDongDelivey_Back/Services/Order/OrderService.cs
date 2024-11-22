using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Account;

namespace DingDongDelivey_Back.Services.Order
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork unitOfWork;
        private AppSettings appSettings;
        TokenService tokenService;
        ValidateService validateService;

        public OrderService(AppSettings appSettings, IUnitOfWork unitOfWork)
        {
            //this.manager = manager;
            this.appSettings = appSettings;
            tokenService = new TokenService();
            this.unitOfWork = unitOfWork;
            validateService = new ValidateService();
        }

        public async Task<Models.Order[]> GetAllOrders(string username)
        {

            User u = checkUsername(username);
            if (u.userT == userType.ADMIN)
            {
                var AllOrders = unitOfWork.OrderRepository.GetAll();
                Models.Order[] orders = AllOrders.Cast<Models.Order>().ToArray();
                var AllProductOrders = unitOfWork.ProductOrderRepository.GetAll();
                var AllProducts = unitOfWork.ProductRepository.GetAll();

                //Models.Order[] result = joinOrderItems(orders);

                return orders;
            }
            else if (u.userT == userType.BUYER)
            {
                var AllOrders = unitOfWork.OrderRepository.GetAll();
                Models.Order[] orders = AllOrders.Cast<Models.Order>().ToArray();
                var AllProductOrders = unitOfWork.ProductOrderRepository.GetAll();
                var AllProducts = unitOfWork.ProductRepository.GetAll();

                List<Models.Order> userOrders = new List<Models.Order>();

                for (int i = 0; i < orders.Length; i++)
                {
                    if (orders[i].buyerId == u.userId && orders[i].isDelivered == true)
                    {
                        userOrders.Add(orders[i]);
                    }
                }

                orders = userOrders.ToArray();

                return orders;
            }
            else if (u.userT == userType.DELIVERYMAN)
            {
                var AllOrders = unitOfWork.OrderRepository.GetAll();
                Models.Order[] orders = AllOrders.Cast<Models.Order>().ToArray();
                var AllProductOrders = unitOfWork.ProductOrderRepository.GetAll();
                var AllProducts = unitOfWork.ProductRepository.GetAll();

                List<Models.Order> userOrders = new List<Models.Order>();

                for (int i = 0; i < orders.Length; i++)
                {
                    if (orders[i].deliverymanId == u.userId && orders[i].isDelivered == true)
                    {
                        userOrders.Add(orders[i]);
                    }
                }

                orders = userOrders.ToArray();

                return orders;
            }

            return null;
        }

        public async Task<string> GetOrderUser(int id)
        {
            User u = unitOfWork.UserRepository.Get(id);

            if (u != null)
            {
                return u.username;
            }
            else
            {
                return "NONE";
            }
        }

        public async Task<Models.Order> GetCurrentOrder(string username)
        {
            User u = checkUsername(username);

            if (u == null)
            {
                return null;
            }

            var AllOrders = unitOfWork.OrderRepository.GetAll();
            Models.Order[] orders = AllOrders.Cast<Models.Order>().ToArray();
            var AllProductOrders = unitOfWork.ProductOrderRepository.GetAll();
            var AllProducts = unitOfWork.ProductRepository.GetAll();

            if (u.hasOrder == false)
            {
                return null;
            }

            foreach (var o in orders)
            {
                if (u.userT == userType.BUYER)
                {
                    if (u.userId == o.buyerId && o.isDelivered == false)
                    {
                        return o;
                    }
                }
                else if (u.userT == userType.DELIVERYMAN)
                {
                    if (u.userId == o.deliverymanId && o.isDelivered == false)
                    {
                        return o;
                    }
                }
            }

            return null;
        }

        public async Task<string> CheckOrderTime(string id)
        {
            User u = checkUsername(id);

            var AllOrders = unitOfWork.OrderRepository.GetAll();
            Models.Order[] orders = AllOrders.Cast<Models.Order>().ToArray();
            var AllProductOrders = unitOfWork.ProductOrderRepository.GetAll();
            var AllProducts = unitOfWork.ProductRepository.GetAll();

            Models.Order currentOrder = new Models.Order();

            foreach (var o in orders)
            {
                if (u.userT == userType.BUYER)
                {
                    if (u.userId == o.buyerId && o.isDelivered == false)
                    {
                        currentOrder = o;
                    }
                }
                else if (u.userT == userType.DELIVERYMAN)
                {
                    if (u.userId == o.deliverymanId && o.isDelivered == false)
                    {
                        currentOrder = o;
                    }
                }
            }

            if (currentOrder.orderId == 0)
            {
                return null;
            }

            if (currentOrder.timeTillDelivery < DateTime.Now && currentOrder.isAccepted) //STIGLA PORUDZBINA
            {
                currentOrder.isDelivered = true;
                u.deliveryS = deliveryStatus.NONE;
                u.hasOrder = false;

                User delivery = unitOfWork.UserRepository.Get(currentOrder.deliverymanId);
                delivery.deliveryS = deliveryStatus.NONE;
                delivery.hasOrder = false;

                Models.Order co = unitOfWork.OrderRepository.Get(currentOrder.deliverymanId);
                co.isDelivered = true;

                unitOfWork.UserRepository.Update(u);
                unitOfWork.UserRepository.Update(delivery);
                unitOfWork.OrderRepository.Update(co);

                return "Success";
            }
            else
            {
                return null;
            }


        }

        public async Task<Models.Order[]> GetAllDeliveryOrders()
        {
            var AllOrders = unitOfWork.OrderRepository.GetAll();
            Models.Order[] orders = AllOrders.Cast<Models.Order>().ToArray();
            var AllProductOrders = unitOfWork.ProductOrderRepository.GetAll();
            var AllProducts = unitOfWork.ProductRepository.GetAll();

            List<Models.Order> userOrders = new List<Models.Order>();

            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i].isAccepted == false)
                {
                    userOrders.Add(orders[i]);
                }
            }

            orders = userOrders.ToArray();


            return orders;
        }

        public async Task<string> AcceptOrder(int id, string username)
        {
            User u = checkUsername(username);
            u = unitOfWork.UserRepository.Get(u.userId);
            Models.Order o = unitOfWork.OrderRepository.Get(id);

            if (o.isAccepted)
            {
                return "Accepted";
            }

            if (u.hasOrder)
            {
                return "Denied";
            }

            u.hasOrder = true;
            u.deliveryS = deliveryStatus.ACCEPTED;

            o.isAccepted = true;
            o.isDelivered = false;
            o.deliverymanId = u.userId;
            o.timeTillDelivery = DateTime.Now.AddMinutes(32);

            unitOfWork.UserRepository.Update(u);
            unitOfWork.OrderRepository.Update(o);

            return "Success";
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

        private Models.Order[] joinOrderItems(Models.Order[] orders)
        {
            //Models.Order[] temp = new Models.Order[0];
            List<Models.Order> temp = new List<Models.Order>();

            var AllProducts = unitOfWork.ProductRepository.GetAll();
            var AllProductOrders = unitOfWork.ProductOrderRepository.GetAll();

            foreach (var order in orders)
            {
                foreach (var PO in AllProductOrders)
                {
                    if (order.orderId == PO.OrderId) //nadji ID porudzbine u tabeli
                    {
                        foreach (var item in AllProducts) //nadji artikal u tabeli
                        {
                            if (PO.ProductId == item.id)
                            {
                                Models.Product p = item;
                                p.quantity = PO.ProductQuantity;
                                PO.Product = p;
                                order.orderItems.Add(PO);
                                temp.Add(order);
                            }
                        }
                    }
                }
            }


            return temp.ToArray();
        }
    }
}
