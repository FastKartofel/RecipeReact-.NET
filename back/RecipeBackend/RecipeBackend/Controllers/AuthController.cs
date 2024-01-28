using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBackend.DAL;
using RecipeBackend.Services.Interfaces;
using RecipeBackend.DTO;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly MainDbContext _mainDbContext;

    public AuthController(IAuthService authService, MainDbContext mainDbContext)
    {
        _authService = authService;
        _mainDbContext = mainDbContext;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDTO userDto)
    {
        // Assuming UserDto has Username, Email, and Password

        // Check if the user already exists
        if (await _mainDbContext.Users.AnyAsync(x => x.Username == userDto.Username))
        {
            return BadRequest("Username is already taken");
        }

        var user = new User
        {
            Username = userDto.Username,
            Email = userDto.Email
            // Don't set the password hash here
        };

        var createdUser = await _authService.Register(user, userDto.Password);

        // Don't send the password hash back
        createdUser.PasswordHash = null;

        return StatusCode(201, createdUser);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDto)
    {
        // Assuming LoginDto has Username and Password
        var token = await _authService.Login(loginDto.Username, loginDto.Password);

        if (token == null)
            return Unauthorized("Username or password is incorrect");

        return Ok(new { token });
    }


    // Other endpoints as necessary
}
