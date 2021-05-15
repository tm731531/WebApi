using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Service.Deal.Model;

namespace WebApi.Area.OrderControllers.Model
{
    public class CreateOrderDto
    {
        public OrderBO CreateOrderBO(CreateOrderInputVM createOrderInputVM)
        {
            OrderBO orderBO = new OrderBO();
            orderBO.buyer = createOrderInputVM.detailDatas.First().buyer;
            orderBO.discount = createOrderInputVM.detailDatas.First().discount;
            orderBO.totalPrice = createOrderInputVM.detailDatas.First().price;
            orderBO.orderDetail = (from x in createOrderInputVM.detailDatas
                                   select new OrderDetailBO
                                   {
                                       category = x.category,
                                       price = x.price,
                                       item = x.item

                                   }).ToList();



            return orderBO;

        }

        internal object CreateOrderMonthlyReportOutVM(OrderBO orderBO)
        {
            
            return new { month=DateTime.Now, data= orderBO.orderDetail.GroupBy(x => x.item) } ;
        }

        internal object CreateOrderOutVM(OrderBO orderBO)
        {
            return orderBO;
        }

        public OrderBO CreateOrderBO(string buyer)
        {
            OrderBO orderBO = new OrderBO();
            orderBO.buyer = buyer;
            return orderBO;

        }
    }
}
