using CExchange.Services.Users.Application.Command;
using CExchange.Services.Users.Application.Command.Handlers;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CExchange.Services.Users.Application
{
    public static class Extensions
    {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder) =>
            builder
            .AddCommandHandlers()
            .AddQueryHandlers();
            
   
    }
}
