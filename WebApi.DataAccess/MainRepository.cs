using System;
using System.Collections.Generic;
using System.Text;
using WebApi.DataAccess.Interface;
using WebApi.DataAccess.MSSQL;

namespace WebApi.DataAccess
{
    public class MainRepository
    {
        public IUserRepository UserRepository;
        public IOrderRepository OrderRepository;
        public IOrderDetailRepository OrderDetailRepository;
        public MainRepository()

        {
            UserRepository = new UserRepository(new DBHelper());
            OrderRepository = new OrderRepository(new DBHelper());
            OrderDetailRepository = new OrderDetailRepository(new DBHelper());


        }
    }
}
