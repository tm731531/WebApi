using System;
using System.Collections.Generic;
using System.Text;
using WebApi.DataAccess;

namespace WebApi.Service
{
    public class AccountService
    {
        MainRepository mainRepository = new MainRepository();

        public bool CreateAccount(string email, string phone, string password)
        {

            bool retrunValue = true;
            try
            {
                mainRepository.UserRepository.CreateAccount(email, phone, password);


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

        public bool UpdateAccount(string email, string phone, string password)
        {

            bool retrunValue = true;
            try
            {
                mainRepository.UserRepository.UpdateAccount(email, phone, password);

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


        #region Check area

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

        #endregion
        #region private area
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
        #endregion
    }
}
