using BookRepository.Services.Common.Validations;

namespace BookRepository.Api.Features.Authors.Models
{
    public class EditAuthorModel : BaseModel<int>
    {
        public string Name { get; init; }

        public string Bio { get; init; }

        public string OriginalName { get; init; }
        public string OriginalBio { get; init; }
    }
}
