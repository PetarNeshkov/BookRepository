namespace BookRepository.Api.Features.Authors.Models
{
    public class AuthorResponseModel
    {
        public IEnumerable<AuthorModel> Authors { get; set; }

        public int AuthorsTotalCount { get; set; }
    }
}
