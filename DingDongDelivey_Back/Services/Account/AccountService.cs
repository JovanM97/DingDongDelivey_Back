using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Services.Account
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork unitOfWork;
        private ValidateService validateService = new ValidateService();

        public AccountService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public User CheckEmailForUser(string email)
        {
            User ret = null;
            try
            {
                ret = unitOfWork.UserRepository.GetAll().Where(U => U.email == email)?.First();
            }
            catch
            {
                return null;
            }
            return ret;
        }

        public string GetUserImage(string username)
        {
            var byteArrImg = File.ReadAllBytes(".../DingDongDelivey_Back/Database/Images/" + username);
            var base64Img = Convert.ToBase64String(byteArrImg);

            return base64Img;
        }
    }
}
