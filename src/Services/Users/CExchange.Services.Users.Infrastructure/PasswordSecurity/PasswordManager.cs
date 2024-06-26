﻿using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace CExchange.Services.Users.Infrastructure.PasswordSecurity
{
    internal sealed class PasswordManager : IPasswordManager
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public PasswordManager(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public string Secure(string password) => _passwordHasher.HashPassword(default, password);

        public bool IsValid(string password, string securedPassword)
            => _passwordHasher.VerifyHashedPassword(default, securedPassword, password) ==
               PasswordVerificationResult.Success;
    }
}