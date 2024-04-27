using Convey.CQRS.Commands;s

namespace CExchange.Services.User.Application.Commands
{
    public record SignUp(Guid Id, string Email, string Name, string LastName, string Password) : ICommand;

}
