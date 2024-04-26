using FluentValidation;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDo.Application.MappingProfiles;
using ToDo.Domain.Repositorios;
using ToDo.Infra.DataContext;
using ToDo.Infra.Repositories;

namespace ToDo.Application
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateToDoCommandHandler).GetTypeInfo().Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateToDoCommandHandler).GetTypeInfo().Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveToDoCommandHandler).GetTypeInfo().Assembly);
                cfg.NotificationPublisher = new ForeachAwaitPublisher();
            });

            services.AddAutoMapper(typeof(ToDoMappingProfile));
            //services.AddScoped<IToDoRepositorio, ToDoRepository>();
            services.AddScoped<IToDoRepositorio, ToDoRepositoryDapper>(provider =>
            {
                var connectionString = configuration.GetConnectionString("connectionString");
                return new ToDoRepositoryDapper(connectionString);
            });
            services.AddValidatorsFromAssemblies(
                    new List<Assembly>
                    {
                    typeof(CreateToDoCommandValidator).GetTypeInfo().Assembly,
                    typeof(UpdateToDoCommandValidator).GetTypeInfo().Assembly,
                    typeof(RemoveToDoCommandValidator).GetTypeInfo().Assembly,
                    }.AsEnumerable());

            services.AddDbContext<ToDoDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("connectionString")));

            return services;
        }
    }
}