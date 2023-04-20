using System.ComponentModel.DataAnnotations;

namespace PmSystem.FrontEnd.Data
{
    public class CustomerBaseViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone field is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }
    }
}
