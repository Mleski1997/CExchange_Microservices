using Convey.CQRS.Commands;

namespace CExchange.Services.Users.Application.Commands
{
    public record SignUp(Guid UserId, string Email, string Name, string LastName, string Password) : ICommand;

}
