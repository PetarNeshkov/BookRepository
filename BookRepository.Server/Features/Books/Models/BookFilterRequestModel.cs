using static BookRepository.Services.Common.GlobalConstants;

namespace BookRepository.Api.Features.Books.Models
{
    public class BookFilterRequestModel
    {
        public int Page { get; set; } = DefaultPage;

        public int ItemsPerPage { get; set; } = DefaultItemsPerPage;

        public string? Query { get; set; }

        public bool FilterByTitle { get; set; }

        public bool FilterByAuthor { get; set; }

        public string SortDirection { get; set; } = AscendingConstant;
    }
}
