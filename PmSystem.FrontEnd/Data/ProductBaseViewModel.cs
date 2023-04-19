using System.ComponentModel.DataAnnotations;

namespace PmSystem.FrontEnd.Data
{
    public class ProductBaseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
