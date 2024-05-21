using CExchange.Services.Users.Application;
using CExchange.Services.Users.Application.Commands.Handlers;
using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.Services;
using CExchange.Services.Users.Core.Abstractions;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using CExchange.Services.Users.Infrastructure.Auth;
using CExchange.Services.Users.Infrastructure.DAL;
using CExchange.Services.Users.Infrastructure.PasswordSecurity;
using CExchange.Services.Users.Infrastructure.Repositories;
using CExchange.Services.Users.Infrastructure.Services;
using CExchange.Services.Users.Infrastructure.Time;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.Docs.Swagger;
using Convey.MessageBrokers.RabbitMQ;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Convey.WebApi.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CExchange.Services.Users.Application.Events;

namespace CExchange.Services.Users.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddControllers();
            builder.Services.AddAuth(configuration);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddSingleton<IClock, Clock>();
            builder.Services.AddTransient<IMessageBroker, MessageBroker>();
         
           
            builder.Services.AddSecurity();

            builder
                .AddRabbitMq();
             

            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseConvey();
            app.UsePublicContracts<ContractAttribute>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRabbitMq();

            return app;
        }
    }
}
