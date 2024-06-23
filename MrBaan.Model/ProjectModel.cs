namespace MrBaan.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string GitUrl { get; set; }

        public DateTime Created {  get; set; } = DateTime.Now;
    }
}
