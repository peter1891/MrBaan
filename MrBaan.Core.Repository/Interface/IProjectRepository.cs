using MrBaan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrBaan.Core.Repository.Interface
{
    public interface IProjectRepository : IRepository<ProjectModel>
    {
        Task<IEnumerable<ProjectModel>> GetProjectsByPage(int pageIndex, int pageSize = 6);
    }
}
