using Microsoft.AspNetCore.Mvc;
using MrBaan.Database;
using MrBaan.Models;
using System.Diagnostics;

namespace MrBaan.Controllers
{
    public class BlogController : Controller
    {
        private readonly DatabaseContext _context;

        public BlogController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var blogs = _context.BlogModels.ToList();
            return View(blogs);
        }

        public IActionResult DetailsBlog(int id)
        {
            var blog = _context.BlogModels.FirstOrDefault(item => item.Id == id);
            if (blog == null)
                return NotFound();

            return View(blog);
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
