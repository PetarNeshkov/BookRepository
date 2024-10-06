
using System.ComponentModel.DataAnnotations;

namespace BookRepository.Data.Common
{
    public abstract class BaseModel<T> : IAuditInfo
    {

        [Key]
        [MaxLength(40)]
        public T Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
