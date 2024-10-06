using BookRepository.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}
