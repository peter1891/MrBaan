using MrBaan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrBaan.Model
{
    public abstract class ImageModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public DateTime UploadedOn { get; set; } = DateTime.Now;
    }
}
