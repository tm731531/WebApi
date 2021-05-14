using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApi.DataAccess.Interface;

namespace WebApi.DataAccess
{
    public class DBHelper : IDatabaseConnectionHelper
    {
        private readonly string _connectionString;

        public DBHelper()
        {
            _connectionString = "從CONFIG或是設定";
        }

        public IDbConnection Create()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            return sqlConnection;
        }
    }
}
