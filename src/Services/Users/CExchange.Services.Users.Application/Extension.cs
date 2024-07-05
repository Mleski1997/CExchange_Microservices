using CExchange.Services.Users.Application.Abstractions;
using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.Commands.Handlers;
using CExchange.Services.Users.Application.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CExchange.Services.Users.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            return services
               .AddScoped<ICommandHandler<SignUp>, SignUpHandler>()
               .AddScoped<ICommandHandler<SignIn>, SignInHandler>();
               



        }
    }
}