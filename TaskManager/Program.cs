using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.Models.DbContext;
using TaskManager.Services.RoleSeederService;
using TaskManager.Services.UserSeederService;

namespace TaskManager
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<TaskManagerContext>();
                await context.Database.MigrateAsync();
                RoleSeederService roleSeeder = new RoleSeederService(context);
                await roleSeeder.SeedRoles();
                UserSeederService userSeeder = new UserSeederService(context);
                await userSeeder.SeedUsers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}