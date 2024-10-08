using BookRepository.Data.Models;
using BookRepository.Services.Common.DataServices.Interfaces;
using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.BooksChanges.Services.Interfaces
{
    public interface IBooksChangesDataService : IDataService<BookChange>, IService
    {
    }
}
