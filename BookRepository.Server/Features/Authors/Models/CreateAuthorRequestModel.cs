using BookRepository.Services.Common.Validations;

namespace BookRepository.Api.Features.Authors.Models
{
    public class CreateAuthorRequestModel : BaseModel<int>
    {
        public string Name { get; init; }

        public string Bio { get; init; }
    }
}
