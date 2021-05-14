using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DataAccess.Interface
{
    public interface IUserRepository
    {
        public bool CreateAccount(string email, string phone, string password);
        public bool UpdateAccount(string email, string phone, string password);
    }
}
