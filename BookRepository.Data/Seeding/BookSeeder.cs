using Bogus;
using BookRepository.Data.Models;
using Microsoft.EntityFrameworkCore;
using static BookRepository.Data.Constraints.DatabaseConstants.Book;
using static BookRepository.Data.Constraints.DatabaseConstants.Errors;

namespace BookRepository.Data.Seeding
{
    public class BookSeeder : ISeeder
    {
        public async Task SeedAsync(BookRepositoryDbContext dbContext)
        {
            if (await dbContext.Books.AnyAsync())
            {
                return;
            }

            var authors = await dbContext.Authors.ToListAsync();
            var random = new Random();

            if (authors.Count == 0)
            {
                throw new InvalidOperationException(BooksCannotBeSeeded);
            }

            var bookFaker = new Faker<Book>()
                   .RuleFor(b => b.Title, f =>
                   {
                       var title = f.Lorem.Sentence(3, 5);

                       return title.Length > TitleMaxLength
                           ? title[..TitleMaxLength]
                           : title;
                   })
                   .RuleFor(b => b.Description, f =>
                   {
                       var description = f.Lorem.Sentence(DescriptionMinLength, DescriptionMaxLength);

                       return description.Length > DescriptionMaxLength
                           ? description[..DescriptionMaxLength]
                           : description;
                   })
                   .RuleFor(b => b.PublishDate, f => f.Date.Past(200).Date)
                   .RuleFor(b => b.Authors, f =>
                   {
                       var assignedAuthors = authors.OrderBy(x => f.Random.Guid()).Take(f.Random.Int(1, 3)).ToList();

                       return assignedAuthors;
                   });

            var books = bookFaker.Generate(14);

            await dbContext.Books.AddRangeAsync(books);
        }
    }
}
