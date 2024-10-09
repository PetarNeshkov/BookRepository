using static BookRepository.Services.Common.GlobalConstants;

namespace BookRepository.Api.Features.Books.Models
{
    public class BookFilterRequestModel
    {
        public int Page { get; init; } = DefaultPage;

        public int ItemsPerPage { get; init; } = DefaultItemsPerPage;

        public string? Query { get; init; }

        public bool FilterByTitle { get; init; }

        public bool FilterByAuthor { get; init; }

        public string SortDirection { get; init; } = AscendingConstant;
    }
}
