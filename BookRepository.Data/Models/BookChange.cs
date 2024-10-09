using System.ComponentModel.DataAnnotations;
using static BookRepository.Data.Constraints.DatabaseConstants;

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
        public required string ChangeDescription { get; set; }
    }
}
