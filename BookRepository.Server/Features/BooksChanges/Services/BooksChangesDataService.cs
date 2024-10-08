using BookRepository.Api.Features.BooksHistories.Services.Interfaces;
using BookRepository.Data;
using BookRepository.Data.Models;
using BookRepository.Services.Common.DataServices;

namespace BookRepository.Api.Features.BookChanges.Services
{
    public class BooksChangesDataService(BookRepositoryDbContext db)
        : DataService<BookChange>(db), IBooksChangesDataService
    {
    }
}
