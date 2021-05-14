using System;
using System.Collections.Generic;
using System.Text;
using WebApi.DataAccess.Dao;

namespace WebApi.DataAccess.Interface
{
    public interface IOrderDetailRepository
    {
        public bool CreateOrderDetail(int order_id
           , string item, int price, string category);
        public IEnumerable<OrderDetail> GetOrderDetail(int order_id);
        public IEnumerable<OrderDetail> GetOrderDetails(List<int> order_ids);
    }
}
