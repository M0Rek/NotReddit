using Domain.DTOs;
using Domain.Models;

namespace BlazorWASM.Services.ClientInterfaces;

public interface ICommentService
{
    Task<Comment> CreateAsync(CommentCreationRequestDto dto);
    Task<IEnumerable<Comment>> GetByPostIdAsync(int id);
}