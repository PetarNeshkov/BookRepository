namespace BookRepository.Data.Seeding;

public interface ISeeder
{
    Task SeedAsync(BookRepositoryDbContext dbContext);
}