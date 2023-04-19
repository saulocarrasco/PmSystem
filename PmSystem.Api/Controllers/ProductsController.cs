using Microsoft.AspNetCore.Mvc;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;

namespace PmSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IService<Product> _productService;

        public ProductsController(IService<Product> productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productService.UpdateAsync(product);

            return NoContent();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);

            return NoContent();
        }
    }

}
