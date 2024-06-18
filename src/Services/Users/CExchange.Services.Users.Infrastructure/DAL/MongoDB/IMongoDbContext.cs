using CExchange.Services.Users.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.DAL.MongoDB
{
    public interface IMongoDbContext
    {
        IMongoCollection<User> Users { get; }
    }
}
