using BookRepository.Api.Features.BooksChanges.Models;
using BookRepository.Api.Features.BooksChanges.Services.Interfaces;
using BookRepository.Data.Models;

namespace BookRepository.Api.Features.BooksChanges.Services
{
    public class BooksChangesBusinessService(
        IBooksChangesDataService bookChangesDataService)
        : IBooksChangesBusinessService
    {
        public async Task CreateBookChangeLog(int bookId, string description)
        {
            var bookChange = new BookChange
            {
                BookId = bookId,
                ChangeDescription = description,
                ChangeTime = DateTime.Now.ToLocalTime(),
            };

            await bookChangesDataService.Add(bookChange);

            await bookChangesDataService.SaveChanges();
        }

        public async Task<BookChangeResponseModel> GetCurrentChanges(int page = 1)
        {
            var authorsTotalCount = await bookChangesDataService.Count();

            var authorsPerPage = await bookChangesDataService.GetCurrentBooksChanges<BookChangeModel>(page);

            return new BookChangeResponseModel
            {
                BooksChanges = authorsPerPage,
                BooksChangesTotalCount = authorsTotalCount,
            }; ;
        }
    }
}
