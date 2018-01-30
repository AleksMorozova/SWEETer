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

       

        public async Task AddPost(PostsModel post)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IDauthor", post.Author.IDaccount);
                dynamicParameters.Add("@Text", post.Text);
                
                dynamicParameters.Add("@LikesNumber", post.LikesNumber);
                dynamicParameters.Add("@CommentNumber", post.CommentsNumber);
                await sqlConnection.ExecuteAsync(
                    "AddPost",
                    dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<PostsModel> GetPost(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<PostsModel>(
                    "GetPost",
                    dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<PostsModel>> GetPosts()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<PostsModel>(
                    "GetPosts",
                    null,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task UpdatePost(PostsModel post)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IDauthor", post.Author.IDaccount);
                dynamicParameters.Add("@Text", post.Text);
          
                dynamicParameters.Add("@LikesNumber", post.LikesNumber);
                dynamicParameters.Add("@CommentNumber", post.CommentsNumber);
                await sqlConnection.ExecuteAsync(
                    "UpdatePost",
                    dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
