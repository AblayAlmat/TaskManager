using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TaskManager.MappingConfigurations.Resolvers;

namespace TaskManager.Extensions
{
    public static class ResolverAdder
    {
        public static void AddResolvers(this IServiceCollection services)
        {
            services.AddScoped<GetUserResolver>();
        }
    }
}