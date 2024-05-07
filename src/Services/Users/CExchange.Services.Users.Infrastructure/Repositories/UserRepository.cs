using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using CExchange.Services.Users.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;


namespace CExchange.Services.Users.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
        }

        public Task<User> GetBydIdAsync(Guid UserId) => _context.Users.SingleOrDefaultAsync(x => x.UserId == UserId);
      

        public Task<User> GetByEmailAsync(string Email) => _context.Users.SingleOrDefaultAsync(x => x.Email == Email);
       
    }
}
