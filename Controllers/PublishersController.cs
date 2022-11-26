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
    [Route("/api/Publishers")]
    public class PublishersController : Controller
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public PublishersController(BookStoreDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisher(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
                return NotFound();

            return Ok(publisher);
        }

        [HttpGet]
        public IActionResult GetAllPublishers()
        {
            var publishers = _context.Publishers.ToList();
            if (publishers == null)
                return NotFound();

            return Ok(publishers);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher(
            [FromBody] SavePublisherResource publisherResource
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var publisher = _mapper.Map<SavePublisherResource, Publisher>(publisherResource);

            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return Ok(publisher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
                return NotFound();

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePublisher(
            [FromBody] SavePublisherResource publisherResource
        )
        {
            var publisher = await _context.Publishers.FindAsync(publisherResource.Id);
            if (publisher == null)
                return NotFound();

            _mapper.Map<SavePublisherResource, Publisher>(publisherResource, publisher);

            await _context.SaveChangesAsync();

            publisher = await _context.Publishers.FindAsync(publisherResource.Id);
            return Ok(publisher);
        }
    }
}
