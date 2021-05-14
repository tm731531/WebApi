using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using WebApi.DataAccess.Dao;
using WebApi.DataAccess.Interface;

namespace WebApi.DataAccess.MSSQL
{
    public class OrderDetailRepository : IOrderDetailRepository
    {

        private bool disposedValue = false;
        private IDatabaseConnectionHelper _DatabaseConnection;

        internal OrderDetailRepository(IDatabaseConnectionHelper databaseConnectionHelper)
        {
            _DatabaseConnection = databaseConnectionHelper;
        }



        public bool CreateOrderDetail(int order_id, string item, int price, string category)
        {
            var returnValue = false;
            try
            {

                var sql = @"INSERT INTO [dbo].[order_detail]
                                   ([order_id]
                                   ,[item]
                                   ,[price]
                                   ,[category] )
                             VALUES
                                   (@order_id
                                   ,@item
                                   ,@price
                                   ,@category)";
                using (var conn = _DatabaseConnection.Create())
                {
                    conn.Execute(sql, new
                    {
                        order_id = order_id,
                        item = item,
                        price = price,
                        category = category
                    });
                }
                returnValue = true;

            }
            catch { }

            return returnValue;
        }
        public IEnumerable<OrderDetail> GetOrderDetail(int order_id)
        {
            try
            {

                var sql = @" SELECT * 
                             FROM [dbo].[order_detail]
                             WHERE [order_id] = @order_id";
                using (var conn = _DatabaseConnection.Create())
                {
                    return conn.Query<OrderDetail>(sql, new
                    {
                        order_id = order_id
                    });
                }

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetails(List<int> order_ids)
        {
            try
            {

                var sql = @" SELECT * 
                             FROM [dbo].[order_detail]
                             WHERE [order_id] in ( @order_id )";
                using (var conn = _DatabaseConnection.Create())
                {
                    return conn.Query<OrderDetail>(sql, new
                    {
                        order_id = string.Join("," ,order_ids)
                    });;
                }

            }
            catch
            {
                return null;
            }
        }
    }
}
