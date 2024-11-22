using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DingDongDelivey_Back.Models
{
    public class Product
    {
        //[Key]
        public int id { get; set; }
        public string name { get; set; }
        public float price{ get; set; }
        public float quantity { get; set; }
        public string ingredients{ get; set; }
        public bool isDeleted{ get; set; }
        public IList<ProductOrder> orders { get; set; }
    }
}
