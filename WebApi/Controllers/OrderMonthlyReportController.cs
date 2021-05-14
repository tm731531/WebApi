using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model.Dto;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMonthlyReportController : ControllerBase
    {
        // GET: api/OrderMonthlyReport
        [HttpGet]
        public JsonResult Get()
        {
            CreateOrderDto createOrderDto = new CreateOrderDto();
            OrderService orderService = new OrderService();
            var orderBO = createOrderDto.CreateOrderBO("");
            var data = createOrderDto.CreateOrderMonthlyReportOutVM(orderService.GetOrder(orderBO));
            return new JsonResult(new { result = data });
        }

    }
}
