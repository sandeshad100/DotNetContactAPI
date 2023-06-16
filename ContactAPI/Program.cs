using Microsoft.EntityFrameworkCore;
using ContactAPI.Models;
namespace ContactAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ContactDbApiContext>(option =>
            option.UseSqlServer(builder.Configuration["MyCon"])

            );
            builder.Services.AddControllers();//for api projects
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.UseRouting();
            //app.MapControllers();//for api project
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map API controllers
                endpoints.MapDefaultControllerRoute(); // Map MVC controllers
            });

            app.Run();
        }
    }
}