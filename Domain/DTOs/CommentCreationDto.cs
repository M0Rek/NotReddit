using Domain.Models;

namespace Domain.DTOs;

public class CommentCreationDto
{
    public User OriginalPoster { get; set; }
    public int CommentedOnId { get; set; }
    public string Content { get; set; }


    public CommentCreationDto(User originalPoster, int commentedOnId, string content)
    {
        OriginalPoster = originalPoster;
        CommentedOnId = commentedOnId;
        Content = content;
    }
}