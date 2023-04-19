using Microsoft.AspNetCore.Mvc;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;
using System.Runtime.CompilerServices;

namespace PmSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IService<Customer> _customerService;

        public CustomersController(IService<Customer> customerRepository)
        {
            _customerService = customerRepository;
        }

        // GET api/customers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAllAsync());
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _customerService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer product)
        {
            await _customerService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Customer product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _customerService.UpdateAsync(product);

            return NoContent();
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);

            return NoContent();
        }
    }

}
