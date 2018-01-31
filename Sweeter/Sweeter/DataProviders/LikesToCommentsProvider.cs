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
                sqlConnection.Execute(@"insert into LikesToCommentTable(IDuser,IDcomment)
      values (@IDauthor, @IDcomment);",
    new { like.Author.IDaccount, like.Comment.IDcomment });

            }
        }

        public void DeleteLike(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"delete from LikesToCommentTable where IDus_com = @id", id);
            }
        }

        public LikesToCommentsModel GetLike(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var like = sqlConnection.Query<LikesToCommentsModel>("select * from LikesToCommentTable where IDus_com = @id", id).First();
                return like;
            }
        }

        public IEnumerable<LikesToCommentsModel> GetLikes()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var likes = sqlConnection.Query<LikesToCommentsModel>("select * from LikesToCommentTable").ToList();
                return likes;
            }
        }
    }
}
