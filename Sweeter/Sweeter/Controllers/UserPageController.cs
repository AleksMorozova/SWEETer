﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sweeter.Services.DataProviders;
using Sweeter.Models;
using Sweeter.DataProviders;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sweeter.Controllers
{
    [Route("/UserPage")]
    public class UserPageController : Controller
    {
        private IPostDataProvider postDataProvider;
        private IAccountDataProvider accountDataProvider;
        private ICommentDataProvider commentDataProvider;
        private IUnsubscribesDataProvider unsubscribesDataProvider;
        public UserPageController(IPostDataProvider postData, IAccountDataProvider accountData, ICommentDataProvider commentData, IUnsubscribesDataProvider unsubscribesData)
        {
            this.postDataProvider = postData;
            this.accountDataProvider = accountData;
            this.commentDataProvider = commentData;
            this.unsubscribesDataProvider = unsubscribesData;
        }
        [HttpGet]
        public IActionResult Index(int? id)
        {

            int idUs;
            if (HttpContext.User.Claims.Count() != 0)
            {
                idUs = int.Parse(HttpContext.User.FindFirst(x => x.Type == "Current").Value);
            }
            else
                idUs = 0;
            if (idUs != 0)
            {
                if (unsubscribesDataProvider.GetUnsubscribes(idUs, id).Count() == 0) ViewData["Act"] = "Unsubscribe";
                else ViewData["Act"] = "Subscribe";
                IEnumerable<PostsModel> feeds = postDataProvider.GetPostsOfAuthor(id);
                IEnumerable<PostsModel> feedsnew = feeds.Reverse();
                ViewData["ID"] = id;
                AccountModel account = accountDataProvider.GetAccount(id);
                AccountModel accountmy = accountDataProvider.GetAccount(idUs);
                ViewData["Style"] = accountmy.Style;
                ViewData["Username"] = account.Username;
                ViewData["Email"] = account.Email;
                if (account.Avatar != null)
                    ViewData["Pic"] = "data:image/jpeg;base64," + Convert.ToBase64String(account.Avatar);
                else
                    ViewData["Pic"] = "data:image/jpeg;base64," + Convert.ToBase64String(accountmy.Avatar);
                foreach (PostsModel p in feedsnew)
                {
                    p.Author = accountDataProvider.GetAccount(p.IDuser);
                    p.CommentNumber = commentDataProvider.GetCommentsOfPost(p.IDpost).Count();
                }
                return View(feedsnew);
            }
            else return Redirect("/");
        }
    }
}
