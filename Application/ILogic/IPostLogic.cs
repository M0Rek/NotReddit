using Domain.DTOs;
using Domain.Models;

namespace Application.ILogic;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post?> GetByIdAsync(int id);
}