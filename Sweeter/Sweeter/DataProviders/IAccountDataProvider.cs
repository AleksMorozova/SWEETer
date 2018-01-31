using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sweeter.DataProviders
{
    using Models;
   public interface IAccountDataProvider
    {
        
        IEnumerable<AccountModel> GetAccounts();

        AccountModel GetAccount(int id);

        void AddAccount(AccountModel account);

        void UpdateAccount(AccountModel account);

        void DeleteAccount(int id);
    }
}
