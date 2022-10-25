using Microsoft.AspNetCore.Mvc;
using Resty.Web.Models;
using System.Diagnostics;
using Resty.Data.Interfaces.Repositories.User;

namespace Resty.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserQueryRepository _userQueryRepository;

        public HomeController(ILogger<HomeController> logger, IUserQueryRepository userQueryRepository)
        {
            _logger = logger;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var a = await _userQueryRepository.GetAllAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}