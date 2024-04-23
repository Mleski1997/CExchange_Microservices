using CExchange.Services.Availability.Core.Entities;
using CExchange.Services.Availability.Core.Repositories;
using CExchange.Services.Availability.Infrastructure.Mongo.Documents;
using Convey.Persistence.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Infrastructure.Mongo.Repositories
{
    internal sealed class ResourcesMongoRepository : IResourcesRepository
    {
        private readonly IMongoRepository<ResourceDocument, Guid> _repository;

        public ResourcesMongoRepository(IMongoRepository<ResourceDocument, Guid> repository)
        {
            _repository = repository;
        }
        public Task AddAsync(Resource resource)
            => _repository.AddAsync(resource.AsDocument());
     

        public Task DeleteAsync(AggregateId id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(AggregateId id)
            => _repository.ExistsAsync(r => r.Id == id);
        

        public async Task<Resource> GetAsync(AggregateId id)
        {
            var document = await _repository.GetAsync(r => r.Id == id);
            return document.AsEntity();
        }

        public Task UpdateAsync(Resource resource)
            => _repository.Collection.ReplaceOneAsync(r => r.Id == resource.Id &&
            r.Version < resource.Version,
                resource.AsDocument()); 
    }
}
