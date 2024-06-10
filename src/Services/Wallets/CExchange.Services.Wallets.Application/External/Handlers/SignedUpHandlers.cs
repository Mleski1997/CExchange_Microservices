using Convey.CQRS.Events;

namespace CExchange.Services.Wallets.Application.External.Handlers
{
    public class SignedUpHandlers : IEventHandler<SignedUp>
    {
        public Task HandleAsync(SignedUp @event, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
