using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.IdentityModel.Protocols;

namespace Sweeter
{
    public class ConnectionFactory
    {
        public static DbConnection GetOpenConnection()
        {
            var connection = new SqlConnection("MyConnectionString");
            connection.Open();

            return connection;
        }
    }
    /* public class ConnectionProvider
     {
         DbConnection conn;
         string connectionString;
         DbProviderFactory factory;

         // Constructor that retrieves the connectionString from the config file
         public ConnectionProvider()
         {
             this.connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString.ToString();
             factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[0].ProviderName.ToString());
         }

         // Constructor that accepts the connectionString and Database ProviderName i.e SQL or Oracle
         public ConnectionProvider(string connectionString, string connectionProviderName)
         {
             this.connectionString = connectionString;
             factory = DbProviderFactories.GetFactory(connectionProviderName);
         }

         // Only inherited classes can call this.
         public DbConnection GetOpenConnection()
         {
             conn = factory.CreateConnection();
             conn.ConnectionString = this.connectionString;
             conn.Open();

             return conn;
         }

     }
     /// <summary>
      ///     Factory for <see cref="IDbConnection" />
      /// </summary>
      public interface IConnectionFactory
      {
          /// <summary>
          ///     Create <see cref="IDbConnection" />
          /// </summary>
          IDbConnection Create();
      }

      public class ConnectionFactory : IConnectionFactory
      {
          private readonly string connectionString = ConfigurationManager.ConnectionStrings["DTAppCon"].ConnectionString;
          public IDbConnection GetConnection
          {
              get
              {
                  var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                  var conn = factory.CreateConnection();
                  conn.ConnectionString = ConnectionString;
                  conn.Open();
                  return conn;
              }
          }

          public string ConnectionString => connectionString;

          public IDbConnection Create()
          {
              throw new NotImplementedException();
          }
      }
      public class ConnectionProvider
      {
          DbConnection conn;
          string connectionString;
          DbProviderFactory factory;

          // Constructor that retrieves the connectionString from the config file
          public ConnectionProvider()
          {
              this.connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString.ToString();
              factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[0].ProviderName.ToString());
          }

          // Constructor that accepts the connectionString and Database ProviderName i.e SQL or Oracle
          public ConnectionProvider(string connectionString, string connectionProviderName)
          {
              this.connectionString = connectionString;
              factory = DbProviderFactories.GetFactory(connectionProviderName);
          }

          public object DbProviderFactories { get; }

          // Only inherited classes can call this.
          public DbConnection GetOpenConnection()
          {
              conn = factory.CreateConnection();
              conn.ConnectionString = this.connectionString;
              conn.Open();

              return conn;
          }

      }
     */
}
