using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Api.Features.Authors.Validators;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using static BookRepository.Services.Common.GlobalConstants;

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

            await authorsBusinessService.CreateNewAuthor(model);

            return Ok(string.Format(SuccessfulCreationMessage, model.Name));

        }

    }
}
