using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Models;

namespace DingDongDelivey_Back.Services.Account
{
    public interface IMailService
    {
        Task SendEmailAsync(MailModel mailRequest);
    }
}
