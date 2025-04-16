
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using WebAppTollCollection.Data;
using WebAppTollCollection.Models;

namespace WebAppTollCollection.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var services = builder.Services;

            services.AddControllersWithViews(op =>
            {
                op.Filters.Add(new AuthorizeFilter());
            });

            services.AddDbContext<Appdatabase>(opt =>
            {
                opt.UseSqlServer("server=.; database= TollDatabaseCore; trusted_connection=true; encrypt = false;");
            });

            services.AddIdentity<AppUser, UserRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;

                opt.User.RequireUniqueEmail = true;

                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 2;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<Appdatabase>();



            builder.Services.ConfigureApplicationCookie(op =>
            {
                op.LoginPath = "/Security/Login";
                op.LogoutPath = "/Security/Logout";
                op.Cookie.Name = "SecretKey";

            });


            var app = builder.Build();

            app.UseHttpsRedirection();


            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute("route", "{controller=TollPlazas}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
