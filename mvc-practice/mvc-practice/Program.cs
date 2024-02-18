using mvc_practice.Context;
using mvc_practice.Interface;
using mvc_practice.Models;

namespace mvc_practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<Config>();
            builder.Services.AddScoped<IEmployeeInterface, EmployeeDetails>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Get}/{id?}");

            app.Run();
        }
    }
}