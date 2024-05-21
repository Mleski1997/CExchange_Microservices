using CExchange.Services.Wallets.Application.Services;
using CExchange.Services.Wallets.Core.Entities;
using CExchange.Services.Wallets.Core.Repositories;
using Convey.CQRS.Events;

namespace CExchange.Services.Wallets.Application.External.Handlers
{
    public class SignedUpHandlers : IEventHandler<SignedUp>
    {
        private readonly IWalletRepository _walletRepository;

        public SignedUpHandlers(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public async Task HandleAsync(SignedUp @event, CancellationToken cancellationToken = default)
        {
            var wallet = new Wallet
            {
                UserId = @event.UserId,
                WalletName = $"{@event.Name}",
                Address = await GenerateWalletAddress()
            };

            await _walletRepository.AddAsync(wallet);
            
       
        }


        private async Task<string> GenerateWalletAddress()
        {
            string address;
            var random = new Random();
            do
            {
                address = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 16)
                   .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            while (await _walletRepository.AddressExistsAsync(address));

            return address;
        }
    }
}
