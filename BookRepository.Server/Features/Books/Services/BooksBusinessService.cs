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


            return successfulMessage;
        }

        public async Task<string> UpdateBook(EditBookModel model)
        {
            var book = await booksDataService.OneById(model.Id);

            var originalTitle = book!.Title;
            var originalDescription = book.Description;
            var originalPublishDate = book.PublishDate.Date;
            var originalAuthors = string.Join(", ", book.Authors.Select(a => a.Name));

            await ApplyBookUpdates(booksDataService, authorsDataService, model, book);

            var newTitle = book.Title;
            var newDescription = book.Description;
            var newPublishDate = book.PublishDate.Date;
            var newAuthors = string.Join(", ", book.Authors.Select(a => a.Name));

            var successfulMessage = string.Format(
                    SuccessfulBookUpdateMessage,
                    originalTitle, originalDescription, originalPublishDate.ToString("dd/MM/yyyy"), originalAuthors,
                    newTitle, newDescription, newPublishDate.ToString("dd/MM/yyyy"), newAuthors
                );

            await booksChangesBusinessService.CreateBookChangeLog(book.Id, successfulMessage);


            return successfulMessage;
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

        private static async Task ApplyBookUpdates(IBooksDataService booksDataService, IAuthorsDataService authorsDataService, EditBookModel model, Book? book)
        {
            book!.Title = model.Title;
            book!.Description = model.Description;
            book!.PublishDate = model.PublishDate!.Value.Date;
            book.Authors.Clear();

            var authors = await authorsDataService.GetAuthorsByIds(model.Authors);
            book.Authors = authors.ToList();

            booksDataService.Update(book);
            await booksDataService.SaveChanges();
        }
    }
}
