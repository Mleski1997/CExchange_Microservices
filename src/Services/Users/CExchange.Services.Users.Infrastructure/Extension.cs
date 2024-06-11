using CExchange.Services.Users.Application;
using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Application.Services;
using CExchange.Services.Users.Core.Abstractions;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using CExchange.Services.Users.Infrastructure.Auth;
using CExchange.Services.Users.Infrastructure.DAL;
using CExchange.Services.Users.Infrastructure.Exception;
using CExchange.Services.Users.Infrastructure.PasswordSecurity;
using CExchange.Services.Users.Infrastructure.Repositories;
using CExchange.Services.Users.Infrastructure.Services;
using CExchange.Services.Users.Infrastructure.Time;
using Convey;
using Convey.CQRS.Queries;
using Convey.HTTP;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            
            builder.Services.AddAuth(configuration);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<IMessageBroker, MessageBroker>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddSingleton<IClock, Clock>();
            builder.Services.AddScoped<IPasswordManager, PasswordManager>();
            builder.AddExceptionToMessageMapper<ExceptionToMessageMapper>();


            return builder
                .AddRabbitMq()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddHttpClient();

        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseConvey()
               .UsePublicContracts<ContractAttribute>()
               .UseAuthentication()
               .UseAuthorization()
               .UseRabbitMq()
               .SubscribeCommand<SignUp>();

            return app;
        }
    }
}
