using Application.IDAOs;
using Domain.Models;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    public Task<User> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}