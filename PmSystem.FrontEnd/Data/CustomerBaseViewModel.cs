using System.ComponentModel.DataAnnotations;

namespace PmSystem.FrontEnd.Data
{
    public class CustomerBaseViewModel
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
