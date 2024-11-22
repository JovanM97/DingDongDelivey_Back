using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Services.Account
{
    interface IAccountService
    {
        public User CheckEmailForUser(string email);
        public string GetUserImage(string username);
    }
}
