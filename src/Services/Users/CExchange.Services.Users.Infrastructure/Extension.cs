using CExchange.Services.Users.Application;
using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.Events;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Application.Services;
using CExchange.Services.Users.Core.Abstractions;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using CExchange.Services.Users.Infrastructure.Auth;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB.Repositories;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB.Settings;
using CExchange.Services.Users.Infrastructure.Exception;
using CExchange.Services.Users.Infrastructure.PasswordSecurity;
using CExchange.Services.Users.Infrastructure.Services;
using CExchange.Services.Users.Infrastructure.Time;
using Convey;
using Convey.CQRS.Queries;
using Convey.HTTP;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.Outbox;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.Tracing.Jaeger;
using Convey.Tracing.Jaeger.RabbitMQ;
using Convey.WebApi.CQRS;
using Convey.WebApi.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace CExchange.Services.Users.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder, IConfiguration configuration)
        {
            builder.Services.Configure<MongoDbSettings>(configuration.GetSection("MongoDb"));
            builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
                new MongoClient(sp.GetRequiredService<IOptions<MongoDbSettings>>().Value.ConnectionString));
            builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
            builder.Services.AddAuth(configuration);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddSingleton<IClock, Clock>();
            builder.Services.AddScoped<IPasswordManager, PasswordManager>();

            builder.AddExceptionToMessageMapper<ExceptionToMessageMapper>();

            builder
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddMongo()
                .AddRabbitMq()
                .AddWebApiSwaggerDocs();

            var rabbitMqSettings = configuration.GetSection("rabbitMq").Get<RabbitMqOptions>();
            Console.WriteLine($"RabbitMQ Exchange: {rabbitMqSettings.Exchange.Name}");
            Console.WriteLine($"RabbitMQ Exchange Type: {rabbitMqSettings.Exchange.Type}");
            Console.WriteLine($"RabbitMQ Exchange Durable: {rabbitMqSettings.Exchange.Durable}");
            Console.WriteLine($"RabbitMQ Exchange AutoDelete: {rabbitMqSettings.Exchange.AutoDelete}");


            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseConvey()
               .UsePublicContracts<ContractAttribute>()
               .UseRabbitMq()
               .SubscribeEvent<SignedUp>();

            return app;
        }
    }
}
