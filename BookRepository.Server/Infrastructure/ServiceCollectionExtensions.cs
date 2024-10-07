using BookRepository.Data;
using ELearningPlatform.Common.DependencyInjectionContracts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookRepository.Api.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<BookRepositoryDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("BookRepositoryConnectionString")));



        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app, IConfiguration configuration)
        {
            var timeout = configuration.GetValue("MigrationsDbTimeoutInSeconds", 60);

            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<BookRepositoryDbContext>();

            dbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(timeout));
            dbContext.Database.Migrate();

            return app;
        }

        public static IApplicationBuilder UseAnyCors(
           this IApplicationBuilder app)
           => app
               .UseCors(options => options
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());

        public static IServiceCollection AddApplicationServices(
         this IServiceCollection services)
        {
            var serviceInterfaceType = typeof(IService);
            var scopedInterfaceType = typeof(IScopedService);
            var singletonInterfaceType = typeof(ISingletonService);

            var typesToRegister = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t =>
                  serviceInterfaceType.IsAssignableFrom(t) ||
                  scopedInterfaceType.IsAssignableFrom(t) ||
                  singletonInterfaceType.IsAssignableFrom(t)
                 )
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                }));

            foreach (var type in typesToRegister)
            {
                if (type.Service is null) continue;

                if (serviceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (scopedInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
                else if (singletonInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }

            }

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
           => services
             .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
