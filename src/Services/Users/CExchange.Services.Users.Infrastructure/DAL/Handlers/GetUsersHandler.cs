using CExchange.Services.Users.Application.DTO;
using CExchange.Services.Users.Application.Queries;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CExchange.Services.Users.Infrastructure.DAL.Handlers
{
    internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
    {
        private readonly IMongoCollection<User> _users;

        public GetUsersHandler(IMongoDbContext context)
        {
            _users = context.Users;
        }
        public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query, CancellationToken cancellationToken = default)
        {
            var users = await _users.Find(_ => true).ToListAsync(cancellationToken);

            return users.Select(user => MapToDto(user)).ToList();

        }

        private UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
            };
        }
    }
}