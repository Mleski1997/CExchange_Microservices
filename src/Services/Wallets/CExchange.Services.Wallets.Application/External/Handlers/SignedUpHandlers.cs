using CExchange.Services.Wallets.Application.Commands;
using CExchange.Services.Wallets.Application.Commands.Handlers;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Application.External.Handlers
{
    public class SignedUpHandlers : IEventHandler<SignedUp>
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public SignedUpHandlers(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public async Task HandleAsync(SignedUp @event, CancellationToken cancellationToken = default)
        {
            var addWalletCommand = new AddWallet(@event.UserId, "Wallet1");
            await _commandDispatcher.SendAsync(addWalletCommand, cancellationToken);
           
        }
    }
}
