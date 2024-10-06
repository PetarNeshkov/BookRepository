using BookRepository.Data.Models;
using BookRepository.Services.Common.Interfaces;
using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.Authors.Services.Interfaces
{
    public interface IAuthorsDataService : IDataService<Author>, IService
    {
        Task<bool> IsExistingByName(string name);
    }
}
