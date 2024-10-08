using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Services.Common.Validations;
using FluentValidation;

using static BookRepository.Services.Common.GlobalConstants.ErrorMessages.Authors;

namespace BookRepository.Api.Features.Authors.Validators
{
    public class EditAuthorValidator : BaseModelValidator<EditAuthorModel, int>
    {
        private readonly IAuthorsDataService authorsDataService;
        public EditAuthorValidator(IAuthorsDataService authorsDataService)
        {
            AddIdValidation(authorsDataService);

            RuleFor(author => author.Name)
                .NotEmpty()
                .WithMessage(NameIsRequiredMessage)
                .MaximumLength(100)
                .WithMessage(string.Format(NameMaxLengthMessage, 100))
                .MustAsync(async (author, name, cancellation) =>
                    author.OriginalName == name || !await authorsDataService.IsExistingByName(name))
                .WithMessage(ExistsMessage);

            RuleFor(author => author.Bio)
                .NotEmpty()
                .WithMessage(BioIsRequiredMessage)
                .MinimumLength(10)
                .WithMessage(string.Format(BioMinLengthMessage, 10))
                .MaximumLength(1000)
                .WithMessage(string.Format(BioMaxLengthMessage, 1000))
                .When(author => author.Bio != author.OriginalBio);
        }
    }
}
