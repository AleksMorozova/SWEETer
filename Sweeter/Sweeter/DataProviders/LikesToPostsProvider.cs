﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sweeter.Models;
using Dapper;
using System.Data.SqlClient;

namespace Sweeter.DataProviders
{
    public class LikesToPostsProvider : ILikesToPostsProvider
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        private SqlConnection sqlConnection;
        public void AddLike(LikesToPostsModel like)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"insert into LikesToPostTable(IDuser,IDpost)
      values (@IDauthor,@IDpost);",
     new {  IDauthor=like.Author.IDaccount, IDpost=like.Post.IDnews });
            }
        }

        public void DeleteLike(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"delete from LikesToPostTable where IDus_post = @id",new { id = id });
            }
        }

        public LikesToPostsModel GetLike(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var like = sqlConnection.Query<LikesToPostsModel>("select * from LikesToPostTable where IDus_post = @id", new { id = id }).First();
                return like;
            }
        }

        public IEnumerable<LikesToPostsModel> GetLikes()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var likes = sqlConnection.Query<LikesToPostsModel>("select * from LikesToPostTable").ToList();
                return likes;
            }
        }
        public IEnumerable<LikesToPostsModel> GetLikesOfPost(int idpost)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var likes = sqlConnection.Query<LikesToPostsModel>("select * from LikesToPostTable where IDpost=@idpost", new { idpost = idpost }).ToList();
                return likes;
            }
        }
        public IEnumerable<LikesToPostsModel> GetLikesOfAuthor(int idauthor)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var likes = sqlConnection.Query<LikesToPostsModel>("select * from LikesToPostTable where IDuser=@iduser",new { iduser = idauthor }).ToList();
                return likes;
            }
        }
    }
}
