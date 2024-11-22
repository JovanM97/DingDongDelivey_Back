using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Services.Login
{
    public interface ILoginService
    {
        public Task<string[]> Login(string email, string password);
        public Task<string[]> SocialLogin(User user);
    }
}
