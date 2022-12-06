using Microsoft.AspNetCore.Mvc;
using Resty.Business.Interfaces.Functionality.Blog;

namespace Resty.Web.ViewComponents.Blog
{
    public class BlogPreview : ViewComponent
    {
        private readonly IBlogQueries _blogQueries;

        public BlogPreview(IBlogQueries blogQueries)
        {
            _blogQueries = blogQueries;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var preview = await _blogQueries.GetPreviewByIdAsync(id);

            return View(preview);
        }
    }
}
