using BookRepository.Data.Common;
using System.ComponentModel.DataAnnotations;

using static BookRepository.Data.Constraints.DatabaseConstants.Author;

namespace BookRepository.Data.Models
{
    public class Author : BaseModel<int>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        [Required]
        [StringLength(BioMaxLength, MinimumLength = BioMinLength)]
        public required string Bio { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
