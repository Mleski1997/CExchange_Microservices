using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.PasswordSecurity
{
    public interface IPasswordManger
    {
        string Secure(string password);
        bool IsValid(string password, string securedPassword);
    }
}