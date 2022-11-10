using Domain.Models;

namespace Domain.DTOs;

public class PostCreationDto
{
    public User OriginalPoster { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public PostCreationDto()
    {
    }

    public PostCreationDto(User originalPoster, string title, string content)
    {
        OriginalPoster = originalPoster;
        Title = title;
        Content = content;
    }
}