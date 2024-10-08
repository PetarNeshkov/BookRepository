using BookRepository.Api.Features.Books.Services.Interfaces;
using BookRepository.Data;
using BookRepository.Data.Models;
using BookRepository.Services.Common.DataServices;

namespace BookRepository.Api.Features.Books.Services
{
    public class BooksDataService(BookRepositoryDbContext db)
        : DataService<Book>(db), IBooksDataService
    {
        public async Task<bool> IsExistingByTitle(string title)
            => await Exists(a => a.Title == title);
    }
}
