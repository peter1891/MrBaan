using MrBaan.Core.Data;
using MrBaan.Core.Repository.Interface;
using MrBaan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrBaan.Core.Repository.Repository
{
    public class ProjectRepository : Repository<ProjectModel>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
