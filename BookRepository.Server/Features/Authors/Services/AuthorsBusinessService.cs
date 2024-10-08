﻿using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Api.Infrastructure.Extensions;
using BookRepository.Data.Models;

using static BookRepository.Services.Common.GlobalConstants;

namespace BookRepository.Api.Features.Authors.Services
{
    public class AuthorsBusinessService(
        IAuthorsDataService authorsDataService) : IAuthorsBusinessService
    {
        public async Task<AuthorResponseModel> GetAllAuthorsByPage(int page)
        {
            var skip = (page - 1) * DefaultItemsPerPage;

            var authorsTotalCount = await authorsDataService.Count();

            var authorsPerPage = await authorsDataService.GetAllAuthorsByPage<AuthorModel>(DefaultItemsPerPage, skip);

            return new AuthorResponseModel
            {
                Authors = authorsPerPage,
                AuthorsTotalCount = authorsTotalCount,
            };
        }

        public async Task<IEnumerable<AuthorNameModel>> GetAllAuthorsNames()
            => await authorsDataService.GetAllAuthorsNames();

        public async Task<AuthorDataModel?> GetAuthorData(int authorId)
        {
            var authorEntity = await authorsDataService.OneById(authorId);

            if (authorEntity is null)
            {
                return null;
            }

            return authorEntity.Map<AuthorDataModel>();
        }

        public async Task<string> CreateNewAuthor(CreateAuthorRequestModel model)
        {

            var author = new Author
            {
                Name = model.Name,
                Bio = model.Bio
            };

            await authorsDataService.Add(author);

            await authorsDataService.SaveChanges();

            return string.Format(SuccessfulCreationMessage, model.Name);
        }

        public async Task<string> UpdateAuthor(EditAuthorModel model)
        {
            var author = await authorsDataService.OneById(model.Id);

            author!.Name = model.Name;
            author!.Bio = model.Bio;

            authorsDataService.Update(author);

            await authorsDataService.SaveChanges();

            return string.Format(SuccessfulEditMessage, model.Name);

        }
    }
}
