
namespace Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }

    public User()
    {
    }
}