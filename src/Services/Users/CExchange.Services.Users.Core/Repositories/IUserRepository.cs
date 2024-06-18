using CExchange.Services.Users.Core.Entities;

namespace CExchange.Services.Users.Core.Repositories
{
    public interface IUserRepository
     {
        Task<User> GetBydIdAsync(Guid id);
        Task<User> GetByEmailAsync(string Email);
        Task AddAsync(User user);
     }
}
