
using BookRepository.Data;
using BookRepository.Data.Seeding;

namespace UsersChart.Data.Seeding;

public class BookRepositoryDbContextSeeder : IDatabaseSeeder
{
    public async Task SeedDatabase(BookRepositoryDbContext dbContext, IServiceProvider serviceProvider)
    {
        if (dbContext == null)
        {
            throw new ArgumentNullException(nameof(dbContext));
        }

        if (serviceProvider == null)
        {
            throw new ArgumentNullException(nameof(serviceProvider));
        }

        var seeders = new List<ISeeder>
        {
            new AuthorSeeder(),
            new BookSeeder(),
        };

        foreach (var seeder in seeders)
        {
            await seeder.SeedAsync(dbContext);

            await dbContext.SaveChangesAsync();
        }
    }
}