using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WebApi.DataAccess.Dao;

namespace WebApi.DataAccess.Interface
{
    public interface IOrderRepository
    {
        public int CreateOrder( string buyer
            , int total_price, string discount);
        public IEnumerable<Order> GetOrder( string buyer);
    }
}
