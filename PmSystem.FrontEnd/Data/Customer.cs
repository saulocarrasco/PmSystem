namespace PmSystem.FrontEnd.Data
{
    public class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
