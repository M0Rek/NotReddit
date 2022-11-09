namespace Domain.DTOs;

public class CommentCreationDto
{
    public int OriginalPosterId { get; set; }
    public int CommentedOnId { get; set; }
    public bool IsParentPost { get; set; }
    public string Content { get; set; }

    public CommentCreationDto(int originalPosterId, int commentedOnId, bool isParentPost, string content)
    {
        OriginalPosterId = originalPosterId;
        CommentedOnId = commentedOnId;
        IsParentPost = isParentPost;
        Content = content;
    }
}