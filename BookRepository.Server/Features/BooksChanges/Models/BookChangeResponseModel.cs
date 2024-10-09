namespace BookRepository.Api.Features.BooksChanges.Models
{
    public class BookChangeResponseModel
    {
        public IEnumerable<BookChangeModel> BooksChanges { get; init; }
        public int BooksChangesTotalCount { get; init; }
    }
}
