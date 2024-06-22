using CExchange.Services.Users.Application;
using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Abstractions;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using CExchange.Services.Users.Infrastructure.Auth;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB.Repositories;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB.Settings;
using CExchange.Services.Users.Infrastructure.Exceptions;
using CExchange.Services.Users.Infrastructure.PasswordSecurity;
using CExchange.Services.Users.Infrastructure.Time;
using Convey;
using Convey.CQRS.Queries;
using Convey.WebApi.CQRS;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Convey.WebApi.Swagger;
using Convey.Docs.Swagger;


namespace CExchange.Services.Users.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            //builder.Services.Configure<MongoDbSettings>(configuration.GetSection("MongoDb"));
            builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
                new MongoClient(sp.GetRequiredService<IOptions<MongoDbSettings>>().Value.ConnectionString));
            builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
            //builder.Services.AddAuth(configuration);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddSingleton<IClock, Clock>();
            builder.Services.AddScoped<IPasswordManager, PasswordManager>();
            builder.Services.AddTransient<IAuthenticator, Authenticator>();
            builder.Services.AddTransient<ITokenStorage, HttpContextTokenStorage>();

            builder.AddExceptionToMessageMapper<ExceptionToMessageMapper>();

            builder
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddMongo()
                .AddRabbitMq();
               







            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app 
                .UseConvey()
                .UsePublicContracts<ContractAttribute>()
                .UseRabbitMq();
                

                

            return app;
        }
    }
}