namespace PmSystem.FrontEnd.Data
{
    public class CustomerItemListViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductBaseViewModel Product { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public CustomerBaseViewModel Customer { get; set; }
        public string CustomerName
        {
            get
            {
                return Customer?.Name;
            }
        }
        public string ProductName
        {
            get
            {
                return Product?.Description;
            }
        }

        public string ProductPrice
        {
            get
            {
                return Product?.Price.ToString("C2");
            }
        }
    }
}
