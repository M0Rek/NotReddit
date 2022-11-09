using Domain;
using Application.DaoInterfaces;
using Domain.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
        private readonly FileContext context;

        public UserFileDao(FileContext context)
        {
                this.context = context;
        }

        public Task<User> CreateAsync(User user)
        {
                int userId = 1;
                if (context.Users.Any())
                {
                        userId = context.Users.Max(u => u.Id);
                        userId++;
                }

                user.Id = userId;
                
                context.Users.Add(user);
                context.SaveChanges();
                return Task.FromResult(user);
        }

        public Task<User?> GetByUsernameAsync(string userName)
        {
                User? existing =
                        context.Users.FirstOrDefault(u =>
                                userName.Equals(u.Username, StringComparison.OrdinalIgnoreCase));
                return Task.FromResult<User?>(existing);
        }

        public Task<User?> GetByIdAsync(int id)
        {
                User? existing = context.Users.FirstOrDefault(u => id == u.Id);

                return Task.FromResult(existing);
        }
}