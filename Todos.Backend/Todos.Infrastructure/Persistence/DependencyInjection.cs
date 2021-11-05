using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Todos.Application.Interfaces;

namespace Todos.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<TodosDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ITodosDbContext>(provider =>
                provider.GetService<TodosDbContext>());
            return services;
        }
    }
}
