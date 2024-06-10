using CExchange.Services.Users.Application.Events;
using CExchange.Services.Users.Application.Exceptions;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Application.Services;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Microsoft.Extensions.Logging;

namespace CExchange.Services.Users.Application.Commands.Handlers
{
    public sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManger;
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<SignUpHandler> _logger;

        public SignUpHandler(IUserRepository userRepository, IPasswordManager passwordManger, IMessageBroker messageBroker, ILogger<SignUpHandler> logger)
        {
            _userRepository = userRepository;
            _passwordManger = passwordManger;
            _messageBroker = messageBroker;
            _logger = logger;
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
                throw new EmailInUseException(command.Email);
            }

            var securedPassword = _passwordManger.Secure(command.Password);
            user = new User(command.UserId, command.Email, command.Name, command.LastName, command.Role, securedPassword);
            await _userRepository.AddAsync(user);
            await _messageBroker.PublishAsync(new SingedUp(user.UserId, user.Email, user.Role));

          

        }
    }
}
