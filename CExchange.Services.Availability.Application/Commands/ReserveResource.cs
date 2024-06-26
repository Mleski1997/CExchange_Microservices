﻿using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CExchange.Services.Availability.Application.Commands
{
    [Contract]
    public class ReserveResource : ICommand
    {
        public Guid ResourceId { get; }
        public DateTime DateTime { get; }
        public int Priority { get; }
        public Guid CustomerId { get; }

        public ReserveResource(Guid resourceId, DateTime dateTime, int priority, Guid customerId)
            => (ResourceId, DateTime, Priority, CustomerId) = (resourceId, dateTime, priority, customerId);
    }
}