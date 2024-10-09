﻿using BookRepository.Services.Common.Validations;

namespace BookRepository.Api.Features.Books.Models
{
    public class EditBookModel : BaseModel<int>
    {
        public string Title { get; init; }

        public string Description { get; init; }

        public DateTime? PublishDate { get; init; }

        public int[] Authors { get; init; }

        public string OriginalTitle { get; init; }

        public string OriginalDescription { get; init; }
    }
}
