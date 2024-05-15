using CExchange.Services.Wallets.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CExchange.Services.Wallets.Infrastructure.DAL
{
    public class WalletDbContext : DbContext   
    {
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<FiatCurrency> FiatsCurrencies { get; set; }
        public DbSet<CryptoCurrency> CryptoCurrencies { get; set; }
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base (options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }
    }
}
