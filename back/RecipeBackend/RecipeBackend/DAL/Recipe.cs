using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBackend.DAL
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(4000)]
        public string Description { get; set; }

        [Required]
        [StringLength(4000)]
        public string Instructions { get; set; }

        [Required]
        public int PreparationTime { get; set; } // in minutes


        [Required]
        public DateTime DatePosted { get; set; }

        
        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

}
