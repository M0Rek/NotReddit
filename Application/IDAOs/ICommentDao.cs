using Domain.Models;

namespace Application.DaoInterfaces;

public interface ICommentDao
{
    Task<Comment> CreateAsync(Comment comment);
    Task<Comment?> GetByIdAsync(int id);

}