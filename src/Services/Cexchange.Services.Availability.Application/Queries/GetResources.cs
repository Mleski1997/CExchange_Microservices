using CExchange.Services.Availability.Application.DTO;
using Convey.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Infrastructure.Mongo.Queries.Handlers
{
    public class GetResources : IQuery<IEnumerable<ResourceDto>>
    {
        public IEnumerable <string> Tags{ get; set; }
        public bool MatchAllTags { get; set; }

    }
}
