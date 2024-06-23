using Microsoft.AspNetCore.Mvc;
using MrBaan.Models;
using System.Diagnostics;

namespace MrBaan.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BlogController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBlog()
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
