﻿using CExchange.Services.Wallets.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using CExchange.Services.Wallets.Core.Repositories;
using CExchange.Services.Wallets.Infrastructure.Repositories;
using Convey;
using Convey.MessageBrokers.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using CExchange.Services.Wallets.Application.External;
using Convey.MessageBrokers.CQRS;
using Convey.CQRS.Commands;
using CExchange.Services.Wallets.Application.Commands;
using CExchange.Services.Wallets.Application.Commands.Handlers;
using Convey.CQRS.Events;
using CExchange.Services.Wallets.Application.External.Handlers;

namespace CExchange.Services.Wallets.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddDbContext<WalletDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();
            

            builder.AddRabbitMq();
               


            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseConvey()
                .UseRabbitMq()
                .SubscribeEvent<SignedUp>();

            return app;
        }

     }
}
