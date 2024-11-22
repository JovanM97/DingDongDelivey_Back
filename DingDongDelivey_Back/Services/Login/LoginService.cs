using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Account;

namespace DingDongDelivey_Back.Services.Login
{
    public class LoginService : ILoginService
    {
        private IUnitOfWork unitOfWork;
        private AppSettings appSettings;
        TokenService tokenService;
        ValidateService validateService;

        public LoginService(AppSettings appSettings, IUnitOfWork unitOfWork)
        {
            //this.manager = manager;
            this.appSettings = appSettings;
            tokenService = new TokenService();
            this.unitOfWork = unitOfWork;
            validateService = new ValidateService();
        }

        public async Task<string[]> Login(string email, string password)
        {
            string[] ret;
            if (!validateService.ValidateEmail(email))
            {
                ret = new string[] { "Error", "Email format is incorrect." };
                return ret;
            }
            User loginUser = checkUser(email, password);

            if (loginUser != null)
            {

                string token = tokenService.generateToken(loginUser, this.appSettings);
                ret = new string[] { token, loginUser.userT.ToString(), loginUser.username };


                return ret;
            }
            else
            {
                ret = new string[] { "Error", "Email or password is incorrect." };
                return ret;

            }

        }

        public async Task<string[]> SocialLogin(User user)
        {
            string[] ret;
            if (!validateService.ValidateEmail(user.email))
            {
                ret = new string[] { "Error", "Email format is incorrect." };
                return ret;
            }
            User loginUser = checkEmail(user.email);

            if (loginUser != null)
            {

                string token = tokenService.generateToken(loginUser, this.appSettings);
                ret = new string[] { token, loginUser.userT.ToString(), loginUser.username };


                return ret;
            }
            else
            {

                User temp = new User();
                temp.username = user.email;
                temp.email = user.email;

                temp.password = BCrypt.Net.BCrypt.HashPassword(user.password);

                temp.userT = userType.BUYER;
                temp.firstName = user.firstName;
                temp.lastName = user.lastName;
                temp.dateOfBirth = user.dateOfBirth;
                temp.address = "Novi Sad";

                temp.isActive = true;
                temp.isDeleted = false;

                unitOfWork.UserRepository.Add(temp);

                string token = tokenService.generateToken(loginUser, this.appSettings);
                ret = new string[] { token, temp.userT.ToString(), temp.username };
                return ret;

            }

        }

        private User checkUser(string email, string password)
        {
            var AllUser = unitOfWork.UserRepository.GetAll();
            foreach (var temp in AllUser)
            {
                if (temp.username != "Dzin")
                {
                    if (temp.email == email && BCrypt.Net.BCrypt.Verify(password, temp.password)) //temp.password == password
                        return temp;
                } else
                {
                    if (temp.email == email && temp.password == password) //temp.password == password
                        return temp;
                }

            }
            return null;
        }

        private User checkEmail(string email)
        {
            var AllUser = unitOfWork.UserRepository.GetAll();
            foreach (var temp in AllUser)
            {
                if (temp.email == email)
                {
                    return temp;
                }
            }
            return null;
        }
    }
}
