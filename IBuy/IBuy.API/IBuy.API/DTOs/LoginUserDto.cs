// DTOs/LoginUserDto.cs
namespace IBuy.API.DTOs
{
    public class LoginUserDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public LoginUserDto() { }
    }
}
