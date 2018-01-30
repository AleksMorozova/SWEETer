using System;
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
        private readonly string connectionString = @"Server=DESKTOP-DGUPQAR;Database=JayBase;Trusted_Connection=True;";

        private SqlConnection sqlConnection;
        public void AddLike(LikesToPostsModel like)
        {
            sqlConnection.Execute(@"insert into LikesToPostsTable(IDpost,IDauthor)
      values (@IDpost,@IDauthor);",
     new { like.Post.IDnews, like.Author.IDaccount });
        }

        public void DeleteLike(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"delete from LikesToPostsTable where id = @id", id);
            }
        }

        public LikesToPostsModel GetLike(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var like = sqlConnection.Query<LikesToPostsModel>("select * from LikesToPostsTable where Id = @id", id).First();
                return like;
            }
        }

        public IEnumerable<LikesToPostsModel> GetLikes()
        {
            var likes = sqlConnection.Query<LikesToPostsModel>("select * from LikesToPostsTable").ToList();
            return likes;
        }
    }
}
