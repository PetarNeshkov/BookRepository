using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Services.Common.Validations;
using FluentValidation;
using static BookRepository.Services.Common.GlobalConstants.ErrorMessages.Authors;

namespace BookRepository.Api.Features.Authors.Validators
{
    public class CreateAuthorValidator : BaseModelValidator<CreateAuthorRequestModel, int>
    {
        public CreateAuthorValidator(IAuthorsDataService authorsDataService)
        {

            RuleFor(author => author.Name)
                .NotEmpty()
                .WithMessage(NameIsRequiredMessage)
                .MaximumLength(100)
                .WithMessage(string.Format(NameMaxLengthMessage, 100))
                .MustAsync(async (name, cancellation) => !await authorsDataService.IsExistingByName(name))
                .WithMessage(ExistsMessage);

            RuleFor(author => author.Bio)
                .NotEmpty()
                .WithMessage(BioIsRequiredMessage)
                .MinimumLength(10)
                .WithMessage(string.Format(BioMinLengthMessage, 10))
                .MaximumLength(1000)
                .WithMessage(string.Format(BioMaxLengthMessage, 1000));
        }
    }
}
