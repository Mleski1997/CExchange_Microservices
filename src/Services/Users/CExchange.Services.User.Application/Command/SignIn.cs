using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CExchange.Services.Users.Application.Command
{
    public record SignIn(string Email, string Password) : ICommand;
    
    
}
