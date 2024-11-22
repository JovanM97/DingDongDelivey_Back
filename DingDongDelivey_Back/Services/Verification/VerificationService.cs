using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Account;

namespace DingDongDelivey_Back.Services.Verification
{
    public class VerificationService : IVerificationService
    {
        private IUnitOfWork unitOfWork;
        private AppSettings appSettings;
        TokenService tokenService;
        ValidateService validateService;

        private IMailService mailService;

        public VerificationService(AppSettings appSettings, IUnitOfWork unitOfWork, IMailService mailService)
        {
            //this.manager = manager;
            this.appSettings = appSettings;
            tokenService = new TokenService();
            this.unitOfWork = unitOfWork;
            validateService = new ValidateService();
            this.mailService = mailService;
        }

        public async Task<User[]> GetAllUsers()
        {
            var AllUser = unitOfWork.UserRepository.GetAll();

            User[] users = AllUser.Cast<User>().ToArray();

            return users;
        }
        
        public async Task<string> AcceptUser(int id)
        {
            User u = checkUserId(id);

            if (u.isActive == false)
            {
                if (u.isDeleted == false)
                {
                    u.isActive = true;
                    unitOfWork.UserRepository.Update(u);

                    MailModel mail = new MailModel()
                    {
                        ToEmail = "srdjandzinovic97@gmail.com",
                        //ToEmail = u.email,
                        Subject = "Account Approved",
                        Body = "Congratulations, your account delivery has been approved"
                    };

                    await mailService.SendEmailAsync(mail);

                    return "Success";
                }
                else
                {
                    return "Deleted";
                }
            }
            else
            {
                return "Approved";
            }
        }

        public async Task<string> RejectUser(int id)
        {
            User u = checkUserId(id);

            if (u.isActive == false)
            {
                if (u.isDeleted == false)
                {
                    u.isDeleted = true;
                    unitOfWork.UserRepository.Update(u);

                    MailModel mail = new MailModel()
                    {
                        ToEmail = "srdjandzinovic97@gmail.com",
                        //ToEmail = u.email,
                        Subject = "Account Approved",
                        Body = "Your account has been rejected"
                    };

                    await mailService.SendEmailAsync(mail);

                    return "Success";
                }
                else
                {
                    return "Deleted";
                }
            }
            else
            {
                return "Approved";
            }
        }

        private User checkUserId(int id)
        {
            var AllUser = unitOfWork.UserRepository.GetAll();
            foreach (var temp in AllUser)
            {
                if (temp.userId == id)
                    return temp;
            }
            return null;
        }
    }
}
