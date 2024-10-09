namespace BookRepository.Data.Constraints
{
    public static class DatabaseConstants
    {
        public const int KeyMaxLength = 40;
        public static class Book
        {
            public const int TitleMaxLength = 30;

            public const int DescriptionMinLength = 10;

            public const int DescriptionMaxLength = 500;
        }

        public static class BookChange
        {
            public const int ChangeDesriptionMaxLength = 1000;
        }

        public static class Author
        {
            public const int NameMaxLength = 100;

            public const int BioMinLength = 10;

            public const int BioMaxLength = 1000;
        }

        public static class Errors
        {
            public const string BooksCannotBeSeeded = "Cannot seed books because no authors are available.";
        }

    }
}
