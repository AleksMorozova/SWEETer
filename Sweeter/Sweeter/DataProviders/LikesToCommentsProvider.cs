using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sweeter.Models;
using Dapper;
using System.Data.SqlClient;


namespace Sweeter.DataProviders
{
    public class LikesToCommentsProvider : ILikesToCommentsProvider
    {
        private readonly string connectionString = @"Server=DESKTOP-DGUPQAR;Database=JayBase;Trusted_Connection=True;";

        private SqlConnection sqlConnection;
        public void AddLike(LikesToCommentsModel like)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"insert into LikesToCommentsTable(IDcomment,IDauthor)
      values (@IDcomment,@IDauthor);",
    new {like.Comment.IDcomment, like.Author.IDaccount });

            }
        }

        public void DeleteLike(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"delete from LikesToCommentsTable where id = @id", id);
            }
        }

        public LikesToCommentsModel GetLike(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var like = sqlConnection.Query<LikesToCommentsModel>("select * from LikesToCommentsTable where Id = @id", id).First();
                return like;
            }
        }

        public IEnumerable<LikesToCommentsModel> GetLikes()
        {
            var likes = sqlConnection.Query<LikesToCommentsModel>("select * from LikesToCommentsTable").ToList();
            return likes;
        }
    }
}
