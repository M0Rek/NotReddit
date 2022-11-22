namespace Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public User OriginalPoster { get; set; }
    public Post CommentedOn { get; set; }
    public string Content { get; set; }
    public DateTime PublishedDateTime { get; set; }
}