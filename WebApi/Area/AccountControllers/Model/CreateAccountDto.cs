using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Area.AccountControllers.Model

{
    public class CreateAccountDto
    {
        private CreateAccountInputVM value;

        public CreateAccountDto(CreateAccountInputVM value)
        {
            this.value = value;
        }


        public string password => value.password;
        public string email => value.email;
        public string phone => value.phone;
    }
}
