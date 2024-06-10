using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.Exceptions
{
    public class InvalidAggregateIdException : CustomException
    {
        public override string Code { get; } = "invalid_aggregate_id";

        public InvalidAggregateIdException() : base($"Invalid aggregate id.")
        {
        }
    }
}