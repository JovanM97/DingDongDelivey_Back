using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDongDelivey_Back.Models
{
    public class AuthentificationUser : IdentityUser
    {
        public bool IsPasswordOk { get; set; }
        public AuthentificationUser() : base() { }
        public AuthentificationUser(string username) : base(username) { }
    }
}
