using MrBaan.Core.Data;
using MrBaan.Core.Repository.Interface;
using MrBaan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrBaan.Core.Repository.Repository
{
    public class ProjectImageRepository : Repository<ProjectImageModel>, IProjectImageRepository
    {
        public ProjectImageRepository(ApplicationDbContext context)
            : base(context) 
        {
            
        }
    }
}
