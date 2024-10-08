using BookRepository.Data.Models;
using BookRepository.Services.Common.DataServices.Interfaces;
using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.BooksHistories.Services.Interfaces
{
    public interface IBooksChangesDataService : IDataService<BookChange>, IService
    {
    }
}
