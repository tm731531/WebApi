using System;
using System.Collections.Generic;
using System.Text;
namespace WebApi.Service
{
    public class AccountService
    {

        public bool CreateAccount(string email, string phone, string password)
        {

            bool retrunValue = true;
            //帶資料 去創帳號了
            try
            {
            }
            catch (Exception)
            {

                retrunValue = false;
            }
            if (email == "false")
            {
                retrunValue = false;
            }
            return retrunValue;
        }

        public bool CheckEmail(string email)
        {

            bool retrunValue = true;
            if (email.Length > 30)
            {
                retrunValue = false;
            }
            else
            {

            }
            return retrunValue;
        }
        public bool CheckPhone(string phone)
        {
            bool retrunValue = true;
            if (!phone.StartsWith("0"))
            {
                retrunValue = false;
            }
            else
            {
            }
            return retrunValue;
        }

        public bool CheckPassword(string password)
        {

            bool retrunValue = false;
            if (Check(password))
            {
                retrunValue = true;
            }
            else
            {
                retrunValue = false;
            }
            return retrunValue;
        }
        private bool Check(string password)
        {
            if (password == "password")
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
