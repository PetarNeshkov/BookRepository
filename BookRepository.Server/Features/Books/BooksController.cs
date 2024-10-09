using BookRepository.Api.Features.Books.Models;
using BookRepository.Api.Features.Books.Services.Interfaces;
using BookRepository.Api.Features.Books.Validators;
using BookRepository.Api.Infrastructure.Extensions;
using BookRepository.Services.Common.Enumerations;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BookRepository.Api.Features.Books
{
    public class BooksController(
        IBooksBusinessService booksBusinessService,
        CreateBookValidator createValidator)
        : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookRequestModel model)
        {
            model.OperationType = CrudOperationType.Create;
            var validationResult = await createValidator.TestValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return UnprocessableEntity(validationResult.Errors);
            }

            return await booksBusinessService.CreateNewBook(model)
                        .ToOkResult();
        }

        [HttpGet]
        [ProducesResponseType(typeof(BookResponseModel), Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] BookFilterRequestModel model)
            => await booksBusinessService.GetCurrentBooks(model)
                    .ToOkResult();
    }
}
