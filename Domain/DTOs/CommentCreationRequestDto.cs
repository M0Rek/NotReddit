namespace Domain.DTOs;

public class CommentCreationRequestDto
{
    public int CommentedOnId { get; set; }
    public string Content { get; set; }
}