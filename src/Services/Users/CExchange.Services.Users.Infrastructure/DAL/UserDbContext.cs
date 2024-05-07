using CExchange.Services.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.DAL
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
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            }
    }
}
 