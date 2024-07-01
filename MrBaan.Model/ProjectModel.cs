using MrBaan.Model;

namespace MrBaan.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string GitUrl { get; set; }

        public DateTime CreatedOn {  get; set; } = DateTime.Now;

        public ICollection<ProjectImageModel> ProjectImages { get; set; } = new List<ProjectImageModel>();
    }
}
