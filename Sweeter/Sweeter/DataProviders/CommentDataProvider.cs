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



        public async Task AddComment(CommentModel comment)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IDpost", comment.Post.IDnews);
                dynamicParameters.Add("@IDauthor", comment.Author.IDaccount);

                dynamicParameters.Add("@Text", comment.Text);
                dynamicParameters.Add("@LikesNumber", comment.LikesNumber);
                await sqlConnection.ExecuteAsync(
                    "AddComment",
                    dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<CommentModel> GetComment(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<CommentModel>(
                    "GetComment",
                    dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CommentModel>> GetComments()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<CommentModel>(
                    "GetComents",
                    null,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task UpdateComment(CommentModel comment)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IDpost", comment.Post.IDnews);
                dynamicParameters.Add("@IDauthor", comment.Author.IDaccount);

                dynamicParameters.Add("@Text", comment.Text);
                dynamicParameters.Add("@LikesNumber", comment.LikesNumber);
                await sqlConnection.ExecuteAsync(
                    "UpdateComment",
                    dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
