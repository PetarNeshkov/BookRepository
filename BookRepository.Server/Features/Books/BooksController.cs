using BookRepository.Api.Features.Books.Models;
using BookRepository.Api.Features.Books.Services.Interfaces;
using BookRepository.Api.Features.Books.Validators;
using BookRepository.Api.Infrastructure.Extensions;
using BookRepository.Services.Common.Enumerations;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;

using static BookRepository.Services.Common.GlobalConstants.ErrorMessages.Books;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BookRepository.Api.Features.Books
{
    public class BooksController(
        IBooksBusinessService booksBusinessService,
        CreateBookValidator createValidator,
        DeleteBookValidator deleteBookValidator,
        EditBookValidator editBookValidator)
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

        [HttpDelete]
        public async Task<IActionResult> DeleteBook([FromQuery] DeleteBookRequestModel model)
        {
            model.OperationType = CrudOperationType.Delete;
            var validationResult = await deleteBookValidator.TestValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return UnprocessableEntity(validationResult.Errors);
            }

            return await booksBusinessService.DeleteBook(model.Id)
                   .ToOkResult();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateBook(EditBookModel model)
        {
            model.OperationType = CrudOperationType.Update;
            var validationResult = await editBookValidator.TestValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return UnprocessableEntity(validationResult.Errors);
            }

            return await booksBusinessService.UpdateBook(model)
                .ToOkResult();
        }


        [HttpGet]
        [ProducesResponseType(typeof(BookResponseModel), Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] BookFilterRequestModel model)
            => await booksBusinessService.GetCurrentBooks(model)
                    .ToOkResult();

        [HttpGet]
        public async Task<IActionResult> GetBookData(int bookId)
        {
            var bookData = await booksBusinessService
                .GetBookData(bookId);

            if (bookData is null)
            {
                return NotFound(NotFoundMessage);
            }

            return Ok(bookData);
        }
    }
}
