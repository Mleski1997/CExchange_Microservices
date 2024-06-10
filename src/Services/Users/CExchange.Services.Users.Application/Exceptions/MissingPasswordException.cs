using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Exceptions
{
    public class MissingPasswordException : AppException
    {
       
        public MissingPasswordException() : base("Invalid Password")
        {
        }
    }
}
