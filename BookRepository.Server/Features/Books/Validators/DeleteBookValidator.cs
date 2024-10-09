using BookRepository.Api.Features.Books.Models;
using BookRepository.Api.Features.Books.Services.Interfaces;
using BookRepository.Services.Common.Validations;

namespace BookRepository.Api.Features.Books.Validators
{
    public class DeleteBookValidator : BaseModelValidator<DeleteBookRequestModel, int>
    {
        public DeleteBookValidator(IBooksDataService booksDataService)
        {
            AddIdValidation(booksDataService);            
        }
    }
}
