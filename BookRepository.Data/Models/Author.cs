using BookRepository.Data.Common;
using System.ComponentModel.DataAnnotations;

using static BookRepository.Data.Constraints.ConstraintConstants.Author;

namespace BookRepository.Data.Models
{
    public class Author : BaseModel<int>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(BioMaxLength, MinimumLength = BioMinLength)]
        public string Bio { get; set; }
    }
}
