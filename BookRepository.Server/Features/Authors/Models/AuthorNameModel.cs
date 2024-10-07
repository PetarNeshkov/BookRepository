using BookRepository.Api.Infrastructure.AutoMapper;
using BookRepository.Data.Models;

namespace BookRepository.Api.Features.Authors.Models
{
    public class AuthorNameModel : IMapFrom<Author>
    {
        public string Name { get; init; }
    }
}
