using Convey;
using CExchange.Services.Availability.Infrastructure;
using CExchange.Services.Availability.Application;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Cexchange.Services.Availability.Application.Commands;
using Convey.Types;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddConvey()
    .AddInfrastructure()
    .AddApplication()
    .AddWebApi();
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseInfrastructure()
    .UseDispatcherEndpoints(endpoints => endpoints
     .Get("", ctx => ctx.Response.WriteAsync(
         ctx.RequestServices.GetService<AppOptions>().Name))
    .Post<AddResource>("resources",
         afterDispatch: (cmd, ctx) => ctx.Response.Created($"resources/{cmd.ResourceId}")));

app.Run();
