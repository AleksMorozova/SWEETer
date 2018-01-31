using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Sweeter.DataProviders
{
    using Models;
    public class PostDataProvider:IPostDataProvider
    {
        private readonly string connectionString = @"Server=DESKTOP-DGUPQAR\VnHP;Database=JayBase;Trusted_Connection=True;";

        private SqlConnection sqlConnection;

       

        public void AddPost(PostsModel post)
        {
            post.PublicDate = DateTime.Now;
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"insert into PostTable(IDuser,Text,PublicDate, LikeNumber, CommentNumber)
      values (@IDauthor,@Text,@PublicDate, @LikesNumber, @CommentNumber);",
   new { post.Author.IDaccount, post.Text, post.PublicDate, post.LikesNumber, post.CommentsNumber });
             
            }
        }
        public void DeletePost(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Execute(@"delete from PostTable where IDpost = @id", id);
            }
        }

        public PostsModel GetPost(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var post = sqlConnection.Query<PostsModel>("select * from PostTable where IDpost = @id", id).First();
                return post;
            }
        }

        public IEnumerable<PostsModel> GetPosts()
        {
            using (var sqlConnection = MvcApplication.GetOpenConnection())
            {
              
              var  posts = sqlConnection.Query<PostsModel>("select * from PostTable").ToList();
                return  posts ;
            }
        }

        public void UpdatePost(PostsModel post)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                
                sqlConnection.Execute(@"update PostTable set IDuser=@IDauthor,Text=@Text,PublicDate=@PublicDate, LikeNumber=@LikesNumber, CommentNumber=@CommentNumber where IDpost = @id;",
                  new { post.Author.IDaccount, post.Text, post.PublicDate,post.LikesNumber, post.CommentsNumber, post.IDnews });
            }
        }
    }
}
