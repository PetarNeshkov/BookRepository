using BookRepository.Api.Features.BookChanges.Models;
using BookRepository.Api.Features.Books.Services.Interfaces;
using BookRepository.Api.Features.BooksHistories.Services.Interfaces;
using BookRepository.Data.Models;

namespace BookRepository.Api.Features.BookChanges.Services
{
    public class BooksChangesBusinessService(IBooksChangesDataService bookChangesDataService)
        : IBooksBusinessService
    {
        public async Task CreateNewBook(BookChangeModel model)
        {
            var bookChange = new BookChange
            {
                BookId = model.BookId,
                ChangeDescription = model.ChangeDescription,
                ChangeTime = DateTime.Now.ToLocalTime(),
            };

            await bookChangesDataService.Add(bookChange);

            await bookChangesDataService.SaveChanges();
        }
    }
}
