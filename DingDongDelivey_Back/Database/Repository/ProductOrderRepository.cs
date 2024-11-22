using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Database.Repository
{
    public class ProductOrderRepository : Repository<ProductOrder, int>, IProductOrderRepository
    {
        public ProductOrderRepository(AppDbContext context) : base(context) { }
    }
}
