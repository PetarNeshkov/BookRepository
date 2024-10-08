using BookRepository.Api.Features.BooksChanges.Services.Interfaces;
using BookRepository.Data;
using BookRepository.Data.Models;
using BookRepository.Services.Common.DataServices;

namespace BookRepository.Api.Features.BooksChanges.Services
{
    public class BooksChangesDataService(BookRepositoryDbContext db)
        : DataService<BookChange>(db), IBooksChangesDataService
    {
    }
}
