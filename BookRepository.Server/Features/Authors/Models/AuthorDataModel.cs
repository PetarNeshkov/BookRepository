using BookRepository.Api.Infrastructure.AutoMapper;
using BookRepository.Data.Models;

namespace BookRepository.Api.Features.Authors.Models
{
    public class AuthorDataModel : IMapFrom<Author>
    {
        public string Name { get; init; }

        public string Bio { get; init; }
    }
}
