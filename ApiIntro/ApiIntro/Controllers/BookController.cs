using ApiIntro.Data;
using ApiIntro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiIntro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null) return NotFound();

            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? keyword)
        {
            return Ok(keyword is null ? await _context.Books.ToListAsync() : await _context.Books.Where(m => m.Title.Contains(keyword)).ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null) return NotFound();

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] Book book, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _context.Books.FindAsync(id);

            if (data is null) return NotFound();

            data.Title = book.Title;
            data.Author = book.Author;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
