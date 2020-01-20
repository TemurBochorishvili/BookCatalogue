using BookCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogue.Persistence
{
    public class CatalogueDbContext : DbContext
    {
        public CatalogueDbContext(DbContextOptions<CatalogueDbContext> options)
            :base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        
        public DbSet<Author> Authors { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }
    }
}