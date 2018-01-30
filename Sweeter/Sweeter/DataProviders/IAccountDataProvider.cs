using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sweeter.DataProviders
{
    using Models;
   public interface IAccountDataProvider
    {
        
        Task<IEnumerable<AccountModel>> GetAccounts();

        Task<AccountModel> GetAccount(int id);

        Task AddAccount(AccountModel account);

        Task UpdateAccount(AccountModel account);

        Task DeleteAccount(int id);
    }
}
