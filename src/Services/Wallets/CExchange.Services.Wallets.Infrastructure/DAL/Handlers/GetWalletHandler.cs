using CExchange.Services.Wallets.Application.DTO;
using CExchange.Services.Wallets.Application.Queries;
using CExchange.Services.Wallets.Core.Entities;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Infrastructure.DAL.Handlers
{
    public class GetWalletHandler : IQueryHandler<GetWallet, WalletDto>
    {
        private readonly WalletDbContext _context;

        public GetWalletHandler(WalletDbContext context)
        {
            _context = context;
        }
        public async Task<WalletDto> HandleAsync(GetWallet query, CancellationToken cancellationToken = default)
        {
           var wallet = await _context.Wallets.SingleOrDefaultAsync(x => x.Address == query.Adress);
            return MapToDto(wallet);
        }

        private WalletDto MapToDto(Wallet wallet)
        {
            return new WalletDto
            {
                Adress = wallet.Address,
                TotalBalance = wallet.TotalBalance,        
            };
        }
    }
}
