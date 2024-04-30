using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace CExchange.Services.Users.Infrastructure.PasswordSecurity
{
    internal sealed class PasswordManager : IPasswordManger
    {
        private readonly IPasswordHasher<object> _passwordHasher;

        public PasswordManager(IPasswordHasher<object> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public string Secure(string password) => _passwordHasher.HashPassword(new object(), password);

        public bool IsValid(string password, string securedPassword)
            => _passwordHasher.VerifyHashedPassword(new object(), securedPassword, password) ==
               PasswordVerificationResult.Success;
    }
}