using CExchange.Services.Users.Application;
using CExchange.Services.Users.Infrastructure;
using Convey;
using Convey.MessageBrokers.RabbitMQ;
using Convey.WebApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



// Add services to the container.
var builder = WebHost.CreateDefaultBuilder(args)
    .ConfigureServices(services => services
        .AddConvey()
        .AddWebApi()
        .AddApplication()
        .AddInfrastructure()
        .Build())
    .Configure(app => app
        .UseInfrastructure());


var host = builder.Build();
await host.RunAsync();