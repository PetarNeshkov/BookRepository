namespace BookRepository.Services.Common
{
    public static class GlobalConstants
    {
        public const string SuccessfulCreationMessage = "The {0} was successfully created.";
        public const string SuccessfulEditMessage = "The {0} was successfully edited.";
        public const string SuccessfulDeleteMessage = "The {0} was successfully deleted.";
        public const string ModelsRegexPatternTemplate = @"^{0}\..+Models,";
        public const string AscendingConstant = "asc";
        public const string DescendingConstant = "desc";
        public const int DefaultPage = 1;
        public const int DefaultItemsPerPage = 10;

        public static class ErrorMessages
        {
            public const string IdModelIdValidationMessage = "The provided id for the entity is invalid.";
            public const string EntityDoesNotExistMessage = "Entity does not exist.";


            public static class Authors
            {
                public const string ExistsMessage = "Author already exists.";
                public const string NameIsRequiredMessage = "Author name is required.";
                public const string NameMaxLengthMessage = "Author name cannot exceed {0} characters.";
                public const string BioIsRequiredMessage = "Author bio is required.";
                public const string BioMinLengthMessage = "Author bio must be at least {0} characters.";
                public const string BioMaxLengthMessage = "Author bio cannot exceed {0} characters.";
                public const string NotFoundMessage = "Author not found.";
            }

            public static class Books
            {
                public const string ExistsMessage = "Book already exists";
                public const string TitleIsRequiredMessage = "Book title is required.";
                public const string TitleMaxLengthMessage = "Book title cannot exceed {0} characters.";
                public const string DescriptionIsRequired = "Book description is required.";
                public const string DescriptionMinLengthMessage = "Book description must be atleast {0} characters.";
                public const string DescriptionMaxLengthMessage = "Book description cannot exceed {0} characters.";
                public const string AuthorIsRequiredMessage = "At least one author is required.";
                public const string AuthorsMaxCountMessage = "There could be only {0} per book.";
            }
        }
    }
}
