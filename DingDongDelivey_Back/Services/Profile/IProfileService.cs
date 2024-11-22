using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Services.Profile
{
    interface IProfileService
    {
        public Task<User> GetUserInfo(string username);

    }
}
