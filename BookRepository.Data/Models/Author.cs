using BookRepository.Data.Common;

namespace BookRepository.Data.Models
{
    public class Author : BaseModel<int>
    {
        public string Name { get; set; }

        public string Bio { get; set; }
    }
}
