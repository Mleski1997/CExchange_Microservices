using CExchange.Services.Availability.Application.Exceptions;
using CExchange.Services.Availability.Core.Entities;
using CExchange.Services.Availability.Core.Repositories;
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
        private readonly IResourcesRepository _resourcesRepository;

        public AddResourceHandler(IResourcesRepository resourcesRepository)
        {
            _resourcesRepository = resourcesRepository;
        }

        public async Task HandleAsync(AddResource command, CancellationToken cancellationToken = default)
        {
            if(await _resourcesRepository.ExistsAsync(command.ResourceId))
            {
                throw new ResourceAlreardyExistsExpetion(command.ResourceId);
            }

            var resource = Resource.Create(command.ResourceId, command.Tags);
            await _resourcesRepository.AddAsync(resource);
        }
    }
}
