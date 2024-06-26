﻿using CExchange.Services.Users.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.Entities
{
    public abstract class AggregateRoot
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public IEnumerable<IDomainEvent> Events => _events;
        public AggregateId Id { get; protected set; }
        public int Version { get; protected set; }

        protected void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }

        public void ClearEvents() => _events.Clear();
    }
}