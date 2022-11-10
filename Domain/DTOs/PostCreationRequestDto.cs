namespace Domain.DTOs;

public class PostCreationRequestDto
{
    public string Title { get; set; }
    public string Content { get; set; }

    public PostCreationRequestDto()
    {
    }

    public PostCreationRequestDto(string title, string content)
    {
        Title = title;
        Content = content;
    }
}