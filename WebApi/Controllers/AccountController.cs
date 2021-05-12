using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Service;
using WebApi.Service.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountService accountService = new AccountService();


        // POST: api/Account
        [HttpPost]
        public void Post([FromBody]CreateAccountDto value)
        {

            accountService.CreateAccount(value);
        }


    }
}
