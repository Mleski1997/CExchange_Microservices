using CExchange.Services.Users.Application.Exceptions;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Command.Handlers
{
    internal sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManger _passwordManger;

        public SignUpHandler(IUserRepository userRepository, IPasswordManger passwordManger)
        {
            _userRepository = userRepository;
            _passwordManger = passwordManger;
        }
        public async Task HandleAsync(SignUp command, CancellationToken cancellationToken = default)
        {

            if (string.IsNullOrWhiteSpace(command.Email))
            {
                throw new InvalidEmailException(command.Email);
            }

            if (string.IsNullOrWhiteSpace(command.Password))
            {
                throw new MissingPasswordException();
            }
            var user = await _userRepository.GetByEmailAsync(command.Email);
            if (user is not null)
            {
                throw new EmailInUseException();
            }

            var password = _passwordManger.Secure(command.Password);
            user = new User
            {
                Id = command.UserId,
                Email = command.Email,
                Name = command.Name,
                LastName = command.LastName,
                Password = password,

            };

            await _userRepository.AddAsync(user);
        }
    }
}