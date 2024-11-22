using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Services.Account;

namespace DingDongDelivey_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Angular")]
    public class AccountController : ControllerBase
    {
        IAccountService Service;
        public AccountController(IUnitOfWork repo)
        {
            Service = new AccountService(repo);
        }

        [HttpGet]
        [Route("checkToken")]
        public bool checkToken()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                return true; ;
            }
            else
            {
                return false;
            }

        }
    }
}
