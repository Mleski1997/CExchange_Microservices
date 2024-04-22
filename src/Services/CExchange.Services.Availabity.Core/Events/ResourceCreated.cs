using CExchange.Services.Availability.Core.Entities;

namespace CExchange.Services.Availability.Core.Events
{
    public class ResourceCreated : IDomainEvent
    {
        public Resource Resource { get; set; }
        public ResourceCreated(Resource resource) => Resource = resource;

    }
}