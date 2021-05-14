using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using WebApi.DataAccess;

using WebApi.Service.Model;

namespace WebApi.Service
{
    public class OrderService
    {
        MainRepository mainRepository = new MainRepository();
        public bool CreateOrder(OrderBO orderBO)
        {

            bool retrunValue = true;
            try
            {
                using (var tranScope = new TransactionScope())
                {
                    var orderID = mainRepository.OrderRepository.CreateOrder(orderBO.buyer, orderBO.totalPrice, orderBO.discount);

                    foreach (var detailData in orderBO.orderDetail)
                    {
                        mainRepository.OrderDetailRepository.CreateOrderDetail(orderID, detailData.item, detailData.price, detailData.category);

                    }
                    tranScope.Complete();
                }
            }
            catch (Exception)
            {

                retrunValue = false;
            }

            return retrunValue;
        }

        public OrderBO GetOrder(OrderBO orderBO)
        {

            try
            {
                using (var tranScope = new TransactionScope())
                {
                    var orders = mainRepository.OrderRepository.GetOrder(orderBO.buyer);


                    var detailData = mainRepository.OrderDetailRepository
                        .GetOrderDetails(orders.Select(x => x.id).Distinct().ToList());

                    orderBO.Combine(orders, detailData);
                    tranScope.Complete();
                }
            }
            catch (Exception)
            {

            }
            return orderBO;
        }

        public bool CheckTotalPriceEqualEachItemsTotal(int totalPrice, int sumItemsPrice)
        {
            bool returnValue = false;
            if (totalPrice== sumItemsPrice) { returnValue = true; }
            else { }
            return returnValue;
        }

        public bool CheckTotalPriceMustMoreThanDiscount(int totalPrice, int discount)
        {
            bool returnValue = false;
            if (totalPrice > discount){ returnValue = true; }
            else { }
            return returnValue;
        }
    }
}
