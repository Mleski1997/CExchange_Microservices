using CExchange.Services.Users.Application;
using CExchange.Services.Users.Infrastructure;
using Convey;
using Convey.MessageBrokers.RabbitMQ;
using Convey.WebApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;



// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
builder.Services
            .AddConvey()
            .AddWebApi()
            .AddApplication()
            .AddInfrastructure()
            .Build();

builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseInfrastructure();

app.MapControllers();



await app.RunAsync();