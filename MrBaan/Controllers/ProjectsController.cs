using Microsoft.AspNetCore.Mvc;
using MrBaan.Core.Repository.Interface;
using MrBaan.Models;
using System.Diagnostics;

namespace MrBaan.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            var allProjects = await _projectRepository.GetAllAsync();

            int pageSize = 1;
            var projects = await _projectRepository.GetProjectsByPage(pageIndex, pageSize);

            ViewBag.HasPreviousPage = pageIndex > 1;
            ViewBag.HasNextPage = pageIndex < (allProjects.Count() / pageSize);
            ViewBag.CurrentPage = pageIndex;

            return View(projects);
        }

        public async Task<IActionResult> DetailsProject(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
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
            _projectRepository.AddAsync(model);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
