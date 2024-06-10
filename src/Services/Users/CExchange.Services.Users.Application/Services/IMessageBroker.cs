using Convey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Services
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
    }
}
