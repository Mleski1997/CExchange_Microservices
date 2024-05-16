using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.Commands.Handlers;
using CExchange.Services.Users.Application.Events;
using CExchange.Services.Users.Core.Abstractions;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using CExchange.Services.Users.Infrastructure.Auth;
using CExchange.Services.Users.Infrastructure.DAL;
using CExchange.Services.Users.Infrastructure.PasswordSecurity;
using CExchange.Services.Users.Infrastructure.Repositories;
using CExchange.Services.Users.Infrastructure.Time;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.MessageBrokers.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddControllers();
            builder.Services.AddAuth(configuration);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddTransient<ICommandHandler<SignUp>, SignUpHandler>();
            builder.Services.AddTransient<IEventHandler<SignedUp>, SignedUpHandler>();
            builder.Services.AddSingleton<IClock, Clock>();
            builder.Services.AddSecurity();
            builder.AddRabbitMq();

            return builder;

        }

        public static IApplicationBuilder UserInfrastructure(this WebApplication app)
        {
            app.MapControllers();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRabbitMq();

            return app;
        }
    }
}
