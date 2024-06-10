using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.Exceptions
{
    public class InvalidCredentialsException : CustomException
    {
        public override string Code { get; } = "invalid_credentials";
        public string Email { get; }

        public InvalidCredentialsException(string email) : base("Invalid credentials.")
        {
            Email = email;
        }
    }
}