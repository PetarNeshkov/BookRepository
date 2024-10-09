using BookRepository.Data.Common;
using System.ComponentModel.DataAnnotations;

using static BookRepository.Data.Constraints.DatabaseConstants.Book;

namespace BookRepository.Data.Models
{
    public class Book : BaseModel<int>
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public required string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public required string Description { get; set; }

        public required DateTime PublishDate { get; set; }

        public ICollection<Author> Authors { get; set; } = new HashSet<Author>();
    }
}
