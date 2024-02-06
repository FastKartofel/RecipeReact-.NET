using RecipeBackend.DAL;
using System.ComponentModel.DataAnnotations;

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

    public virtual User User { get; set; }
}
