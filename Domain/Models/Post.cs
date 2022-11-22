namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User OriginalPoster { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishedDateTime { get; set; }
    
    
}