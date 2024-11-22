using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Services.Register
{
    interface IRegisterService
    {
        public Task<string[]> Register(User user);
    }
}
