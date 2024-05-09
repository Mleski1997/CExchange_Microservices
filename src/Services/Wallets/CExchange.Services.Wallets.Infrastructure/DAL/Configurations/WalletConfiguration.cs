using CExchange.Services.Wallets.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Infrastructure.DAL.Configurations
{
    internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(x => x.Adress);
            builder.Property(w => w.Adress)
                .IsRequired()
                .HasMaxLength(16);
            builder.Property(w => w.WalletName)
                .IsRequired()
                .HasMaxLength (20);
            builder.Property(w => w.UserId)
                .IsRequired();
            builder.HasMany(w => w.FiatBalances)
                .WithOne()
                .HasForeignKey("WalletAdress");
            builder.HasMany(w => w.CryptoBalances)
                .WithOne()
                .HasForeignKey("WalletAdress");
        }
    }
}
