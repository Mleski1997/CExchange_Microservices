using CExchange.Services.Users.Application.PasswordSecurity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.PasswordSecurity
{
    internal sealed class PasswordManager : IPasswordManger
    {
        public PasswordManager(IPasswordHasher<User> passwordHasher)
        {
            
        }
        public string Secure(string password) { }
        
        public bool Validate(string password) { }
        
    }
}
