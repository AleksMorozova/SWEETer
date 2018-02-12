﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sweeter.DataProviders;
using Sweeter.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sweeter.Controllers
{
    [Route("/Posts")]
    public class PostsController : Controller
    {
        private IPostDataProvider postDataProvider;
        private IAccountDataProvider accountDataProvider;
        private ICommentDataProvider commentDataProvider;
        private ILogger<PostsController> _logger;

        public PostsController(IPostDataProvider postData, IAccountDataProvider accountData, ICommentDataProvider commentData, ILogger<PostsController> logger)
        {
            this.postDataProvider = postData;
            this.accountDataProvider = accountData;
            this.commentDataProvider = commentData;
            _logger = logger;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
       

        
        [HttpGet]
        public IActionResult Index()
        {

            int id = int.Parse(HttpContext.User.FindFirst(x => x.Type == "Current").Value);
            if (id != 0)
            {


                //int id = Convert.ToInt32(Request.Cookies["0"]);
                IEnumerable<PostsModel> feeds = postDataProvider.GetPosts();
                IEnumerable<PostsModel> feedsnew=feeds.Reverse();
                AccountModel account = accountDataProvider.GetAccount(id);
                ViewData["Username"] = account.Username;
                foreach (PostsModel p in feedsnew)
                {
                    p.Author = accountDataProvider.GetAccount(p.IDuser);
                    p.CommentNumber = commentDataProvider.GetCommentsOfPost(p.IDpost).Count();
                }
                _logger.LogInformation($"All is good, user {account.IDuser} look at new posts");
                return View(feedsnew);
            }
            else return RedirectPermanent("/Username");
        }


        [HttpPost("addfeed")]
        public IActionResult NewPost(string mypost)
        {
            int id = int.Parse(HttpContext.User.FindFirst(x => x.Type == "Current").Value);
            AccountModel Author = accountDataProvider.GetAccount(id);
            PostsModel Mypost = new PostsModel
            {
                Author = Author,
                LikeNumder=0,
                CommentNumber=0,
                IDuser=id,
                Text=mypost
            };
            postDataProvider.AddPost(Mypost);
            _logger.LogInformation($"Post {Mypost.IDpost} created by user {Author.IDuser}");
            return RedirectPermanent("/Posts");
        }


            // GET api/values
            /*[HttpGet]
             * 
            private IPostDataProvider postDataProvider;
            public PostsController(IPostDataProvider postData)
            {
                this.postDataProvider = postData;
            }
            public async Task<IEnumerable<PostsModel>> Get()
            {
                return await this.postDataProvider.GetPosts();
            }

            // GET api/values/5
            [HttpGet("{id}")]
            public async Task<PostsModel> Get(int id)
            {
                return await this.postDataProvider.GetPost(id); ;
            }

            // POST api/values
            [HttpPost]
            public async void Post([FromBody]PostsModel postsModel)
            {
                await this.postDataProvider.AddPost(postsModel);

            }
            [HttpPut("{id}")]
            public async Task Put(int id, [FromBody]PostsModel post)
            {
                await this.postDataProvider.UpdatePost(post);
            }*/

    }
}
                //byte[] ImageData = account.Avatar;
                //string path = "wwwroot/ForPics/av" + id.ToString() + ".jpeg";
                //using (FileStream fs = new FileStream(path, FileMode.Create))
                //{
                //    fs.Write(ImageData, 0, ImageData.Length);
                //}
                //ViewData["Pic"] = path.Substring(7);
