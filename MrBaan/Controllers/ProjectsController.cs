using Microsoft.AspNetCore.Mvc;
using MrBaan.Models;
using System.Diagnostics;

namespace MrBaan.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ProjectsController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProject()
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
