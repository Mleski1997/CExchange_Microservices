﻿using CExchange.Services.Availability.Application.Commands;
using CExchange.Services.Availability.Application.Events.Rejected;
using CExchange.Services.Availability.Application.Exceptions;
using CExchange.Services.Availability.Core.Exceptions;
using Convey.MessageBrokers.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Infrastructure.Exceptions
{
    internal sealed class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
            => exception switch
            {
                MissingResourceTagsException ex => new AddResourceRejected(Guid.Empty, ex.Message,
                    ex.Code),
                InvalidResourceTagsException ex => new AddResourceRejected(Guid.Empty, ex.Message,
                    ex.Code),
             
                CannotExpropriateReservationException ex => message switch
                {
                    ReserveResource command => new ReleaseResourceReservationRejected(command.ResourceId, command.DateTime,
                        ex.Message, ex.Code),
                    _ => null
                },
                CustomerNotFoundException ex => message switch
                {
                    ReserveResource command => new ReleaseResourceReservationRejected(command.ResourceId, command.DateTime,
                        ex.Message, ex.Code),
                    _ => null
                },
                InvalidCustomerStateException ex => message switch
                {
                    ReserveResource command => new ReleaseResourceReservationRejected(command.ResourceId, command.DateTime,
                        ex.Message, ex.Code),
                    _ => null
                },
                ResourceNotFoundException ex => message switch
                {
                    DeleteResource command => new DeleteResourceRejected(command.ResourceId,
                        ex.Message, ex.Code),
                    ReserveResource command => new ReleaseResourceReservationRejected(command.ResourceId, command.DateTime,
                        ex.Message, ex.Code),
                    ReleaseResourceReservation command => new ReleaseResourceRejected(command.ResourceId, command.DateTime,
                        ex.Message, ex.Code),
                    _ => null
                },
                UnauthorizedResourceAccessException ex => message switch
                {
                    ReserveResource command => new ReleaseResourceReservationRejected(command.ResourceId, command.DateTime,
                        ex.Message, ex.Code),
                    _ => null
                },
                _ => null
            };
    }
}