using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBackend.DAL
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        public virtual User User { get; set; }
        public virtual Recipe Recipe { get; set; }
    }

}
