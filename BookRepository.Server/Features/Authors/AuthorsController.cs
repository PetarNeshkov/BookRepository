using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Api.Features.Authors.Validators;
using BookRepository.Api.Infrastructure.Extensions;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BookRepository.Api.Features.Authors
{
    public class AuthorsController(
        IAuthorsBusinessService authorsBusinessService,
        AuthorsValidator validator)
        : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequestModel model)
        {
            var validationResult = await validator.TestValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return UnprocessableEntity(validationResult.Errors);
            }

            return await authorsBusinessService.CreateNewAuthor(model)
                        .ToOkResult();
        }

        [HttpGet]
        [ProducesResponseType(typeof(AuthorResponseModel), Status200OK)]
        public async Task<IActionResult> GetAll(int page = 1)
            => await authorsBusinessService
                .GetAllAuthorsByPage(page)
                .ToOkResult();
    }
}
