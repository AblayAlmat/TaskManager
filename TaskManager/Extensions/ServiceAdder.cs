using Microsoft.Extensions.DependencyInjection;
using TaskManager.Services.AccountService;
using TaskManager.Services.TaskService;

namespace TaskManager.Extensions
{
    public static class ServiceAdder
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}