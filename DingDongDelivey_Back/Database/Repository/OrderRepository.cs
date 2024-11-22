using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Database.Repository
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }
    }
}
