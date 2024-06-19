using Convey;
using Convey.WebApi;
using CExchange.Services.Availability.Application;
using CExchange.Services.Availability.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddConvey()
                 .AddWebApi()
                 .AddApplication()
                 .AddInfrastructure();

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
