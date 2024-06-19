using CExchange.Services.Availability.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Core.Events
{
    public class ResourceDeleted : IDomainEvent
    {
        public Resource Resource { get; }

        public ResourceDeleted(Resource resource)
            => Resource = resource;
    }
}