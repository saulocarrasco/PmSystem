

namespace PmSystem.Domain.Entities
{
    public class CustomerItem : EntityModel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
