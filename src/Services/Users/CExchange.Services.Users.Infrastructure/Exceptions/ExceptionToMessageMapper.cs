using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.Events.Rejected;
using CExchange.Services.Users.Application.Exceptions;
using CExchange.Services.Users.Core.Exceptions;
using Convey.MessageBrokers.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.Exceptions
{
    internal sealed class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(System.Exception exception, object message)
        {
            throw new NotImplementedException();
        }
    }

}