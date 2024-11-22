using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DingDongDelivey_Back.Models
{
    public enum userType
    {
        ADMIN,
        DELIVERYMAN,
        BUYER,
        NONE
    }

    public enum deliveryStatus
    {
        PROCESSING,
        ACCEPTED,
        DECLINED,
        NONE
    }

    public class User
    {
        //[Key]
        public int userId { get; set; }
        public string username { get; set; }
        public string email{ get; set; }
        public string password{ get; set; }
        public string firstName{ get; set; }
        public string lastName{ get; set; }
        public DateTime dateOfBirth{ get; set; }
        public string address{ get; set; }
        public userType userT{ get; set; }
        public string image{ get; set; }
        public bool isActive{ get; set; }

        public deliveryStatus deliveryS{ get; set; }
        public bool hasOrder{ get; set; }
        public IList<Order> orders{ get; set; }

        public bool isDeleted{ get; set; }

        public User() { }
    }
}
