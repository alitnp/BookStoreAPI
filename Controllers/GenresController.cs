using AutoMapper;
using BookStore.Models;
using BookStore.Repository;
using BookStore.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("/api/Genres")]
    public class GenresController : Controller
    {
        private readonly IMapper _mapper;

        private readonly BookStoreDbContext _context;

        public GenresController(IMapper mapper, BookStoreDbContext context)
        {
            this._context = context;

            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] Genre genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return Ok(genre);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var genre = _context.Genres.ToList();
            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
                return NotFound();

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre([FromBody] GenreResource payload)
        {
            var genre = await _context.Genres.FindAsync(payload.Id);
            if (genre == null)
                return NotFound();
            genre.Name = payload.Name;
            await _context.SaveChangesAsync();
            genre = await _context.Genres.FindAsync(payload.Id);
            return Ok(genre);
        }
    }
}
