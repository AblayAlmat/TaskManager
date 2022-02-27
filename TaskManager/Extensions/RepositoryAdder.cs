using Microsoft.Extensions.DependencyInjection;
using TaskManager.Repositories.TaskRepository;
using TaskManager.Services.TaskService;

namespace TaskManager.Extensions
{
    public static class RepositoryAdder
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();
        }
    }
}