using BookRepository.Data.Models;
using BookRepository.Services.Common.DataServices.Interfaces;
using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.Books.Services.Interfaces
{
    public interface IBooksDataService : IDataService<Book>, IService
    {
        Task<bool> IsExistingByTitle(string title);
    }
}
