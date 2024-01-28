using System.ComponentModel.DataAnnotations;

namespace RecipeBackend.DTO
{
    public class UserDTO
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Password { get; set; }
    }
}
