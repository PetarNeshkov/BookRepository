using BookRepository.Api.Features.BooksChanges.Services.Interfaces;
using BookRepository.Api.Infrastructure.Extensions;
using BookRepository.Data;
using BookRepository.Data.Models;
using BookRepository.Services.Common.DataServices;
using Microsoft.EntityFrameworkCore;

using static BookRepository.Services.Common.GlobalConstants;

namespace BookRepository.Api.Features.BooksChanges.Services
{
    public class BooksChangesDataService(BookRepositoryDbContext db)
        : DataService<BookChange>(db), IBooksChangesDataService
    {
        public async Task<IEnumerable<TServiceModel>> GetCurrentBooksChanges<TServiceModel>(int page = 1)
        {
            var skip = (page - 1) * DefaultItemsPerPage;

            return await GetQuery(take: DefaultItemsPerPage, skip: skip, orderBy: x => x.ChangeTime, descending: true)
                        .MapCollection<TServiceModel>()
                        .ToListAsync();
        }
    }
}
