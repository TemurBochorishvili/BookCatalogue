using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookCatalogue.Controllers.Resources;
using BookCatalogue.Models;
using BookCatalogue.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogue.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CatalogueController : ControllerBase
    {
        private readonly CatalogueDbContext context;

        private readonly IMapper mapper;

        public CatalogueController(CatalogueDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<BookResource>> Get()
        {
            var books = await context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .ToListAsync();

            return mapper.Map<List<Book>, List<BookResource>>(books);
        }

        [HttpGet("{id}")]
        public async Task<BookResource> GetById(int id)
        {
            var books = await context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .SingleOrDefaultAsync(next => next.Id == id);

            return mapper.Map<Book, BookResource>(books);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookResource bookResource)
        {
            if(!context.Books.Any(b => (b.Category.Id == bookResource.Category.Id) && (b.Author.Id == bookResource.Author.Id)))
            {
                return BadRequest();
            }

            var book = mapper.Map<BookResource, Book>(bookResource);

            await context.Books.AddAsync(book);

            await context.SaveChangesAsync();

            return Ok(book);
        }

        [HttpPost("[action]/{id}/{title}")]
        public async Task<ActionResult> EditTitle(int id, string title)
        {

            var book = await context.Books.FirstOrDefaultAsync(next => next.Id == id);

            if (book == default)
            {
                return BadRequest();
            }

            book.Title = title;
            
            context.Books.Update(book);

            await context.SaveChangesAsync();

            return Ok(book);
        }

        [HttpPost("[action]/{id}/{name}")]
        public async Task<ActionResult> EditAuthor(int id, string name)
        {

            var author = await context.Authors.FirstOrDefaultAsync(next => next.Id == id);

            if (author == default)
            {
                return BadRequest();
            }

            author.Name = name;
            
            context.Authors.Update(author);

            await context.SaveChangesAsync();

            return Ok(author);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Delete(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(next => next.Id == id);

            if (book == default)
            {
                return BadRequest();
            }

            context.Books.Remove(book);

            await context.SaveChangesAsync();

            return Ok(book);
        }
    }
}
