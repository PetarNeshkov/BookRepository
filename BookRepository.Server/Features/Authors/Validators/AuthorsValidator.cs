using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Services.Common.Validations;
using FluentValidation;
using static BookRepository.Services.Common.GlobalConstants.ErrorMessages.Authors;

namespace BookRepository.Api.Features.Authors.Validators
{
    public class AuthorsValidator : BaseModelValidator<CreateAuthorRequestModel, int>
    {
        private readonly IAuthorsDataService authorsDataService;

        public AuthorsValidator(IAuthorsDataService authorsDataService)
        {

            RuleFor(author => author.Name)
                .NotEmpty()
                .WithMessage(AuthorNameIsRequredMessage)
                .MaximumLength(100)
                .WithMessage(string.Format(AuthorNameMaxLengthMessage, 100))
                .MustAsync(async (name, cancellation) => !await authorsDataService.IsExistingByName(name))
                .WithMessage(AuthorExistsMessage);

            RuleFor(author => author.Bio)
                .NotEmpty()
                .WithMessage(AuthorBioIsRequredMessage)
                .MinimumLength(10)
                .WithMessage(string.Format(AuthorBioMinLengthMessage, 10))
                .MaximumLength(1000)
                .WithMessage(string.Format(AuthorBioMaxLengthMessage, 1000));
        }
    }
}
