using System.ComponentModel.DataAnnotations;

namespace PmSystem.FrontEnd.Data
{
    public class CustomerItemViewModel 
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value Must Bigger Than {1}")]
        public int ProductId { get; set; }
        public ProductBaseViewModel Product { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value Must Bigger Than {1}")]
        public int Quantity { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value Must Bigger Than {1}")]
        public int CustomerId { get; set; }
        public CustomerBaseViewModel Customer { get; set; }
    }
}
