using Microsoft.AspNetCore.Mvc;
using Resty.Web.Models;
using System.Diagnostics;
using Resty.Data.Interfaces.Repositories.User;

namespace Resty.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestRepository _testRepository;

        public HomeController(ILogger<HomeController> logger, ITestRepository testRepository)
        {
            _logger = logger;
            _testRepository = testRepository;
        }

        public async Task<IActionResult> Index()
        {
            var a = await _testRepository.Test1();
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