namespace BookRepository.Api.Features.Books.Models
{
    public class BookResponseModel
    {
        public IEnumerable<BookModel> Books { get; set; }

        public int BooksTotalCount { get; set; }
    }
}
