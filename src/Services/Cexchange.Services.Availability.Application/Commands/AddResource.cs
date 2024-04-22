using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = Convey.CQRS.Commands.ICommand;

namespace Cexchange.Services.Availability.Application.Commands
{
    public class AddResource : ICommand
    {
        public Guid ResourceId { get;}
        public IEnumerable <string> Tags { get; }

        public AddResource(Guid resourceId, IEnumerable<string> tags)
           => (ResourceId, Tags) = (resourceId == Guid.Empty ? Guid.NewGuid() : resourceId,
               tags ?? Enumerable.Empty<string>());

    }
}
