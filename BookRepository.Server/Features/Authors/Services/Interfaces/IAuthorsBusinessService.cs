using BookRepository.Api.Features.Authors.Models;
using ELearningPlatform.Common.DependencyInjectionContracts;

namespace BookRepository.Api.Features.Authors.Services.Interfaces
{
    public interface IAuthorsBusinessService : IService
    {
        Task CreateNewAuthor(CreateAuthorRequestModel model);
    }
}
