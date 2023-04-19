using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;

namespace PmSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService<CustomerItem> _reportService;
        public ReportController(IReportService<CustomerItem> reportService)
        {
            _reportService = reportService;
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var items = await _reportService.GetAsync(id);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }
    }
}
