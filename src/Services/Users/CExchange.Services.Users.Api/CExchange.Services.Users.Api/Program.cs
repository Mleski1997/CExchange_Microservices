using CExchange.Services.Users.Application;
using CExchange.Services.Users.Infrastructure;
using Convey;
using Convey.MessageBrokers.RabbitMQ;
using Convey.WebApi;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConvey()              
                 .AddApplication()
                 .AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseInfrastructure();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
