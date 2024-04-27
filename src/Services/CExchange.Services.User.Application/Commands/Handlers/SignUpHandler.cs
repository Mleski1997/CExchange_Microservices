using CExchange.Services.Users.Core.Entities;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Commands.Handlers
{
    internal sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        public async Task HandleAsync(SignUp command, CancellationToken cancellationToken = default)
        {

            var user = new User (command.Id, command.Email, command.Name, command.LastName, command.Password);
        }
    }
}
