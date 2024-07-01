using MrBaan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrBaan.Model
{
    public class ProjectImageModel : ImageModel
    {
        public int ProjectModelId { get; set; }
        public ProjectModel ProjectModel { get; set; }
    }
}
