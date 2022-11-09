using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public interface ICommentLogic
{
    Task<Comment> CreateAsync(CommentCreationDto dto);
    Task<Post?> GetByIdAsync(int id);

}