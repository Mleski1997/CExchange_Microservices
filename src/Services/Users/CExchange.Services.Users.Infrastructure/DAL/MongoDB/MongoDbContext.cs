// Infrastructure/DAL/MongoDB/MongoDbContext.cs
using CExchange.Services.Users.Core.Entities;
using CExchange.Services.Users.Core.ValueObjects;
using CExchange.Services.Users.Infrastructure.DAL.MongoDB.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CExchange.Services.Users.Infrastructure.DAL.MongoDB
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        static MongoDbContext()
        {
            BsonSerializer.RegisterSerializer(new EmailSerializer());
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(c => c.Email).SetSerializer(new EmailSerializer());
            });
        }

        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            var settings = options.Value;
            var mongoUrl = MongoUrl.Create(settings.ConnectionString);
            var client = new MongoClient(mongoUrl);
            _database = client.GetDatabase(settings.Database);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}
