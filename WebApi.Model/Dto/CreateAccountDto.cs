﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Model.Dto
{
    public class CreateAccountDto
    {
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
    }
}
