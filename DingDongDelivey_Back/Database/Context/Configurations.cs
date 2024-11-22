using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Database.Context
{
    public static class Configurations
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Users
            var User1 = new User()
            {
                userId = 1,
                username = "AdminDzin",
                email = "srdjandzinovic97@gmail.com",
                password = BCrypt.Net.BCrypt.HashPassword("dzin123"),
                firstName = "Srdjan",
                lastName = "Dzinovic",
                dateOfBirth = new DateTime(1997, 1, 4),
                address = "Novi Sad",
                userT = userType.ADMIN,
                image = "",
                isActive = true,
                orders = new Order[0],
                deliveryS = deliveryStatus.NONE,
                hasOrder = false,
                //order = new Order(),
                isDeleted = false
            };

            var User2 = new User()
            {
                userId = 2,
                username = "DeliveryDzin",
                email = "deliverydzin@gmail.com",
                password = BCrypt.Net.BCrypt.HashPassword("dzin123"),
                firstName = "Srdjan",
                lastName = "Dzinovic",
                dateOfBirth = new DateTime(1997, 1, 4),
                address = "Novi Sad",
                userT = userType.DELIVERYMAN,
                image = "",
                isActive = true,
                orders = new Order[0],
                deliveryS = deliveryStatus.NONE,
                hasOrder = false,
                //order = new Order(),
                isDeleted = false
            };

            var User3 = new User()
            {
                userId = 3,
                username = "BuyerDzin",
                email = "buyerdzin@gmail.com",
                password = BCrypt.Net.BCrypt.HashPassword("dzin123"),
                firstName = "Srdjan",
                lastName = "Dzinovic",
                dateOfBirth = new DateTime(1997, 1, 4),
                address = "Novi Sad",
                userT = userType.BUYER,
                image = "",
                isActive = true,
                orders = new Order[0],
                deliveryS = deliveryStatus.NONE,
                hasOrder = true,
                //order = new Order(),
                isDeleted = false
            };

            var User4 = new User()
            {
                userId = 4,
                username = "DeliveryDzin2",
                email = "deliverydzin2@gmail.com",
                password = BCrypt.Net.BCrypt.HashPassword("dzin123"),
                firstName = "Srdjan",
                lastName = "Dzinovic",
                dateOfBirth = new DateTime(1997, 1, 4),
                address = "Novi Sad",
                userT = userType.DELIVERYMAN,
                image = "",
                isActive = false,
                orders = new Order[0],
                deliveryS = deliveryStatus.NONE,
                hasOrder = false,
                //order = new Order(),
                isDeleted = false
            };


            modelBuilder.Entity<User>().HasData(
               User1, User2, User3, User4
           );
            #endregion

            #region Products
            var product1 = new Product()
            {
                id = 1,
                name = "Chicken Burrito",
                price = 410,
                quantity = -1,
                ingredients = "Chicken, beans, rice, tomatoes, corn, red salsa, nacho",
                isDeleted = false
            };
            var product2 = new Product()
            {
                id = 2,
                name = "Beef Burger",
                price = 550,
                quantity = -1,
                ingredients = "100% beef burger, bacon, letuce, tomatoes, onions, secret sauce",
                isDeleted = false
            };
            var product3 = new Product()
            {
                id = 3,
                name = "Pizza Margharita 24cm",
                price = 320,
                quantity = -1,
                ingredients = "Tomato sauce, mozzarella, basil",
                isDeleted = false
            };
            var product4 = new Product()
            {
                id = 4,
                name = "Pizza Margharita 32cm",
                price = 460,
                quantity = -1,
                ingredients = "Tomato sauce, mozzarella, basil",
                isDeleted = false
            };


            modelBuilder.Entity<Product>().HasData(
               product1, product2, product3, product4
           );
            #endregion

            #region ProductOrders

            var ProductOrder1 = new ProductOrder()
            {
                OrderId = 1,
                ProductId = 1,
                ProductQuantity = 1
            };

            var ProductOrder2 = new ProductOrder()
            {
                OrderId = 1,
                ProductId = 2,
                ProductQuantity = 2
            };

            var ProductOrder3 = new ProductOrder()
            {
                OrderId = 2,
                ProductId = 3,
                ProductQuantity = 2
            };

            var ProductOrder4 = new ProductOrder()
            {
                OrderId = 2,
                ProductId = 4,
                ProductQuantity = 2
            };

            var ProductOrder5 = new ProductOrder()
            {
                OrderId = 3,
                ProductId = 3,
                ProductQuantity = 3
            };

            var ProductOrder6 = new ProductOrder()
            {
                OrderId = 3,
                ProductId = 4,
                ProductQuantity = 1
            };

            modelBuilder.Entity<ProductOrder>().HasData(
               ProductOrder1, ProductOrder2, ProductOrder3, ProductOrder4, ProductOrder5, ProductOrder6
            );

            #endregion

            #region Orders
            var order1 = new Order()
            {
                orderId = 1,
                //orderItems = new ProductOrder[2] { ProductOrder1, ProductOrder2 },
                orderAddress = "Futoska 120",
                orderPrice = 1110,
                orderComment = "",
                buyerId = 3,
                //buyer = User3,
                deliverymanId = 2,
                isAccepted = true,
                timeTillDelivery = new DateTime(2022, 6, 8, 16, 30, 0),
                isDelivered = false

            };
            var order2 = new Order()
            {
                orderId = 2,
                //orderItems = new ProductOrder[2] { ProductOrder3, ProductOrder4 },
                orderAddress = "Bulevar Oslobodjenja 220",
                orderPrice = 930,
                orderComment = "",
                buyerId = 3,
                //buyer = User3,
                deliverymanId = 2,
                isAccepted = true,
                timeTillDelivery = new DateTime(2022, 6, 1, 16, 30, 0),
                isDelivered = true

            };
            var order3 = new Order()
            {
                orderId = 3,
                //orderItems = new ProductOrder[2] { ProductOrder3, ProductOrder4 },
                orderAddress = "Bulevar Oslobodjenja 220",
                orderPrice = 930,
                orderComment = "",
                buyerId = 3,
                //buyer = User3,
                deliverymanId = 2,
                isAccepted = false,
                timeTillDelivery = new DateTime(2022, 7, 13, 23, 30, 0),
                isDelivered = false

            };


            modelBuilder.Entity<Order>().HasData(
               order1, order2, order3
            );


            #endregion
        }
    }
}
