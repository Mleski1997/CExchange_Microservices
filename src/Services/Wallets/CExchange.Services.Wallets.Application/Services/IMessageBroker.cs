﻿using Convey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Application.Services
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
        Task PublishAsync(IEnumerable<IEvent> events);
    }
}
