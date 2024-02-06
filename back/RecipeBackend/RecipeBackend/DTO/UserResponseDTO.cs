namespace RecipeBackend.DTO
{
    public class UserResponseDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        // Add any other user properties that you want to return to the client
        // Avoid including sensitive data like passwords or password hashes
    }

}
