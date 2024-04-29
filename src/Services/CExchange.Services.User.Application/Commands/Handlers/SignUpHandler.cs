using CExchange.Services.Users.Application.PasswordSecurity;
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
        private readonly IPasswordManger _passwordManger;

        public SignUpHandler(IPasswordManger passwordManger)
        {
            _passwordManger = passwordManger;
        }
        public async Task HandleAsync(SignUp command, CancellationToken cancellationToken = default)
        {

            var securedPassword = _passwordManger.Secure(command.Password);
            var user = new User (command.UserId, command.Email, command.Name, command.LastName, command.Password);
        }
    }
}
