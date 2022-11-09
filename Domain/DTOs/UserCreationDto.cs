using Domain.Enums;

namespace Domain.DTOs;

public class UserCreationDto
{
    public string Username { get; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }

    public UserCreationDto(string username, string email, string password, UserRole role)
    {
        Username = username;
        Email = email;
        Password = password;
        Role = role;
    }
}