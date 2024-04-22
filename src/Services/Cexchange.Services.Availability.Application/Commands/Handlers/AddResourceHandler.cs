using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cexchange.Services.Availability.Application.Commands.Handlers
{
    public class AddResourceHandler : ICommandHandler<AddResource>
    {

        public Task HandleAsync(AddResource command, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
