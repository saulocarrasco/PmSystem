using PmSystem.Domain.Entities;


namespace PmSystem.Domain.Dtos
{
    public class CustomerItemDto : EntityModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
    }
}
