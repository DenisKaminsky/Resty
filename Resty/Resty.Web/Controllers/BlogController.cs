using Microsoft.AspNetCore.Mvc;

namespace Resty.Web.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
