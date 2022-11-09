using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post?> GetByIdAsync(int id);
}