using System.ComponentModel.DataAnnotations;

namespace RecipeBackend.DAL
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        // Navigation property for relationships
        public virtual ICollection<Comment> Comments { get; set; }

    }

}
