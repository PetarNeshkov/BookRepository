using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Api.Features.Authors.Validators;
using BookRepository.Api.Infrastructure.Extensions;
using BookRepository.Services.Common.Enumerations;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using static BookRepository.Services.Common.GlobalConstants.ErrorMessages.Authors;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BookRepository.Api.Features.Authors
{
    public class AuthorsController(
        IAuthorsBusinessService authorsBusinessService,
        CreateAuthorValidator createValidator,
        EditAuthorValidator editValidator)
        : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequestModel model)
        {
            model.OperationType = CrudOperationType.Create;
            var validationResult = await createValidator.TestValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return UnprocessableEntity(validationResult.Errors);
            }

            return await authorsBusinessService.CreateNewAuthor(model)
                        .ToOkResult();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAuthor(EditAuthorModel model)
        {
            model.OperationType = CrudOperationType.Update;
            var validationResult = await editValidator.TestValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return UnprocessableEntity(validationResult.Errors);
            }

            return await authorsBusinessService.UpdateAuthor(model)
                .ToOkResult();
        }

        [HttpGet]
        [ProducesResponseType(typeof(AuthorResponseModel), Status200OK)]
        public async Task<IActionResult> GetAll(int page = 1)
            => await authorsBusinessService
                .GetAllAuthorsByPage(page)
                .ToOkResult();

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuthorNameModel>), Status200OK)]
        public async Task<IActionResult> GetAllAuthorsNames()
            => await authorsBusinessService
                .GetAllAuthorsNames()
                .ToOkResult();

        [HttpGet]
        public async Task<IActionResult> GetAuthorsData(int authorId)
        {
            var authorData = await authorsBusinessService
                .GetAuthorData(authorId);

            if (authorData is null)
            {
                return NotFound(AuthorNotFoundMessage);
            }


            return Ok(authorData);
        }
    }
}
