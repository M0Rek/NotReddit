using Domain.Models;

namespace Application.IDAOs;

public interface ICommentDao
{
    Task<Comment> CreateAsync(Comment comment);
    Task<IEnumerable<Comment>> GetByPostIdAsync(int id);

}