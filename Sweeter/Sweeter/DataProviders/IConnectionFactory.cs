using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sweeter.DataProviders
{
    public class IConnectionFactory
    {
        SqlConnection CreateConnection { get; }
    }
}
