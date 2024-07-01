using Microsoft.AspNetCore.Mvc;
using MrBaan.Core.Repository.Interface;
using MrBaan.Model;
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

            int pageSize = 4;
            var projects = await _projectRepository.GetProjectsByPage(pageIndex, pageSize);

            ViewBag.HasPreviousPage = pageIndex > 1;
            ViewBag.HasNextPage = pageIndex < (int)Math.Ceiling((Double)allProjects.Count() /pageSize);
            ViewBag.CurrentPage = pageIndex;
            ViewBag.TotalPages = (int)Math.Ceiling((Double)allProjects.Count() / pageSize);

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
        public async Task<IActionResult> CreateProject(ProjectModel model, List<IFormFile> formFiles)
        {
            if (formFiles != null && formFiles.Any())
            {
                foreach (var formFile in formFiles)
                {
                    if (formFile.Length > 0)
                    {
                        var images = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                        if (!Directory.Exists(images))
                            Directory.CreateDirectory(images);

                        var filePath = Path.Combine(images, formFile.FileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                            await formFile.CopyToAsync(stream);

                        ProjectImageModel projectImageModel = new ProjectImageModel()
                        {
                            FileName = formFile.FileName,
                            FilePath = $"/img/{formFile.FileName}",
                            ProjectModel = model
                        };

                        model.ProjectImages.Add(projectImageModel);
                    }
                }
            }

            await _projectRepository.AddAsync(model);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
