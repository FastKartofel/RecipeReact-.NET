using System.ComponentModel.DataAnnotations;

namespace RecipeBackend.DTO
{
    public class LoginDTO
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
