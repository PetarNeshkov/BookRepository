using BookRepository.Api.Features.BookChanges.Models;
using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.BookChanges.Services.Interfaces
{
    public interface IBooksChangesBusinessService : IService
    {
        Task CreateBookChangeLog(BookChangeModel model);
    }
}
