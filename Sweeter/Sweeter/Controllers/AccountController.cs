using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sweeter.Models;
using Dapper;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sweeter.Controllers
{
    using Models;
    using DataProviders;
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        private IAccountDataProvider accountDataProvider;
        public AccountController(IAccountDataProvider accountData)
        {
            this.accountDataProvider = accountData;
        }

        [HttpGet("{id}")]
        public async Task Get(int id)
        
           => await this.accountDataProvider.GetAccount(id);

        [HttpPost]
        public async Task Post([FromBody]AccountModel account)
        {
            await this.accountDataProvider.AddAccount(account);
        }


    }
}
