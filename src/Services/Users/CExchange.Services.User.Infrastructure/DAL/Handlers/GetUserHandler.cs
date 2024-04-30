using CExchange.Services.Users.Application.DTO;
using CExchange.Services.Users.Application.Queries;
using CExchange.Services.Users.Core.Entities;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.DAL.Handlers
{
    internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDetailsDto>
    {
        private readonly UserDbContext _context;

        public GetUserHandler(UserDbContext context)
        {
            _context = context;
        }
        public async Task<UserDetailsDto> HandleAsync(GetUser query, CancellationToken cancellationToken = default)
        {

            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == query.UserId, cancellationToken);
            return MapToDto(user);
        }

        private UserDetailsDto MapToDto(User user)
        {
            return new UserDetailsDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
            };
        }
    }
}