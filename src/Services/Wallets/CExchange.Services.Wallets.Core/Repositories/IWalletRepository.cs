using CExchange.Services.Wallets.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.Repositories
{
    public interface IWalletRepository
    {
        Task AddAsync (Wallet wallet);
        Task<bool> AddressExistsAsync(string Address);
        Task<Wallet> GetByAddresWalllet(string Address);
    }
}
