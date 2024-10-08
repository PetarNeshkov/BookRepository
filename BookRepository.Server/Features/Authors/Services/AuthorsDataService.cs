﻿using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Api.Infrastructure.Extensions;
using BookRepository.Data;
using BookRepository.Data.Models;
using BookRepository.Services.Common.DataServices;
using Microsoft.EntityFrameworkCore;

namespace BookRepository.Api.Features.Authors.Services
{
    public class AuthorsDataService(BookRepositoryDbContext db)
        : DataService<Author>(db), IAuthorsDataService
    {
        public async Task<IEnumerable<AuthorNameModel>> GetAllAuthorsNames()
          => await GetQuery(orderBy: x => x.CreatedOn, descending: true)
                  .MapCollection<AuthorNameModel>()
                  .ToListAsync();

        public async Task<IEnumerable<TServiceModel>> GetAllAuthorsByPage<TServiceModel>(int itemsPerPage, int skip)
                    => await GetQuery(take: itemsPerPage, skip: skip, orderBy: x => x.CreatedOn, descending: true)
                        .MapCollection<TServiceModel>()
                        .ToListAsync();

        public Task<bool> IsExistingByName(string name)
            => Exists(a => a.Name == name);

        public async Task<IEnumerable<Author>> GetAuthorsByIds(IEnumerable<int> authorIds)
            => await GetQuery(a => authorIds.Contains(a.Id))
                    .ToListAsync();
    }
}
