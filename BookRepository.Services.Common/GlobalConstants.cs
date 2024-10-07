namespace BookRepository.Services.Common
{
    public static class GlobalConstants
    {
        public const string SuccessfulCreationMessage = "The {0} was successfully created.";
        public static class ErrorMessages
        {
            public const string IdModelIdValidationMessage = "The provided id for the entity is invalid.";
            public const string EntityDoesNotExistMessage = "Entity does not exist.";


            public static class Authors
            {
                public const string AuthorNameIsRequredMessage = "Author name is required.";
                public const string AuthorNameMaxLengthMessage = "Author name cannot exceed {0} characters.";
                public const string AuthorExistsMessage = "Author already exists.";
                public const string AuthorBioIsRequredMessage = "Author bio is required.";
                public const string AuthorBioMinLengthMessage = "Author bio must be at least {0} characters.";
                public const string AuthorBioMaxLengthMessage = "Author bio cannot exceed 1000 characters.";
            }
        }
    }
}
