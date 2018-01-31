using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sweeter.DataProviders
{
    using Models;
    using Dapper;
    public class CommentDataProvider
    {
        private readonly string connectionString = @"Server=DESKTOP-DGUPQAR\VnHP;Database=JayBase;Trusted_Connection=True;";

        private SqlConnection sqlConnection;



        public void AddComment(CommentModel comment)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"insert into CommentTable(IDpost, IDuser,Text, LikeNumber)
      values (@IDpost, @IDauthor,@Text, @LikesNumber);",
 new { comment.Post.IDnews, comment.Author.IDaccount, comment.Text, comment.LikesNumber });
            }
        }

        public CommentModel GetComment(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var comment = sqlConnection.Query<CommentModel>("select * from CommentTable where IDcomment = @id", id).First();
                return comment;
            }
        }

        public IEnumerable<CommentModel> GetComments()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var comments = sqlConnection.Query<CommentModel>("select * from CommentTable").ToList();
                return comments;
            }
        }

        public void UpdateComment(CommentModel comment)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"update CommentTable set IDpost=@IDpost, IDuser=@IDauthor,Text=@Text, LikeNumber=@LikesNumber where IDcomment = @id;",
                  new { comment.Post.IDnews,comment.Author.IDaccount,comment.Text,comment.LikesNumber, comment.IDcomment });
            }
        }

        public void DeleteComment(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"delete from CommentTable where IDcomment = @id", id);
            }
        }
    }
}
