using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Sweeter.DataProviders
{
    using Models;
 
   public interface IPostDataProvider
    {
        Task<IEnumerable<PostsModel>> GetPosts();

        Task<PostsModel> GetPost(int id);

        Task AddPost(PostsModel post);
        Task UpdatePost(PostsModel post);


    }
}
