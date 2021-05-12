using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model.ViewModel
{
    public class CreateAccountInputVM
    {
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
