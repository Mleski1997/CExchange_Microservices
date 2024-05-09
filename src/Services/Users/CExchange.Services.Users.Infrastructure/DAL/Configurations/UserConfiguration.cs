using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.DAL.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email)
                .HasConversion(x => x.Value, x => new Email(x))
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Name)
               .HasConversion(x => x.Value, x => new Name(x))
               .IsRequired()
               .HasMaxLength(30);
            builder.Property(x => x.LastName)
               .HasConversion(x => x.Value, x => new LastName(x))
               .IsRequired()
               .HasMaxLength(30);
            builder.Property(x => x.Password)
               .HasConversion(x => x.Value, x => new Password(x))
               .IsRequired()
               .HasMaxLength(100);
            builder.Property(x => x.Role)
               .HasConversion(x => x.Value, x => new Role(x))
               .IsRequired()
               .HasMaxLength(30);
        }
    }
}
