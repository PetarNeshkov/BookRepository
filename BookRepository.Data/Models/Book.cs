using BookRepository.Data.Common;

namespace BookRepository.Data.Models
{
    public class Book : BaseModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public HashSet<string> Authors { get; set; } = [];
    }
}
