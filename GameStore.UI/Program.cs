using GameStore.DAL.Data;
using GameStore.DAL.Models;
using GameStore.UI.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace GameStore.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<GameDbContext>(opts =>
            {

                opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr"));
            });

            builder.Services.AddIdentityExt();

            builder.Services.ConfigureApplicationCookie(cf =>
            {

                CookieBuilder cookieBuilder = new CookieBuilder()
                {
                    Name = "GameStoreApp",
                    Path = "/",
            
                    
                };
                cf.Cookie = cookieBuilder;
                cf.ExpireTimeSpan= TimeSpan.FromDays(1);
               

            });

          
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
              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
