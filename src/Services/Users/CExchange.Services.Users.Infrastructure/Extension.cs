using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Abstractions;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using CExchange.Services.Users.Infrastructure.Auth;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB.Repositories;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB.Settings;
using CExchange.Services.Users.Infrastructure.PasswordSecurity;
using CExchange.Services.Users.Infrastructure.RabbitMq;
using CExchange.Services.Users.Infrastructure.Time;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CExchange.Services.Users.Application.Queries;
using CExchange.Services.Users.Infrastructure.DAL.Handlers;
using CExchange.Services.Users.Application.Abstractions;
using CExchange.Services.Users.Application.DTO;

namespace CExchange.Services.Users.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDB"));

            return services.AddSingleton<IMongoClient, MongoClient>(sp =>
                    new MongoClient(sp.GetRequiredService<IOptions<MongoDbSettings>>().Value.ConnectionString))
                .AddSingleton<IMongoDbContext, MongoDbContext>()
                .AddAuth(configuration)
                .AddHttpContextAccessor()
                .AddScoped<IQueryHandler<GetUser, UserDetailsDto>, GetUserHandler>()
                .AddScoped<IQueryHandler<GetUsers, IEnumerable<UserDto>>, GetUsersHandler>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddSingleton<IClock, Clock>()
                .AddScoped<IPasswordManager, PasswordManager>()
                .AddTransient<IAuthenticator, Authenticator>()
                .AddTransient<ITokenStorage, HttpContextTokenStorage>()
                .AddSingleton<RabbitMqService>();
        }
    }
}
