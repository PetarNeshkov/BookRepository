using Bogus;
using BookRepository.Data.Constraints;
using BookRepository.Data.Models;
using Microsoft.EntityFrameworkCore;

using static BookRepository.Data.Constraints.DatabaseConstants.Author;

namespace BookRepository.Data.Seeding
{
    public class AuthorSeeder : ISeeder
    {
        public async Task SeedAsync(BookRepositoryDbContext dbContext)
        {
            if (await dbContext.Authors.AnyAsync())
            {
                return;
            }

            var authorFaker = new Faker<Author>()
                 .RuleFor(a => a.Name, f => f.Person.FullName.Substring(0, Math.Min(f.Person.FullName.Length, NameMaxLength)))
                 .RuleFor(a => a.Bio, f =>
                 {
                     var bio = f.Lorem.Paragraphs(1, 3);

                     return bio.Length > BioMaxLength
                         ? bio[..BioMaxLength]
                         : bio;
                 });

            var authors = authorFaker.Generate(10);

            await dbContext.Authors.AddRangeAsync(authors);
        }
    }
}
