using Microsoft.AspNetCore.Mvc;
using MrBaan.Core.Repository.Interface;
using MrBaan.Models;
using System.Diagnostics;

namespace MrBaan.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogRepository.GetAllAsync();
            return View(blogs);
        }

        public async Task<ActionResult> DetailsBlog(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(id);
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
