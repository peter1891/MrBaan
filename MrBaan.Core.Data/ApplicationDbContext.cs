using Microsoft.EntityFrameworkCore;
using MrBaan.Model;
using MrBaan.Models;

namespace MrBaan.Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BlogModel> BlogModels { get; set; }
        public DbSet<ProjectModel> ProjectModels { get; set; }
        public DbSet<ProjectImageModel> ProjectImageModels { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogModel>(entity =>
            {
                entity.HasKey(b => b.Id);
            });

            modelBuilder.Entity<ProjectModel>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasMany(p => p.ProjectImages)
                .WithOne(i => i.ProjectModel)
                .HasForeignKey(i => i.ProjectModelId);
            });

            modelBuilder.Entity<ProjectImageModel>(entity =>
            {
                entity.HasKey(i => i.Id);
            });
        }
    }
}
