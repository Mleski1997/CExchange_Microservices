using CExchange.Services.Users.Application.DTO;
using CExchange.Services.Users.Application.Queries;
using CExchange.Services.Users.Core.Entities;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;

namespace CExchange.Services.Users.Infrastructure.DAL.Handlers
{
    internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
    {
        private readonly UserDbContext _context;

        public GetUsersHandler(UserDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query, CancellationToken cancellationToken = default)
        {
            var users = await _context.Users.AsNoTracking().ToListAsync();

            return users.Select(user => MapToDto(user)).ToList();

        }

        private UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.UserId,
                Name = user.Name,
                LastName = user.LastName,
            };
        }
    }
}