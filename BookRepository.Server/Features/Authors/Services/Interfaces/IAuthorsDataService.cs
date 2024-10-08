using BookRepository.Api.Features.Authors.Models;
using BookRepository.Data.Models;
using BookRepository.Services.Common.DataServices.Interfaces;
using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.Authors.Services.Interfaces
{
    public interface IAuthorsDataService : IDataService<Author>, IService
    {
        Task<bool> IsExistingByName(string name);

        Task<IEnumerable<TServiceModel>> GetAllAuthorsByPage<TServiceModel>(int itemsPerPage, int skip);

        Task<IEnumerable<AuthorNameModel>> GetAllAuthorsNames();

        Task<IEnumerable<Author>> GetAuthorsByIds(IEnumerable<int> authorIds);
    }
}
