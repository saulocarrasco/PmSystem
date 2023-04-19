using Microsoft.AspNetCore.Mvc;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;

namespace PmSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IService<Customer> _customerService;

        public CustomersController(IService<Customer> customerService)
        {
            _customerService = customerService;
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
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            await _customerService.AddAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            await _customerService.UpdateAsync(customer);

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
