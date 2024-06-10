using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.Exceptions
{
    public class InvalidEmailExcpetion : CustomException
    {
        public string Code { get; } = "email_in_use";
        public string Email { get; set; }
        public InvalidEmailExcpetion(string email) : base($"Email: `{email}` is invalid")
        {
            Email = email;
        }
    }

}
