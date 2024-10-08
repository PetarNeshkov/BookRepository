﻿using BookRepository.Api.Features.Books.Models;
using BookRepository.Api.Features.Books.Services.Interfaces;
using BookRepository.Services.Common.Validations;
using FluentValidation;
using static BookRepository.Services.Common.GlobalConstants.ErrorMessages.Books;

namespace BookRepository.Api.Features.Books.Validators
{
    public class CreateBookValidator : BaseModelValidator<CreateBookRequestModel, int>
    {
        public CreateBookValidator(IBooksDataService booksDataService)
        {

            RuleFor(book => book.Title)
                .NotEmpty()
                .WithMessage(TitleIsRequiredMessage)
                .MaximumLength(30)
                .WithMessage(string.Format(TitleMaxLengthMessage, 30))
                .MustAsync(async (name, cancellation) => !await booksDataService.IsExistingByTitle(name))
                .WithMessage(ExistsMessage);

            RuleFor(book => book.Description)
                .NotEmpty()
                .WithMessage(DescriptionIsRequired)
                .MinimumLength(10)
                .WithMessage(string.Format(DescriptionMinLengthMessage, 10))
                .MaximumLength(1000)
                .WithMessage(string.Format(DescriptionMaxLengthMessage, 500));

            RuleFor(book => book.Authors)
                .NotEmpty()
                .WithMessage(AuthorIsRequiredMessage)
                .Must(authors => authors.Count() <= 3)
                .WithMessage(string.Format(AuthorsMaxCountMessage, 3));

        }
    }
}
