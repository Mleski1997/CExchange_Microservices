using CExchange.Services.Wallets.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Infrastructure.DAL
{
    public class WalletDbContext : DbContext   
    {
        public DbSet<Wallet> Wallets { get; set; }
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base (options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
