namespace Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public User OriginalPoster { get; set; }
    public int CommentedOnId { get; set; }
    public string Content { get; set; }
    public DateTime PublishedDateTime { get; set; }
    public List<int> UpVotedBy { get; set; } = new();
    public List<int> DownVotedBy { get; set; } = new();
}