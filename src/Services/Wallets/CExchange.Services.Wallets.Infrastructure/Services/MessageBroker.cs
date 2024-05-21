﻿using CExchange.Services.Wallets.Application.Services;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Infrastructure.Services
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IBusPublisher _busPublisher;

        public MessageBroker(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        public Task PublishAsync(params IEvent[] events) => PublishAsync(events?.AsEnumerable());
      

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            if (events is null)
            {
                return;
            }
            foreach(var @event in events)
            {
                if(@event is null)
                {
                    continue;
                }
                
                var messageId = Guid.NewGuid().ToString("N");
                await _busPublisher.PublishAsync(@event, messageId);
            }

        }
    }
}