using CExchange.Services.Users.Application;
using CExchange.Services.Users.Infrastructure;
using Convey;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConvey()
                 .AddApplication();
                

builder.Services.AddInfrastructure(builder.Configuration);





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

app.UseHttpsRedirection();

app.UseInfrastructure();

app.Run();
