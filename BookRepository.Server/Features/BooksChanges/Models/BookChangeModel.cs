namespace BookRepository.Api.Features.BookChanges.Models
{
    public class BookChangeModel
    {
        public int BookId { get; init; }

        public DateTime ChangeTime { get; init; }

        public string ChangeDescription { get; init; }
    }
}
