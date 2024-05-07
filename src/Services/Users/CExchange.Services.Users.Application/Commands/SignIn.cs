using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Convey.CQRS.Commands;

namespace CExchange.Services.Users.Application.Commands
{
    public record SignIn(string email, string password) : ICommand;

}
