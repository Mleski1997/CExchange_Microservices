using Convey.CQRS.Commands;

namespace CExchange.Services.Users.Application.Commands
{
    public record SignIn(string email, string password) : ICommand;

}
