using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.Exceptions
{
    internal class InvalidEmailExcpetion : CustomException
    {
        public string Email { get; set; }
        public InvalidEmailExcpetion(string email) : base($"Email: `{email}` is invalid")
        {
            Email = email;
        }
    }

}
