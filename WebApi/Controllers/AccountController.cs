using Microsoft.AspNetCore.Mvc;
using WebApi.Model.Dto;
using WebApi.Model.ViewModel;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountService accountService = new AccountService();


        // POST: api/Account
        [HttpPost]
        public void Post([FromBody]CreateAccountInputVM value)
        {

            if (ValidationAccountData(value)) {
                
                accountService.CreateAccount(value.email, value.phone, value.password);

            }
        }

        private bool ValidationAccountData(CreateAccountInputVM data)
        {

            var tempData = new CreateAccountDto(data);

            if (accountService.CheckPassword(tempData.password) &&
                accountService.CheckPhone(tempData.phone) &&
                accountService.CheckEmail(tempData.email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
