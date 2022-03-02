using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.Extensions;
using TaskManager.Models;
using TaskManager.Models.DbContext;
using TaskManager.Services.RoleSeederService;
using TaskManager.Services.UserSeederService;

namespace TaskManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TaskManagerContext>(o =>
                    o.UseNpgsql(connection).EnableSensitiveDataLogging().EnableDetailedErrors())
                .AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TaskManagerContext>();
            services.ConfigureApplicationCookie(o => o.LoginPath = "/Account/Login");
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<RoleSeederService>();
            services.AddTransient<UserSeederService>();
            services.AddServices();
            services.AddRepositories();
            services.AddResolvers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}