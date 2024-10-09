using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Api.Features.Books.Models;
using BookRepository.Api.Features.Books.Services.Interfaces;
using BookRepository.Api.Features.BooksChanges.Services.Interfaces;
using BookRepository.Api.Infrastructure.Extensions;
using BookRepository.Data.Models;
using static BookRepository.Services.Common.GlobalConstants;
namespace BookRepository.Api.Features.Books.Services
{
    public class BooksBusinessService(
        IBooksDataService booksDataService,
        IAuthorsDataService authorsDataService,
        IBooksChangesBusinessService booksChangesBusinessService)
        : IBooksBusinessService
    {
        public async Task<BookResponseModel> GetCurrentBooks(BookFilterRequestModel filterRequestModel)
        {
            var booksTotalCount = await booksDataService.Count();

            var filteredBooks = await booksDataService.GetAllAuthorsByPage<BookModel>(filterRequestModel);

            return new BookResponseModel
            {
                Books = filteredBooks,
                BooksTotalCount = booksTotalCount
            };
        }

        public async Task<string> CreateNewBook(CreateBookRequestModel model)
        {
            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                PublishDate = model.PublishDate!.Value.Date,
            };

            var authors = await authorsDataService.GetAuthorsByIds(model.Authors);
            book.Authors = authors.ToList();

            await booksDataService.Add(book);

            await booksDataService.SaveChanges();

            var successfulMessage = string.Format(SuccessfulCreationMessage, model.Title);

            await booksChangesBusinessService.CreateBookChangeLog(book.Id, successfulMessage);


            return string.Format(SuccessfulCreationMessage, model.Title);
        }

        public async Task<string> DeleteBook(int id)
        {
            var bookToDelete = await booksDataService.OneById(id);

            booksDataService.Delete(bookToDelete!);

            await booksDataService.SaveChanges();

            var successfulMessage = string.Format(SuccessfulDeleteMessage, bookToDelete!.Title);

            await booksChangesBusinessService.CreateBookChangeLog(bookToDelete.Id, successfulMessage);

            return string.Format(SuccessfulCreationMessage, bookToDelete.Title);

        }

        public async Task<BookModel?> GetBookData(int bookId)
        {
            var authorEntity = await booksDataService.GetByIdWithAuthors(bookId);

            if (authorEntity is null)
            {
                return null;
            }

            return authorEntity.Map<BookModel>();
        }
    }
}
