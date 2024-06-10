using Convey.CQRS.Commands;

namespace CExchange.Services.Users.Application.Commands
{
    public record SignIn(string Email, string Password) : ICommand;

}
