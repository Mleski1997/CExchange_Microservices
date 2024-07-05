
using CExchange.Services.Wallets.Application;
using CExchange.Services.Wallets.Infrastructure;
using Convey;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddConvey()
                 .AddApplication()
                 .AddInfrastructure(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseInfrastructure();

app.MapControllers();

app.Run();
