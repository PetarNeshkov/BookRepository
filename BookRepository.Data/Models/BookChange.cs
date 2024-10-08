using System.ComponentModel.DataAnnotations;
using static BookRepository.Data.Constraints.ConstraintConstants;
using static BookRepository.Data.Constraints.ConstraintConstants.BookChange;

namespace BookRepository.Data.Models
{
    public class BookChange
    {
        [Key]
        [MaxLength(KeyMaxLength)]
        public int Id { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public required DateTime ChangeTime { get; set; }

        [Required]
        [MaxLength(ChangeDesriptionMaxLength)]
        public required string ChangeDescription { get; set; }
    }
}
