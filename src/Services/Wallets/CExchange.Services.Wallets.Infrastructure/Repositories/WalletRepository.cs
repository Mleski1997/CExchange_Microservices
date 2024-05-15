using CExchange.Services.Wallets.Core.Entities;
using CExchange.Services.Wallets.Core.Repositories;
using CExchange.Services.Wallets.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletDbContext _context;

        public WalletRepository(WalletDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
            await _context.SaveChangesAsync();
        }

        public Task<bool> AddressExistsAsync(string Address) => _context.Wallets.AnyAsync(x => x.Address == Address);
    }
}
