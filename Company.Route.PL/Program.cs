using Company.Route.BLL.Repositories;
using Company.Route.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Company.Route.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();//allow any controller to make an object of it

            // builder.Services.AddScoped<AppDbContext>();//allow dependancy injection for AppDbContext
            //this means clr can use object from AppDbContext

            // Another way fpr Dependancy Injection 
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));//I put the connection in appsetting.json, for the server name is not stable 
            });

           builder.Services.AddScoped<DepartmentRepository>();//Allow Dependancy Injection for Department Repository
            builder.Services.AddScoped<EmployeeRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();///Middle Wares
            app.UseStaticFiles();      //Middle Wares
                                       //Middle Wares
            app.UseRouting();          //Middle Wares
                                       //Middle Wares
            app.UseAuthorization();    //Middle Wares
                                       //Middle Wares
            app.MapControllerRoute(    //Middle Wares
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
