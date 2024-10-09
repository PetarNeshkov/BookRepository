using BookRepository.Api.Features.Books.Models;
using BookRepository.Api.Features.Books.Services.Interfaces;
using BookRepository.Api.Infrastructure.Extensions;
using BookRepository.Data;
using BookRepository.Data.Models;
using BookRepository.Services.Common.DataServices;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using static BookRepository.Services.Common.GlobalConstants;

namespace BookRepository.Api.Features.Books.Services
{
    public class BooksDataService(BookRepositoryDbContext db)
        : DataService<Book>(db), IBooksDataService
    {
        public async Task<bool> IsExistingByTitle(string title)
            => await Exists(a => a.Title == title);

        public async Task<IEnumerable<TServiceModel>> GetAllAuthorsByPage<TServiceModel>(BookFilterRequestModel filterModel)
        {
            Expression<Func<Book, bool>>? filter = null;

            if (!string.IsNullOrEmpty(filterModel.Query))
            {
                if (filterModel.FilterByTitle)
                {
                    filter = book => book.Title.Contains(filterModel.Query);
                }
                else if (filterModel.FilterByAuthor)
                {
                    filter = book => book.Authors.Any(author => author.Name.Contains(filterModel.Query));
                }
            }

            bool descending = filterModel.SortDirection == DescendingConstant;
            var skip = (filterModel.Page - 1) * filterModel.ItemsPerPage;

            return await GetQuery(
                    filter,
                    orderBy: a => a.PublishDate,
                    take: filterModel.ItemsPerPage,
                    skip: skip,
                    descending: descending)
                        .MapCollection<TServiceModel>()
                        .ToListAsync();
        }
    }
}
