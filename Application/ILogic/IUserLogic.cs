using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
}
