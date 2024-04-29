using CExchange.Services.Users.Core.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.Repositories
{
     public interface IUserRepository
     {
        Task<User> GetBydIdAsync(Guid UserId);
        Task<User> GetByEmailAsync(string Email);
        Task AddAsync(User user);
     }
}
