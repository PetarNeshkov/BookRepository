using BookRepository.Api.Infrastructure.AutoMapper;
using BookRepository.Data.Models;

namespace BookRepository.Api.Features.Authors.Models
{
    public class AuthorModel : IMapFrom<Author>
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Bio { get; init; }
    }
}
