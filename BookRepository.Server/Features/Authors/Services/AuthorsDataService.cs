using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Api.Infrastructure.Extensions;
using BookRepository.Data;
using BookRepository.Data.Models;
using BookRepository.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace BookRepository.Api.Features.Authors.Services
{
    public class AuthorsDataService(BookRepositoryDbContext db)
        : DataService<Author>(db), IAuthorsDataService
    {
        public async Task<IEnumerable<TServiceModel>> GetAllAuthorsByPage<TServiceModel>(int itemsPerPage, int skip)
            => await GetQuery(take: itemsPerPage, skip: skip, orderBy: x => x.CreatedOn, descending: true)
                .MapCollection<TServiceModel>()
                .ToListAsync();

        public Task<bool> IsExistingByName(string name)
            => Exists(a => a.Name == name);
    }
}
