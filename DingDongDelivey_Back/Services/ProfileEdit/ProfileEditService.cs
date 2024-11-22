using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Account;

namespace DingDongDelivey_Back.Services.ProfileEdit
{
    public class ProfileEditService : IProfileEditService
    {
        private IUnitOfWork unitOfWork;
        private AppSettings appSettings;
        TokenService tokenService;
        ValidateService validateService;

        public ProfileEditService(AppSettings appSettings, IUnitOfWork unitOfWork)
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

        public async Task<string> SaveUserInfo(int id, User user)
        {
            if (checkUsername(user.userId, user.username) == false)
            {
                return "Username";
            }

            string pw = user.password;
            user.password = BCrypt.Net.BCrypt.HashPassword(pw);

            User u = unitOfWork.UserRepository.Get(id);

            u.username = user.username;
            u.firstName = user.firstName;
            u.lastName = user.lastName;
            u.password = user.password;
            u.dateOfBirth = user.dateOfBirth;
            u.address = user.address;

            unitOfWork.UserRepository.Update(u);
            return "Success";

        }

        private bool checkUsername(int id, string username)
        {
            var AllUser = unitOfWork.UserRepository.GetAll();
            foreach (var temp in AllUser)
            {
                if (temp.userId != id && temp.username == username)
                    return false;
            }
            return true;
        }
    }
}
