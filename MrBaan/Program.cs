using Microsoft.EntityFrameworkCore;
using MrBaan.Core.Data;
using MrBaan.Core.Repository.Interface;
using MrBaan.Core.Repository.Repository;

namespace MrBaan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            database => database.MigrationsAssembly("MrBaan.Core.Data")));

            builder.Services.AddScoped<IBlogRepository, BlogRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                    name: "blog",
                    pattern: "Blog/{action=Index}/{id?}",
                    defaults: new { controller = "Blog", action = "Index" });

            app.MapControllerRoute(
                    name: "projects",
                    pattern: "Projects/{action=Index}/{id?}",
                    defaults: new { controller = "Projects", action = "Index" });

            app.Run();
        }
    }
}
