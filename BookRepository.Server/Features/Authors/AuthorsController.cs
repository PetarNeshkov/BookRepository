using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Features.Authors.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookRepository.Api.Features.Authors
{
    public class AuthorsController(IAuthorsBusinessService authorsBusinessService) : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequestModel model)
        {
            await authorsBusinessService.CreateNewAuthor(model);

            return this.Ok($"The {model.Name} was successfully created.");

        }

    }
}
