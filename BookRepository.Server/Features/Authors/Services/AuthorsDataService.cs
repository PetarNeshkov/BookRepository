using BookRepository.Api.Features.Authors.Services.Interfaces;
using BookRepository.Data;
using BookRepository.Data.Models;
using BookRepository.Services.Common;

namespace BookRepository.Api.Features.Authors.Services
{
    public class AuthorsDataService(BookRepositoryDbContext db)
        : DataService<Author>(db), IAuthorsDataService
    {
        public Task<bool> IsExistingByName(string name)
            => Exists(a => a.Name == name);
    }
}
