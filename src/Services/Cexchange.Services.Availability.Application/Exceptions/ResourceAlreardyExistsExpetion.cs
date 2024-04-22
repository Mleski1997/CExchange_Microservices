using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Application.Exceptions
{
    public class ResourceAlreardyExistsExpetion : CustomException
    {
        public Guid ResourceId { get;}
        public ResourceAlreardyExistsExpetion(Guid resourceId) : base($"Resource with id {resourceId} already id.")
        {
            ResourceId = resourceId;
        }
    }
}
