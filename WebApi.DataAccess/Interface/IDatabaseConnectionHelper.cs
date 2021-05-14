using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebApi.DataAccess.Interface
{
    interface IDatabaseConnectionHelper
    {
        IDbConnection Create();
    }
}
