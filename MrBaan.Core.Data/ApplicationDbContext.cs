using Microsoft.EntityFrameworkCore;
using MrBaan.Models;

namespace MrBaan.Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BlogModel> BlogModels { get; set; }
        public DbSet<ProjectModel> ProjectModels { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
