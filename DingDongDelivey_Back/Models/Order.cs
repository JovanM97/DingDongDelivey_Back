using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DingDongDelivey_Back.Models
{
    public class Order
    {
        //[Key]
        public int orderId { get; set; }
        public IList<ProductOrder> orderItems { get; set; }
        public string orderAddress{ get; set; }
        public float orderPrice{ get; set; }
        public string orderComment{ get; set; }
        public int buyerId { get; set; }
        public int deliverymanId { get; set; }
        public User buyer{ get; set; }
        public bool isAccepted { get; set; }
        public DateTime timeTillDelivery{ get; set; }
        public bool isDelivered{ get; set; }
    }
}
