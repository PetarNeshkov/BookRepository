using BookRepository.Api.Features.Authors.Models;
using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.Authors.Services.Interfaces
{
    public interface IAuthorsBusinessService : IService
    {
        Task<AuthorResponseModel> GetAllAuthorsByPage(int page);

        Task<IEnumerable<AuthorNameModel>> GetAllAuthorsNames();

        Task<AuthorDataModel?> GetAuthorData(int authorId);

        Task<string> CreateNewAuthor(CreateAuthorRequestModel model);

    }
}
