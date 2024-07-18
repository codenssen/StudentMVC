using Microsoft.EntityFrameworkCore;
using StudentMVC.Data;
using StudentMVC.Interface;
using StudentMVC.Repository;

namespace StudentMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //builder.Services.AddScoped<IStudentRepository,StudentLocalRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();

            var app = builder.Build();

            app.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}"
             );

            app.UseRouting();

            app.Run();
        }
    }
}
