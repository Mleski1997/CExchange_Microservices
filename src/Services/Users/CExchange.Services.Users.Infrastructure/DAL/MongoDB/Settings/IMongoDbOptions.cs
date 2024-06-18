using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.DAL.MongoDB.Settings
{
    public interface IMongoDbOptions<T>
    {
        string ConnectionString { get; }
        string Database { get; }
    }
}