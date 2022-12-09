using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStore.Models;
using BookStore.Repository;
using BookStore.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("/api/Books")]
    public class BooksController : Controller
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;

        public BooksController(BookStoreDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] SaveBookResource saveBookResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = _mapper.Map<SaveBookResource, Book>(saveBookResource);
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Genre)
                .SingleOrDefaultAsync(v => v.Id == id);
            if (book == null)
                return NotFound();
            var bookResourced = _mapper.Map<Book, BookResource>(book);
            // var book = await _context.Books
            //     .ProjectTo<BookResource>(_mapper.ConfigurationProvider)
            //     .FirstOrDefaultAsync(x => x.Id == id);
            // var book = await _context.Books
            //     .Include(x => x.Genre)
            //     .Include(x => x.Publisher)
            //     .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(bookResourced);
        }
    }
}
