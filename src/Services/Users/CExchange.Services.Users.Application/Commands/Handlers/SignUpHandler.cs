using CExchange.Services.Users.Application.Events;
using CExchange.Services.Users.Application.Exceptions;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Application.Services;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using CExchange.Services.Users.Core.ValueObjects;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Commands.Handlers
{
    public sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManger;
        private readonly IMessageBroker _messageBroker;

        public SignUpHandler(IUserRepository userRepository, IPasswordManager passwordManger, IMessageBroker messageBroker)
        {
            _userRepository = userRepository;
            _passwordManger = passwordManger;
            _messageBroker = messageBroker;
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

            await _messageBroker.PublishAsync(new SignedUp(user.UserId, user.Email, user.Name, user.LastName, user.Role));


        }
    }
}
