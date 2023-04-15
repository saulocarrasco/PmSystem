

namespace PmSystem.Domain.Entities
{
    public class Product : EntityModel
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
