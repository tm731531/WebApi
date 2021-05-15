using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Area.OrderControllers.Model;
using WebApi.Service;
using WebApi.Service.Model;

namespace WebApi.Area.OrderControllers
{
    [Route("api/Count/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        // GET: api/Order/Tom
        [HttpGet("{buyer}", Name = "Get")]
        public JsonResult Get(string buyer)
        {
            CreateOrderDto createOrderDto = new CreateOrderDto();
            OrderService orderService = new OrderService();
            var orderBO =   createOrderDto.CreateOrderBO(buyer);

            var data =  createOrderDto.CreateOrderOutVM(orderService.GetOrder(orderBO));
            return new JsonResult(new { result = data });
        }

        // POST: api/Order
        [HttpPost]
        public JsonResult Post([FromBody] CreateOrderInputVM value)
        {
            var returnValue = false;
            CreateOrderDto createOrderDto = new CreateOrderDto();
            OrderService orderService = new OrderService();
            var orderBO = createOrderDto.CreateOrderBO(value);
            if (ValidationAccountData(orderBO))
            {
                returnValue= orderService.CreateOrder(orderBO);
            }
            return new JsonResult(new { result = returnValue });

        }

        #region private area
        private bool ValidationAccountData(OrderBO data)
        {

            OrderService orderService = new OrderService();

            if (orderService.CheckTotalPriceMustMoreThanDiscount(data.totalPrice, data.discount) &&
                orderService.CheckTotalPriceEqualEachItemsTotal(data.totalPrice, data.orderDetail.Sum(x => x.price)))
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
