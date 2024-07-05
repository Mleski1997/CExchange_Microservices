using System.Threading;
using System.Threading.Tasks;
using CExchange.Services.Users.Application.Abstractions;
using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.Events;
using CExchange.Services.Users.Application.Exceptions;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace CExchange.Services.Users.Application.Commands.Handlers
{
    public sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly ILogger<SignUpHandler> _logger;

        public SignUpHandler(IUserRepository userRepository, IPasswordManager passwordManager, ILogger<SignUpHandler> logger)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
            _logger = logger;
        }

        public async Task HandleAsync(SignUp command, CancellationToken cancellationToken)
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
            if (user != null)
            {
                throw new EmailInUseException(command.Email);
            }

            var securedPassword = _passwordManager.Secure(command.Password);
            user = new User(command.Id, command.Email, command.Name, command.LastName, command.Role, securedPassword);
            await _userRepository.AddAsync(user);

            var userCreatedEvent = new SignedUp(user.Id, user.Email, user.Name, user.LastName);
            // await _messageBroker.PublishAsync(userCreatedEvent);

            _logger.LogInformation("SignedUp event sent to RabbitMQ for user {UserId}", user.Id);
        }
    }
}
