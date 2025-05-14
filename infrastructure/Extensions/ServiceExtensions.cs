
using Application.Interfaces;
using infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Application.Services;

namespace infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<TaskService>();

            return services;
        }
    }
}