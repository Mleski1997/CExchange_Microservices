using CExchange.Services.Users.Application.Exceptions;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Repositories;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CExchange.Services.Users.Application.Command.Handlers
{
    internal sealed class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticator _authenticator;
        private readonly IPasswordManger _passwordManger;
        private readonly ITokenStorage _tokenStorage;

        public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator, IPasswordManger passwordManger,ITokenStorage tokenStorage )
        {
            _userRepository = userRepository;
            _authenticator = authenticator;
            _passwordManger = passwordManger;
            _tokenStorage = tokenStorage;
        }
        public async Task HandleAsync(SignIn command, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetByEmailAsync( command.Email);
            if (user is null)
            {
                throw new InvalidCredentialsException();
            }
            if (!_passwordManger.IsValid(command.Password, user.Password))
            {
                throw new InvalidCredentialsException();
            }
            var jwt = _authenticator.CreateToken(user.Id, user.Role);
            _tokenStorage.Set(jwt);


        }
    }
}
