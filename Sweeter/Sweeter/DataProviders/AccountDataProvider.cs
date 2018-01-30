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
        private readonly string connectionString = @"Server=DESKTOP-DGUPQAR;Database=JayBase;Trusted_Connection=True;";

        private SqlConnection sqlConnection;

        public void AddAccount(AccountModel account)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"insert into AccountTable(Fullname, Email, Password, Username, Avatar)
      values (@Fullname, @Email, @Password, @Username, @Avatar);",
    new { account.FullName, account.Email, account.Password, account.Login, account.Avatar });
           
            }

        }

        public void DeleteAccount(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"delete from AccountTable where id = @id", id);
            }
        }

        public AccountModel GetAccount(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var account = sqlConnection.Query<AccountModel>("select * from AccountTable where Id = @id", id).First();
                return account;
            }
        }

        public IEnumerable<AccountModel> GetAccounts()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var accounts = sqlConnection.Query<AccountModel>("select * from AccountTable").ToList();
                return accounts;
            }
        }

        public void UpdateAccount(AccountModel account)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {

                sqlConnection.Execute(@"update AccountTable set Fullname=@Fullname, Email=@Email, Password=@Password, Username=@Username, Avatar=@Avatar where ID = @id;",
              new { account.FullName, account.Email, account.Password, account.Login, account.Avatar, account.IDaccount });
            }
        }
    }
}
