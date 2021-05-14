using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using WebApi.DataAccess.Dao;
using WebApi.DataAccess.Interface;

namespace WebApi.DataAccess.MSSQL
{
    public class OrderRepository : IOrderRepository
    {

        private bool disposedValue = false;
        private IDatabaseConnectionHelper _DatabaseConnection;

        internal OrderRepository(IDatabaseConnectionHelper databaseConnectionHelper)
        {
            _DatabaseConnection = databaseConnectionHelper;
        }



        public int CreateOrder(string buyer, int total_price, int discount)
        {


            var returnValue = 0;
            try
            {

                var sql = @"INSERT INTO [dbo].[order]
                                   ([buyer]
                                   ,[total_price]
                                   ,[discount]
                                   ,[order_date] )
                             OUTPUT INSERTED.Id
                             VALUES
                                   (@buyer
                                   ,@total_price
                                   ,@discount
                                   ,@order_date)";
                using (var conn = _DatabaseConnection.Create())
                {


                    returnValue= conn.QuerySingle<int>(sql, new
                    {
                        buyer = buyer,
                        total_price = total_price,
                        discount = discount,
                        order_date = DateTime.Now
                    });
                }
            }
            catch { }

            return returnValue;
        }
        public IEnumerable<Order> GetOrder(string buyer)
        {
            try
            {

                var sql = @" SELECT * 
                             FROM [dbo].[order]
                             WHERE [buyer] = @buyer";
                using (var conn = _DatabaseConnection.Create())
                {
                    return conn.Query<Order>(sql, new
                    {
                        buyer = buyer
                    });
                }

            }
            catch
            {
                return null;
            }
        }
    }
}
