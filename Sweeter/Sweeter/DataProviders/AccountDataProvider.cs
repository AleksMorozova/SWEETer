using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sweeter.Models;
using Dapper;
using System.Data.SqlClient;


namespace Sweeter.DataProviders
{
    public class AccountDataProvider : IAccountDataProvider
    {
        private readonly string connectionString = "Server=localhost;Database=JayBase;Trusted_Connection=True;";

        private SqlConnection sqlConnection;

        public async Task AddAccount(AccountModel account)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Fullname", account.FullName);
                dynamicParameters.Add("@Email", account.Email);
                dynamicParameters.Add("@Password", account.Password);
                dynamicParameters.Add("@Username", account.Login);
                dynamicParameters.Add("@Avatar", account.Avatar);
                await sqlConnection.ExecuteAsync(
                    "AddAccount",
                    dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }

        }

        public Task DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountModel> GetAccount(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<AccountModel>(
                    "GetAccount",
                    dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Task<IEnumerable<AccountModel>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccount(AccountModel account)
        {
            throw new NotImplementedException();
        }
    }
}
