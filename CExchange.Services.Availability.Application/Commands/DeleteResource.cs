using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CExchange.Services.Availability.Application.Commands
{
    [Contract]
    public class DeleteResource : ICommand
    {
        public Guid ResourceId { get; }

        public DeleteResource(Guid resourceId)
            => ResourceId = resourceId;
    }
}