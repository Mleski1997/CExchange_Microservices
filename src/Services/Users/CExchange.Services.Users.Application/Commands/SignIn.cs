
using CExchange.Services.Users.Application.Abstractions;

namespace CExchange.Services.Users.Application.Commands
{
    public record SignIn(string Email, string Password) : ICommand;

}
