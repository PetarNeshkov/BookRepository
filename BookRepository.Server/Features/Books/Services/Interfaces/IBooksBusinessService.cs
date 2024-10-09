using BookRepository.Api.Features.Books.Models;
using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.Books.Services.Interfaces
{
    public interface IBooksBusinessService : IService
    {
        Task<BookResponseModel> GetCurrentBooks(BookFilterRequestModel model);

        Task<BookModel?> GetBookData(int bookId);

        Task<string> CreateNewBook(CreateBookRequestModel model);

        Task<string> UpdateBook(EditBookModel model);

        Task<string> DeleteBook(int id);
    }
}
