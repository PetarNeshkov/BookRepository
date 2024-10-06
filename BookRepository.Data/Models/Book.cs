using BookRepository.Data.Common;
using System.ComponentModel.DataAnnotations;

using static BookRepository.Data.Constraints.ConstraintConstants.Book;

namespace BookRepository.Data.Models
{
    public class Book : BaseModel<int>
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public HashSet<string> Authors { get; set; } = [];
    }
}
