using CExchange.Services.Wallets.Core.Entities;
using CExchange.Services.Wallets.Core.Repositories;

using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Application.Commands.Handlers
{
    public class AddWalletHandler : ICommandHandler<AddWallet>
    {
       
        private readonly IWalletRepository _walletRepository;

        public AddWalletHandler(IWalletRepository walletRepository)
        {          
            _walletRepository = walletRepository;
        }
        public async Task HandleAsync(AddWallet command, CancellationToken cancellationToken = default)
        {
            var wallet = new Wallet
            {
                UserId = command.UserId,
                WalletName = command.WalletName,
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
                return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 16)
               .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            while (await _walletRepository.AddressExistsAsync(address));

            return address;
        }
    }
}
