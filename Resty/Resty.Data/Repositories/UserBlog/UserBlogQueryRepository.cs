using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resty.Data.Repositories.UserBlog
{
    public class UserBlogQueryRepository : BaseRepository
    {
        public UserBlogQueryRepository(RestyDbContext dbContext) : base(dbContext)
        {
        }


    }
}
