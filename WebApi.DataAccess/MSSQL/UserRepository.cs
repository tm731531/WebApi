using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using WebApi.DataAccess.Interface;

namespace WebApi.DataAccess.MSSQL
{
    public class UserRepository : IUserRepository
    {

        private bool disposedValue = false;
        private IDatabaseConnectionHelper _DatabaseConnection;

        internal UserRepository(IDatabaseConnectionHelper databaseConnectionHelper)
        {
            _DatabaseConnection = databaseConnectionHelper;
        }

        public bool CreateAccount(string email, string phone, string password)
        {
            var returnValue = false;
            try
            {

                var sql = @"INSERT INTO [dbo].[user]
                                   ([email]
                                   ,[phone]
                                   ,[password])
                             VALUES
                                   (@email
                                   ,@phone
                                   ,@password)";
                using (var conn = _DatabaseConnection.Create())
                {
                    conn.Execute(sql, new { email = email,phone = phone,password = password });
                }
                returnValue = true ;

            }
            catch { }

            return returnValue;
        }

        public bool UpdateAccount(string email, string phone, string password)
        {
            var returnValue = false;
            try
            {

                var sql = @"UPDATE [dbo].[user]
                            SET    [password]=@password
                            WHERE  [email]=@email";
                using (var conn = _DatabaseConnection.Create())
                {
                    conn.Execute(sql, new { email = email, password = password });
                }
                returnValue = true;
            }
            catch { }

            return returnValue;
        }
    }
}
