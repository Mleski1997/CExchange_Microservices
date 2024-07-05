using System.Threading;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Abstractions
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
