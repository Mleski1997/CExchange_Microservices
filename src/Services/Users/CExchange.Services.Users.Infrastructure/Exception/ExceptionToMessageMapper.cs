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

namespace CExchange.Services.Users.Infrastructure.Exception
{
    internal sealed class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(System.Exception exception, object message)
            => exception switch

            {
                EmailInUseException ex => new SignUpRejected(ex.Email, ex.Message, ex.Code),
                InvalidEmailException ex => message switch
                {

                    SignUpRejected command => new SignUpRejected(command.Email, ex.Message, ex.Code),
                    _ => null
                },
                _ => null
            };
    }
}