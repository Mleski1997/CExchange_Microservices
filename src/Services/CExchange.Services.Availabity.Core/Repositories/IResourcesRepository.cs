using CExchange.Services.Availabity.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availabity.Core.Repositories
{
    public interface IResourcesRepository
    {
        Task<Resource> GetAsync(AggregateId id);
        Task<bool> ExistsAsync(AggregateId id);
        Task AddAsync(Resource resource);
        Task UpdateAsync(Resource resource);
        Task DeleteAsync(AggregateId id);
    }
}