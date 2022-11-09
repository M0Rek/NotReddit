namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public int OriginalPosterId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishedDateTime { get; set; }
    public List<int> UpVotedBy { get; set; } = new();
    public List<int> DownVotedBy { get; set; } = new();
    
    
}