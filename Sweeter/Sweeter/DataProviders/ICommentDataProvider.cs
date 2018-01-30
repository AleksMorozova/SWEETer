using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sweeter.DataProviders
{
    using Models;
    using Dapper;

  public  interface ICommentDataProvider
    {
        Task<IEnumerable<CommentModel>> GetComments();

        Task<CommentModel> GetComment(int id);

        Task AddComment(CommentModel comment);
        Task UpdateComment(CommentModel comment);
    }
}
