namespace BookCatalogue.Controllers.Resources
{
    public class BookResource
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public AuthorResource Author { get; set; }

        public BookCategoryResource Category { get; set; }
    }
}
