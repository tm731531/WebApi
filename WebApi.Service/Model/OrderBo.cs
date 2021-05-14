using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.DataAccess.Dao;

namespace WebApi.Service.Model
{
    public class OrderBO
    {

        public List<OrderBO> returnBO;
        public string buyer { get; set; }
        public int totalPrice { get; set; }
        public string discount { get; set; }
        public List<OrderDetailBO> orderDetail { get; set; }

        internal void Combine(IEnumerable<Order> orders, IEnumerable<OrderDetail> detailData)
        {
            returnBO = new List<OrderBO>();
            OrderBO bO = new OrderBO();
            foreach (var data in orders)
            {
                bO.buyer = data.buyer;
                bO.totalPrice = data.total_price;
                bO.discount = data.discount;
                bO.orderDetail = (from x in detailData
                                  where x.order_id == data.id
                                  select new OrderDetailBO
                                  {
                                      category = x.category,
                                      item = x.item,
                                      price = x.price
                                  }).ToList();
                returnBO.Add(bO);
            }
        }
    }
    public class OrderDetailBO
    {

        public string item { get; set; }

        public int price { get; set; }

        public string category { get; set; }
    }

}
