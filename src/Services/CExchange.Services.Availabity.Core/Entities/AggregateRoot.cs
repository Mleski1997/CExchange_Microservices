﻿using CExchange.Services.Availability.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Core.Entities
{

    public abstract class AggregateRoot
    {
        private readonly List<IDomainEvent> _events = new();
        public IEnumerable<IDomainEvent> Events => _events;
        public AggregateId Id { get; protected set; }
        public int Version { get; protected set; }

        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any())
            {
                Version++;
            }
            _events.Add(@event);
        }

        public void ClearEvents() => _events.Clear();
    }
}
