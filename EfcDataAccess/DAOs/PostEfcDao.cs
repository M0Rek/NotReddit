using Application.IDAOs;
using Domain.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    public Task<Post> CreateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}