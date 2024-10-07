using BookRepository.Services.Common.Enumerations;

namespace BookRepository.Services.Common.Validations
{
    public abstract class BaseModel<TId>
    {
        public TId Id { get; set; }

        public CrudOperationType OperationType { get; set; }
    }
}
