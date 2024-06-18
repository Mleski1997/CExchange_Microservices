using Convey.CQRS.Commands;

namespace CExchange.Services.Users.Application.Commands
{
    [Contract]
    public record SignUp(Guid Id, string Email, string Name, string LastName, string Password, string Role) : ICommand;

}
