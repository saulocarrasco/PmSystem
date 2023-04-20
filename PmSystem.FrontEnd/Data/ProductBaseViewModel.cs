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
        [Range(1, int.MaxValue, ErrorMessage = "Value Must Bigger Than {1}")]
        public decimal Price { get; set; }
    }
}
