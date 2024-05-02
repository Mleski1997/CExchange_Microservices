using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Exceptions
{
    internal class InvalidCredentialsException : CustomException
    {
        public InvalidCredentialsException() : base("Invalid Email or Password")
        { }
        
    }
}
