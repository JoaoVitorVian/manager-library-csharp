using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}