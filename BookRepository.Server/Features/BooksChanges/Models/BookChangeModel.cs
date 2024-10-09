using BookRepository.Api.Infrastructure.AutoMapper;
using BookRepository.Data.Models;

namespace BookRepository.Api.Features.BooksChanges.Models
{
    public class BookChangeModel : IMapFrom<BookChange>
    {
        public int BookId { get; init; }

        public DateTime ChangeTime { get; init; }

        public string ChangeDescription { get; init; }
    }
}
