namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User OriginalPoster { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishedDateTime { get; set; }

    public Post(User originalPoster, string title, string content)
    {
        OriginalPoster = originalPoster;
        Title = title;
        Content = content;
    }

    public Post()
    {
    }
}