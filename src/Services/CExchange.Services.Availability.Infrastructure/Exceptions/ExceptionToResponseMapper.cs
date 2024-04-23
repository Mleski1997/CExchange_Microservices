using CExchange.Services.Availability.Application.Exceptions;
using CExchange.Services.Availability.Core.Exceptions;
using Convey.WebApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Infrastructure.Exceptions
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                CustomException ex => new ExceptionResponse(new { code = ex.Code, reason = ex.Message }, HttpStatusCode.BadRequest),
                AppException ex => new ExceptionResponse(new { code = ex.Code, reason = ex.Message }, HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new { code = "error", reason = "There was an error" }, HttpStatusCode.BadRequest)
            };
      
    }
}
