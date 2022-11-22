using Application.IDAOs;
using Domain.Models;

namespace EfcDataAccess.DAOs;

public class CommentEfcDao : ICommentDao
{
    public Task<Comment> CreateAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Comment>> GetByPostIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}