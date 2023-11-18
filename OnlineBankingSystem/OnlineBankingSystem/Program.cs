using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineBankingSystem.Areas.Identity.Data;
using OnlineBankingSystem.Data;
using OnlineBankingSystem.Models;

namespace OnlineBankingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("OnlineBankingSystemContextConnection") ?? throw new InvalidOperationException("Connection string 'OnlineBankingSystemContextConnection' not found.");

                                    builder.Services.AddDbContext<OnlineBankingSystemContext>(options =>
                options.UseSqlServer(connectionString));

                    builder.Services.AddDbContext<MyDbContext>(options =>
                                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<OnlineBankingSystemUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<OnlineBankingSystemContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            builder.Services.AddMvc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Banking}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}