using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Area.OrderControllers.Model
{
    public class CreateOrderInputVM
    {
        public List<CreateOrderInputVMDetailData> detailDatas { get; set; }
     
    }
    public class CreateOrderInputVMDetailData

    {
        public string buyer { get; set; }
        public int totalPrice { get; set; }
        public int discount { get; set; }

        public string item { get; set; }

        public int price { get; set; }

        public string category { get; set; }
    }

}
