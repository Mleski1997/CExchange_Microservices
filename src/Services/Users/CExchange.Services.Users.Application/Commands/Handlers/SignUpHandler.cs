using CExchange.Services.Users.Application.Events;
using CExchange.Services.Users.Application.Exceptions;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Commands.Handlers
{
    internal sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManger;
        private readonly IEventDispatcher _eventDispatcher;

        public SignUpHandler(IUserRepository userRepository, IPasswordManager passwordManger, IEventDispatcher eventDispatcher)
        {
            _userRepository = userRepository;
            _passwordManger = passwordManger;
            _eventDispatcher = eventDispatcher;
        }
        public async Task HandleAsync(SignUp command, CancellationToken cancellationToken = default)
        {

            if(string.IsNullOrWhiteSpace(command.Email))
            {
                throw new InvalidEmailException(command.Email);
            } 

            if(string.IsNullOrWhiteSpace(command.Password))
            {
                throw new MissingPasswordException();
            }
            var user = await _userRepository.GetByEmailAsync(command.Email);
            if(user is not null)
            {
                throw new EmailInUseException();
            }

            var securedPassword = _passwordManger.Secure(command.Password);
            user = new User(command.UserId, command.Email, command.Name, command.LastName, command.Role, securedPassword);

            await _userRepository.AddAsync(user);

            var signedUpEvent = new SignedUp(user.UserId, user.Email, user.Name, user.LastName, user.Role);
            await _eventDispatcher.PublishAsync(signedUpEvent);
        }
    }
}
