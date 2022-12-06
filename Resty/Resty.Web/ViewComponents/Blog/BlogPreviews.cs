using Microsoft.AspNetCore.Mvc;
using Resty.Business.Interfaces.Functionality.Blog;

namespace Resty.Web.ViewComponents.Blog
{
    public class BlogPreviews : ViewComponent
    {
        private readonly IBlogQueries _blogQueries;

        public BlogPreviews(IBlogQueries blogQueries)
        {
            _blogQueries = blogQueries;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var previews = await _blogQueries.GetAllPreviewsAsync();

            return View(previews.ToArray());
        }
    }
}
