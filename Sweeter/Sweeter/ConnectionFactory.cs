using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sweeter
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateSqlConnection();

    }
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private string _connectionString;
        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public  SqlConnection CreateSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
   
}
