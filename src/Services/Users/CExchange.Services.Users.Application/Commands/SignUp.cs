using CExchange.Services.Users.Application.Abstractions;
using System;

namespace CExchange.Services.Users.Application.Commands
{
    public record SignUp(Guid Id, string Email, string Password, string Name, string LastName, string Role) : ICommand;
}
