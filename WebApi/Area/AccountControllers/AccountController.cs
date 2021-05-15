using Microsoft.AspNetCore.Mvc;
using WebApi.Area.AccountControllers.Model;
using WebApi.Service;

namespace WebApi.Area.AccountControllers
{
    [Route("api/Account/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountService accountService = new AccountService();


        // POST: api/Account
        [HttpPost]
        public JsonResult Post([FromBody]CreateAccountInputVM value)
        {
            var returnValue = false;

            if (ValidationAccountData(value))
            {

                returnValue= accountService.CreateAccount(value.email, value.phone, value.password);

            }
            return new JsonResult(new { result = returnValue });
        } 
        // Put: api/Account
        [HttpPut]
        public JsonResult Put([FromBody]CreateAccountInputVM value)
        {
            var returnValue = false;

            if (ValidationAccountData(value))
            {

                returnValue= accountService.CreateAccount(value.email, value.phone, value.password);

            }
            return new JsonResult(new { result = returnValue });
        }



        #region private area
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
        #endregion
    }
}
