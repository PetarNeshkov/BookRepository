
using System.ComponentModel.DataAnnotations;
using static BookRepository.Data.Constraints.ConstraintConstants;

namespace BookRepository.Data.Common
{
    public abstract class BaseModel<TId> : IAuditInfo<TId>
    {

        [Key]
        [MaxLength(KeyMaxLength)]
        public TId Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
