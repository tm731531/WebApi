using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Area.AccountControllers.Model
{
    public class CreateAccountInputVM
    {
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
