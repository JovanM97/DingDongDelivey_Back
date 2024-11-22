using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDongDelivey_Back.Models
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
