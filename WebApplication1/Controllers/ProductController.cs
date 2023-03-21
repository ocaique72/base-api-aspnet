using desafio.Data;
using desafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetAllAsync(
            //fromServices pegando do dbContext/ database
            [FromServices] AppDbContext context)

        {
            //AsNoTracking nao verifica status dos obj ganhando performace
            var products = await context.Products.AsNoTracking().ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            //fromServices pegando do dbContext/ database
            [FromServices] AppDbContext context, [FromRoute]int id)

        {
            //AsNoTracking nao verifica status dos obj ganhando performace
            var product = await context.Products.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return product == null ? NotFound() : Ok(product);
           
        }

        [HttpPost("products")]
        public async Task<IActionResult> CreateAsync(
            [FromServices] AppDbContext context,
            [FromBody] Product product)
        {
            if(product == null)
            {
                return BadRequest();
            }
            await context.SaveChangesAsync();
            return Ok(product);
        }   
    }


}
