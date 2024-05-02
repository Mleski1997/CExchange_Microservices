using CExchange.Services.Users.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.PasswordSecurity
{
    public interface IAuthenticator 
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
