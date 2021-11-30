using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Todos.Application.Common.Mapping;
using FluentValidation;
using Todos.Application.Common.Behaviors;

namespace Todos.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddValidatorsFromAssemblies(new[]{ Assembly.GetExecutingAssembly()});    
            return services;
        }
    }
}
