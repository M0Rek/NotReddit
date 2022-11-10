using Domain.DTOs;
using Domain.Models;

namespace BlazorWASM.Services.ClientInterfaces;

public interface IPostService
{
    Task<Post> CreateAsync(PostCreationRequestDto dto);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post?> GetByIdAsync(int id);
}