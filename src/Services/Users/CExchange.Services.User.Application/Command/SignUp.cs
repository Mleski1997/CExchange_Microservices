using CExchange.Services.Users.Core.Entities;
using Convey.CQRS.Commands;
namespace CExchange.Services.Users.Application.Command
{
    public record SignUp(Guid UserId, string Email, string Name, string LastName, string Password, string? Role = null) : ICommand;
}
