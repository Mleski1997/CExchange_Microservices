using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Core.Exceptions
{
    public class CannotExpropriateReservationException : DomainException
    {
        public override string Code { get; } = "cannot_expropriate_reservation";
        public Guid ResourceId { get; }
        public DateTime DateTime { get; }

        public CannotExpropriateReservationException(Guid resourceId, DateTime dateTime)
            : base($"Cannot expropriate resource {resourceId} reservation at {dateTime}")
            => (ResourceId, DateTime) = (resourceId, dateTime);
    }
}