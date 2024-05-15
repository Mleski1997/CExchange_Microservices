using CExchange.Services.Users.Core.Abstractions;
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.Repositories;
using CExchange.Services.Users.Infrastructure.Auth;
using CExchange.Services.Users.Infrastructure.DAL;
using CExchange.Services.Users.Infrastructure.PasswordSecurity;
using CExchange.Services.Users.Infrastructure.Repositories;
using CExchange.Services.Users.Infrastructure.Time;
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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers();
            services.AddAuth(configuration);
            services.AddHttpContextAccessor();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddSingleton<IClock, Clock>();
            services.AddSecurity();

            return services;

        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            app.MapControllers();
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
