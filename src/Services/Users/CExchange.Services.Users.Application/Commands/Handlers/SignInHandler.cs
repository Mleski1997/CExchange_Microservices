﻿using CExchange.Services.Users.Application.Abstractions;
using CExchange.Services.Users.Application.Exceptions;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Commands.Handlers
{
    public sealed class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticator _authenticator;
        private readonly IPasswordManager _passwordManager;
        private readonly ITokenStorage _tokenStorage;

        public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator, IPasswordManager passwordManager,
            ITokenStorage tokenStorage)
        {
            _userRepository = userRepository;
            _authenticator = authenticator;
            _passwordManager = passwordManager;
            _tokenStorage = tokenStorage;
        }

        public async Task HandleAsync(SignIn command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);
            if (user is null)
            {
                throw new EmailInUseException(command.Email);
            }

            if (!_passwordManager.IsValid(command.Password, user.Password))
            {
                throw new MissingPasswordException();
            }

            var jwt = _authenticator.CreateToken(user.Id, user.Role);
            _tokenStorage.Set(jwt);
        }
    }
}
