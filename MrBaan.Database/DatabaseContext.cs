using Microsoft.EntityFrameworkCore;
using MrBaan.Models;

namespace MrBaan.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) 
        {
            
        }

        public DbSet<BlogModel> BlogModels { get; set; }
        public DbSet<ProjectModel> ProjectModels { get; set; }
    }
}
