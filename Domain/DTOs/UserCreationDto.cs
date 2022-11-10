namespace Domain.DTOs;

public class UserCreationDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserCreationDto()
    {
    }

    public UserCreationDto(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}