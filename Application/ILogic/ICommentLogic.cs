using Domain.DTOs;
using Domain.Models;

namespace Application.ILogic;

public interface ICommentLogic
{
    Task<Comment> CreateAsync(CommentCreationDto dto);
    Task<IEnumerable<Comment>> GetByPostIdAsync(int id);

}