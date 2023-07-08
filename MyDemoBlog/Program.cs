using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyDemoBlog.Areas.Admin;
using MyDemoBlog.Domain;
using MyDemoBlog.Domain.Repos.Abstract;
using MyDemoBlog.Domain.Repos.EF;

namespace MyDemoBlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.GetSection("Project").Bind(new Config());
            builder.Services
                .AddTransient<IArticleRepository, ArticleRepository>()
                .AddTransient<DataManager>()
                .AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString))
                .AddIdentity<IdentityUser, IdentityRole>(opts =>
                {
                    opts.User.RequireUniqueEmail = true;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                    opts.Password.RequireNonAlphanumeric = false;
                }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Services
                .ConfigureApplicationCookie(opts =>
                {
                    opts.Cookie.Name = "BlogAuth";
                    opts.Cookie.HttpOnly = true;
                    opts.LoginPath = "/account/login";
                    opts.AccessDeniedPath = "/account/accessdenied";
                    opts.SlidingExpiration = true;
                })
                .AddAuthorization(x=> 
                {
                    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
                })
                .AddControllersWithViews(x => 
                {
                    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
                });

            

            var app = builder.Build();

            if (app.Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); }


           
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapDefaultControllerRoute();
            app.Run();
        }
    }
}