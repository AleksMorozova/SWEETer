using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sweeter.DataProviders
{
    public class ConnectionFactory: IConnectionFactory
    {
        readonly string connStr;
        public ConnectionFactory(string connStr)
        {
            this.connStr = System.Configuration.ConfigurationManager.ConnectionStrings[connStr].ConnectionString; ;
        }
        public SqlConnection CreateConnection
        {
            get
            {
                return new SqlConnection(this.connStr);
            }
        }
    }
}
