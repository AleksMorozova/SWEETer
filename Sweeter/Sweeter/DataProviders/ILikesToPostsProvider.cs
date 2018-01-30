using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sweeter.DataProviders
{
    using Models;
    interface ILikesToPostsProvider
    {
        IEnumerable<LikesToPostsModel> GetLikes();

        LikesToPostsModel GetLike(int id);

        void AddLike(LikesToPostsModel like);



        void DeleteLike(int id);
    }
}
