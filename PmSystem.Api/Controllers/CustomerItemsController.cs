using Microsoft.AspNetCore.Mvc;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Dtos;
using PmSystem.Domain.Entities;

namespace PmSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerItemsController : ControllerBase
    {
        private readonly IService<CustomerItem> _customerItemService;

        public CustomerItemsController(IService<CustomerItem> customerItemService)
        {
            _customerItemService = customerItemService;
        }

        // GET api/customerItems
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerItemService.GetAllAsync());
        }

        // GET api/customerItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _customerItemService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/customerItems
        [HttpPost]
        public async Task<ActionResult<CustomerItem>> Post(CustomerItemDto customerDto)
        {
            var customerItem = new CustomerItem
            {
                Quantity = customerDto.Quantity,
                CustomerId = customerDto.CustomerId,
                ProductId = customerDto.ProductId
            };

            await _customerItemService.AddAsync(customerItem);
            return CreatedAtAction(nameof(GetById), new { id = customerItem.Id }, customerItem);
        }

        // PUT api/customerItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CustomerItemDto customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest();
            }

            var customerItem = new CustomerItem
            {
                Id = customerDto.Id,
                Quantity = customerDto.Quantity,
                CustomerId = customerDto.CustomerId,
                ProductId = customerDto.ProductId
            };
            await _customerItemService.UpdateAsync(customerItem);

            return NoContent();
        }

        // DELETE api/customerItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerItemService.DeleteAsync(id);

            return NoContent();
        }
    }

}
