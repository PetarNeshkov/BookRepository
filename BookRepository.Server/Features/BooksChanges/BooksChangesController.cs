using BookRepository.Api.Features.BooksChanges.Models;
using BookRepository.Api.Features.BooksChanges.Services.Interfaces;
using BookRepository.Api.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BookRepository.Api.Features.BooksChanges
{
    public class BooksChangesController(IBooksChangesBusinessService booksChangesBusinessService)
        : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(BookChangeResponseModel), Status200OK)]
        public async Task<IActionResult> GetAll(int page = 1)
            => await booksChangesBusinessService.GetCurrentChanges(page)
                    .ToOkResult();
    }
}
