using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBackend.DAL;
using RecipeBackend.Services.Interfaces;
using RecipeBackend.DTO;

[ApiController]
[Route("api/auth")]
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
        if (await _mainDbContext.Users.AnyAsync(x => x.Username == userDto.Username))
        {
            return BadRequest("Username is already taken");
        }

        var user = new User
        {
            Username = userDto.Username,
            Email = userDto.Email
        };

        var createdUser = await _authService.Register(user, userDto.Password);

        var userResponse = new UserResponseDTO
        {
            UserId = createdUser.UserId,
            Username = createdUser.Username,
            Email = createdUser.Email
        };

        return StatusCode(201, userResponse);
    }



    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDto)
    {
        var token = await _authService.Login(loginDto.Username, loginDto.Password);

        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized("Invalid username or password");
        }

        return Ok(new { token });
    }

}
