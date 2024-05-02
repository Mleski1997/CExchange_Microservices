using CExchange.Services.Users.Application.Exceptions;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using CExchange.Services.Users.Core.ValueObjects;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Command.Handlers
{
    internal sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        
        private readonly IPasswordManger _passwordManger;
     

        public SignUpHandler(IUserRepository userRepository,IPasswordManger passwordManger)
        {
            _userRepository = userRepository;        
            _passwordManger = passwordManger;
        }
        public async Task HandleAsync(SignUp command, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user is not null)
            {
                throw new EmailInUseException();
            }
            var role = string.IsNullOrWhiteSpace(command.Role) ? Role.User() : new Role(command.Role);
          
            if (role is null)
            {
                throw new RoleNotFoundException();
            }

            var password = _passwordManger.Secure(command.Password);
            user = new User
            {
                Id = command.UserId,
                Email = command.Email,
                Name = command.Name,
                LastName = command.LastName,
                Role = role,
                Password = password,

            };

            await _userRepository.AddAsync(user);
        }
    }
}