using CExchange.Services.Users.Application.Services;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Convey.MessageBrokers.RabbitMQ;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.Services
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IBusPublisher _busPublisher;
        private readonly ILogger<IMessageBroker> _logger;


        public MessageBroker(IBusPublisher busPublisher, ILogger<IMessageBroker> logger)
        {
            _busPublisher = busPublisher;
            _logger = logger;

        }

        public Task PublishAsync(params IEvent[] events) => PublishAsync(events?.AsEnumerable());

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            if (events == null)
            {
                return;
            }

            foreach (var @event in events)
            {
                if (@event == null)
                {
                    continue;
                }

                var messageId = Guid.NewGuid().ToString("N");
                _logger.LogTrace($"Publishing integration event: {@event.GetType().Name} [id: '{messageId}'].");
                await _busPublisher.PublishAsync(@event, messageId);
            }
        }
    }
}