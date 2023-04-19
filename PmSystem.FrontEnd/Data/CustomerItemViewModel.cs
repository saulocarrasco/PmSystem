namespace PmSystem.FrontEnd.Data
{
    public class CustomerItemViewModel 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductBaseViewModel Product { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public CustomerBaseViewModel Customer { get; set; }
    }
}
