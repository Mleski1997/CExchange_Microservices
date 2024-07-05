// Application/Queries/GetUserHandler.cs
using CExchange.Services.Users.Application.Abstractions;
using CExchange.Services.Users.Application.DTO;
using CExchange.Services.Users.Application.Queries;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.DAL.Handlers
{
    public sealed class GetUserHandler : IQueryHandler<GetUser, UserDetailsDto>
    {
        private readonly IMongoCollection<User> _users;

        public GetUserHandler(IMongoDbContext context)
        {
            _users = context.Users;
        }

        public async Task<UserDetailsDto> HandleAsync(GetUser query, CancellationToken cancellationToken = default)
        {
            var user = await _users.Find(x => x.Id == query.UserId).SingleOrDefaultAsync(cancellationToken);
            return user == null ? null : MapToDto(user);
        }

        private UserDetailsDto MapToDto(User user)
        {
            return new UserDetailsDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                Role = user.Role
            };
        }
    }
}
