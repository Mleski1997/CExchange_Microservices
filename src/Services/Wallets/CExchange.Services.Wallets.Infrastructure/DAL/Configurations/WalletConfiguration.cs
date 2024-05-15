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
            builder.HasKey(w => w.Address);
            builder.Property(w => w.Address).IsRequired().HasMaxLength(16);
            builder.Property(w => w.WalletName).IsRequired().HasMaxLength(50);
        }
    }
}
