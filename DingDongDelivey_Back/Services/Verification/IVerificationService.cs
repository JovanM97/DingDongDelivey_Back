using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Services.Verification
{
    interface IVerificationService
    {
        public Task<User[]> GetAllUsers();
        public Task<string> AcceptUser(int id);
        public Task<string> RejectUser(int id);
    }
}
