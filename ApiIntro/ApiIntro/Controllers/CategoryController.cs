using ApiIntro.Data;
using ApiIntro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiIntro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if(category is null) return NotFound();

            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? keyword)
        {
            return Ok(keyword is null ? await _context.Categories.ToListAsync() : await _context.Categories.Where(m => m.Name.Contains(keyword)).ToListAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();

            var category = await _context.Categories.FindAsync(id);

            if(category is null) return NotFound();

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Create", category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] Category category, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _context.Categories.FindAsync(id);

            if (data is null) return NotFound();

            data.Name = category.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
