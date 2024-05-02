using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Exceptions
{
    internal class RoleNotFoundException : CustomException
    {
        public RoleNotFoundException() : base("Role not found")
        {
        }
    }
}
