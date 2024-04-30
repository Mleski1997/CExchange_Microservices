using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.PasswordSecurity
{
    internal static class Extensions
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services
                .AddSingleton<IPasswordHasher<object>, PasswordHasher<object>>()
                .AddSingleton<IPasswordManger, PasswordManager>();

            return services;
        }

    }
}
