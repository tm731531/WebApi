using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Model.Dto;
namespace WebApi.Service
{
    public class AccountService
    {

        public bool CreateAccount(CreateAccountDto createAccountDto)
        {

            bool retrunValue = true;
            if (createAccountDto.email.Length > 30)
            {
                retrunValue = false;
            }
            if (!createAccountDto.phone.StartsWith("0"))
            {
                retrunValue = false;
            }

            if (Check(createAccountDto.password))
            {
                retrunValue = false;
            }

            return retrunValue;
        }

        private bool Check(string password)
        {
            return false;
        }
    }
}
