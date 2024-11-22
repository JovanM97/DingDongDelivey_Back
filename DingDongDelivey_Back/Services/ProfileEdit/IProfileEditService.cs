using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Services.ProfileEdit
{
    interface IProfileEditService
    {
        public Task<User> GetUserInfo(string username);
        public Task<string> SaveUserInfo(int id, User user);
    }
}
