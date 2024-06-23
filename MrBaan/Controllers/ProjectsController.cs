using Microsoft.AspNetCore.Mvc;
using MrBaan.Database;
using MrBaan.Models;
using System.Diagnostics;

namespace MrBaan.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProjectsController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projects = _context.ProjectModels.ToList();
            return View(projects);
        }

        public IActionResult DetailsProject(int id)
        {
            var project = _context.ProjectModels.FirstOrDefault(item => item.Id == id);
            if (project == null)
                return NotFound();

            return View(project);
        }

        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectModel model)
        {
            _context.ProjectModels.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
