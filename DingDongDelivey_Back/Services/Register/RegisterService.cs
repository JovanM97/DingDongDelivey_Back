using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Account;

namespace DingDongDelivey_Back.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private IUnitOfWork unitOfWork;
        private AppSettings appSettings;
        TokenService tokenService;
        ValidateService validateService;

        public RegisterService(AppSettings appSettings, IUnitOfWork unitOfWork)
        {
            //this.manager = manager;
            this.appSettings = appSettings;
            tokenService = new TokenService();
            this.unitOfWork = unitOfWork;
            validateService = new ValidateService();
        }

        public async Task<string[]> Register(User user)
        {
            string[] ret;
            if (!validateService.ValidateEmail(user.email))
            {
                ret = new string[] { "Error", "Email format is incorrect." };
                return ret;
            }
            if (checkIfUserExists(user.email, user.username) == 1)
            {
                ret = new string[] { "Error", "The email is already taken." };
                return ret;
            }
            else if (checkIfUserExists(user.email, user.username) == 2)
            {
                ret = new string[] { "Error", "The username is already taken." };
                return ret;
            }
            else //if (checkIfUserExists(user.email, user.username) == 0) //add new user
            {
                User temp = new User();
                temp.username = user.username;
                temp.email = user.email;

                temp.password = BCrypt.Net.BCrypt.HashPassword(user.password);

                temp.userT = user.userT;
                temp.firstName = user.firstName;
                temp.lastName = user.lastName;
                temp.dateOfBirth = user.dateOfBirth;
                temp.address = user.address;

                temp.image = user.image;
                //temp.image = MakeImageCopy(user.image, user.username);
                
                if (user.userT == userType.DELIVERYMAN)
                {
                    temp.isActive = false;
                } else
                {
                    temp.isActive = true;
                }
                temp.isDeleted = false;
                //temp.userId = getUserId(); //DB sam zadaje ID

                unitOfWork.UserRepository.Add(temp);
                //unitOfWork.UserRepository.Update();
                string token = tokenService.generateToken(temp, this.appSettings);
                ret = new string[] { token, "Registration successfull.", temp.username };
                return ret;
            }
        }


        private int checkIfUserExists(string email, string username)
        {
            var AllUser = unitOfWork.UserRepository.GetAll();
            foreach (var temp in AllUser)
            {
                if (temp.email == email)
                    return 1;
                if (temp.username == username)
                    return 2;
            }
            return 0;
        }

        private int getUserId()
        {
            var AllUser = unitOfWork.UserRepository.GetAll();
            int id = AllUser.Count() + 1;

            return id;
        }

        private string MakeImageCopy(string src, string username)
        {
            string dest = ".../DingDongDelivey_Back/Database/Images/" + username;
            System.IO.File.Copy(src, dest);

            return dest;
        }
    }
}
