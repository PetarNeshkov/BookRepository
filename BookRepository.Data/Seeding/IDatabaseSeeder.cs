namespace BookRepository.Data.Seeding;

public interface IDatabaseSeeder
{
    Task SeedDatabase(BookRepositoryDbContext dbContext, IServiceProvider serviceProvider);

}