using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Account;

namespace DingDongDelivey_Back.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private IUnitOfWork unitOfWork;
        private AppSettings appSettings;
        TokenService tokenService;
        ValidateService validateService;

        public ProfileService(AppSettings appSettings, IUnitOfWork unitOfWork)
        {
            //this.manager = manager;
            this.appSettings = appSettings;
            tokenService = new TokenService();
            this.unitOfWork = unitOfWork;
            validateService = new ValidateService();
        }

        public async Task<User> GetUserInfo(string username)
        {
            User u = checkUsername(username);
            if (username == "AdminDzin" || username == "Dzin")
            {
                u.image = GetUserImage(username);

            }
            return u;
        }

        private User checkUsername(string username)
        {
            var AllUser = unitOfWork.UserRepository.GetAll();
            foreach (var temp in AllUser)
            {
                if (temp.username == username)
                    return temp;
            }
            return null;
        }

        public string GetUserImage(string username)
        {
            var byteArrImg = File.ReadAllBytes(@"C:\Users\Jovan\source\repos\DingDongDelivey_Back\DingDongDelivey_Back\Database\Images\" + username + ".png");
            var base64Img = Convert.ToBase64String(byteArrImg);

            return base64Img;
        }
    }
}
