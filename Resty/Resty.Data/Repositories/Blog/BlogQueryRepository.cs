using Mapster;
using Microsoft.EntityFrameworkCore;
using Resty.Data.DTO.Blog;
using Resty.Data.DTO.User;
using Resty.Data.Interfaces.DTO.Blog;
using Resty.Data.Interfaces.DTO.User;
using Resty.Data.Interfaces.Repositories.User;

namespace Resty.Data.Repositories.Blog
{
    public class BlogQueryRepository : BaseRepository
    {
        public BlogQueryRepository(RestyDbContext context) : base(context) { }

        public Task<IDataBlog[]> GetAllAsync()
        {
            return DbContext.Blogs
                .Select(x => ToDataBlog(x))
                .ToArrayAsync<IDataBlog>();
        }

        public Task<IDataBlog> GetByIdAsync(int id)
        {
            return DbContext.Blogs
                .Select(x => ToDataBlog(x))
                .FirstOrDefaultAsync<IDataBlog>(x => x.Id == id);
        }







        public Task<bool> ValidateUsernameExistsAsync(string username)
        {
            return DbContext.Users
                .AnyAsync(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public Task<bool> ValidateEmailExistsAsync(string email)
        {
            return DbContext.Users
                .AnyAsync(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        private static IDataBlog ToDataBlog(Models.Blog.Blog blog)
        {
            return new DataBlog()
            {
                Id = blog.Id,
                Title = blog.Title,
                CreatedDateUtc = blog.CreatedDateUtc,
                Author = new DataAuthor
                {
                    Id = blog.Author.Id,
                    Username = blog.Author.Username,
                    Rating = blog.Author.Rating
                }
            };
        }
    }
}
