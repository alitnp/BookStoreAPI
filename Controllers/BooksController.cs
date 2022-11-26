using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Models;
using BookStore.Repository;
using BookStore.Resources;
using Microsoft.AspNetCore.Mvc;

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
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }
    }
}
