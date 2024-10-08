namespace BookRepository.Api.Features.BooksChanges.Models
{
    public class BookChangeModel
    {
        public int BookId { get; init; }

        public DateTime ChangeTime { get; init; }

        public string ChangeDescription { get; init; }
    }
}
