using Azure.Messaging;
using desafio.Data;
using desafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace desafio.Controllers
{
    [ApiController]
    [Route("v1")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        //isso seria o FromServices
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<ActionResult> GetAllAsync()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("categories/{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [Route("categories")]
        public async Task<ActionResult> CreateAsync([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = category.Id }, category);
        }

        [HttpPut]
        [Route("categories/{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = category.Name;
            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete]
        [Route("categories/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound("Nao encontrado");
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Ok("deletado com sucesso");
        }
    }
}
