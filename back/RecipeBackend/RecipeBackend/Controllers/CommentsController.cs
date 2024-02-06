using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBackend.DAL;
using RecipeBackend.DTO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

//ther are still work to do in this project, i have commented the Authorize for nowbecuase can't async get the comments from the database otherwise
//[Authorize]
[ApiController]
[Route("api/comments")]
public class CommentsController : ControllerBase
{
    private readonly MainDbContext _context;

    public CommentsController(MainDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostComment([FromBody] CommentDTO commentDto)
    {
        try
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                return BadRequest("Invalid user ID");
            }
            //something wrong with posting the comment stil don't know waht wrong


            var comment = new Comment
            {
                Content = commentDto.Content,
                UserId = 1,
                DatePosted = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Comment added successfully" });
        }
        catch (Exception ex)
        {
            // Log the detailed error
            // Consider using a logging framework or tool
            return BadRequest(new { error = $"Failed to post comment: {ex.Message}" });
        }
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        var comments = await _context.Comments
            .Include(c => c.User)
            .Select(c => new
            {
                c.CommentId,
                c.Content,
                c.DatePosted,
                User = new { c.User.UserId, c.User.Username }
            })
            .ToListAsync();

        return Ok(comments);
    }
}
