using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Data.Models;

namespace BookRepository.Api.Features.Authors.Services
{
    public class AuthorsBusinessService(
        IAuthorsDataService authorsDataService) : IAuthorsBusinessService
    {
        public async Task CreateNewAuthor(CreateAuthorRequestModel model)
        {

            var author = new Author
            {
                Name = model.Name,
                Bio = model.Bio
            };

            await authorsDataService.Add(author);

            await authorsDataService.SaveChanges();
        }
    }
}
