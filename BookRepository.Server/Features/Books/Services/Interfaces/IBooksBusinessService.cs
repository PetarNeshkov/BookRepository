using BookRepository.Api.Features.Books.Models;
using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.Books.Services.Interfaces
{
    public interface IBooksBusinessService : IService
    {
        Task<string> CreateNewBook(CreateBookRequestModel model);
    }
}
