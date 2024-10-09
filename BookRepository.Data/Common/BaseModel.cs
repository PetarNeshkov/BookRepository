
using System.ComponentModel.DataAnnotations;
using static BookRepository.Data.Constraints.DatabaseConstants;

namespace BookRepository.Data.Common
{
    public abstract class BaseModel<TId> : IAuditInfo
    {

        [Key]
        [MaxLength(KeyMaxLength)]
        public TId Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
