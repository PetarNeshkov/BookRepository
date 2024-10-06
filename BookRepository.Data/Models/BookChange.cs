using System.ComponentModel.DataAnnotations;

using static BookRepository.Data.Constraints.ConstraintConstants.BookChange;

namespace BookRepository.Data.Models
{
    public class BookChange
    {
        [Key]
        [MaxLength(40)]
        public required int Id { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public DateTime ChangeTime { get; set; }

        [Required]
        [MaxLength(ChangeDesriptionMaxLength)]
        public string ChangeDescription { get; set; }
    }
}
