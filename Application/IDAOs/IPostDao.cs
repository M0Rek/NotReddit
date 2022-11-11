using Domain.Models;

namespace Application.IDAOs;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post?> GetByIdAsync(int id);


}