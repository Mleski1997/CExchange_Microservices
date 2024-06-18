using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;


namespace CExchange.Services.Users.Infrastructure.DAL.MongoDB.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDbContext context)
        {
            _users = context.Users;
        }

        public async Task AddAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }

        public async Task<User> GetBydIdAsync(Guid id)
        {
            var result = await _users.FindAsync(user => user.Id == id);
            return await result.SingleOrDefaultAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq("Email", email);
            return await _users.Find(filter).FirstOrDefaultAsync();
        }

        
    }
}