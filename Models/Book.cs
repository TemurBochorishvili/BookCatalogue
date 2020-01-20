using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalogue.Models
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }

        public Author Author { get; set; }

        public int AuthorId { get; set; }
        
        public BookCategory Category { get; set; }
        
        public int CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

    }
}