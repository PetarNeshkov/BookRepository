using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.BooksChanges.Services.Interfaces
{
    public interface IBooksChangesBusinessService : IService
    {
        Task CreateBookChangeLog(int bookId, string description);
    }
}
