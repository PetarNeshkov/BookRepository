using BookRepository.Api.Features.Authors.Models;
using BookRepository.Api.Infrastructure.AutoMapper;
using BookRepository.Data.Models;

namespace BookRepository.Api.Features.Books.Models
{
    public class BookModel : IMapFrom<Book>
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }

        public DateTime PublishDate { get; init; }

        public IEnumerable<AuthorNameModel> Authors { get; init; }
    }
}
