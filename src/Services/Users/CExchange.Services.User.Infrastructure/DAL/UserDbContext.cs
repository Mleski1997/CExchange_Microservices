using CExchange.Services.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.DAL
{
    public class UserDbContext : DbContext
    {
        public class UserDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }

            public UserDbContext(DbContextOptions<UserDbContext> options)
                : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

              
                modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(e => e.Id); 
                    entity.Property(e => e.Email)
                          .IsRequired()
                          .HasMaxLength(100);
                    entity.HasIndex(e => e.Email) 
                          .IsUnique(); 
                    entity.Property(e => e.Name)
                          .IsRequired()
                          .HasMaxLength(50);
                    entity.Property(e => e.LastName)
                         .IsRequired()
                         .HasMaxLength(50);

                });

                
            }
        }
    }
 }