using CExchange.Services.Availabity.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availabity.Core.Events
{
    public class ResourceCreated : IDomainEvent
    {
        public Resource Resource { get; set; }
        public ResourceCreated(Resource resource) => Resource = resource;

    }
}