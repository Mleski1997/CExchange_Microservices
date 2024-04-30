using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Exceptions
{
    public class InvalidEmailException : CustomException
    {
        public string Email { get; set; }
        public InvalidEmailException(string email) : base($"Email {email} is invalid")

        {
            Email = email;
        }
    }
}