using CExchange.Services.Wallets.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using CExchange.Services.Wallets.Core.Repositories;
using CExchange.Services.Wallets.Infrastructure.Repositories;

namespace CExchange.Services.Wallets.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WalletDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IWalletRepository, WalletRepository>();
           


            return services;
        }

     }
}
