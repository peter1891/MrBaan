using Microsoft.EntityFrameworkCore;
using MrBaan.Core.Data;
using MrBaan.Core.Repository.Interface;
using MrBaan.Models;

namespace MrBaan.Core.Repository.Repository
{
    public class ProjectRepository : Repository<ProjectModel>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<ProjectModel>> GetProjectsByPage(int pageIndex, int pageSize = 6)
        {
            return await ApplicationDbContext.ProjectModels
                .OrderByDescending(item => item.Created)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}
