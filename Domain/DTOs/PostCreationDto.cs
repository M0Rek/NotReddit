using Domain.Models;

namespace Domain.DTOs;

public class PostCreationDto
{
    public int OriginalPosterId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public PostCreationDto(int originalPosterId, string title, string content)
    {
        OriginalPosterId = originalPosterId;
        Title = title;
        Content = content;
    }
}