using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Infrastructure.Mongo.Documents
{
    internal  sealed class ReservationDocument
    {
        public int TimeStamp { get; set; }
        public int Priority { get; set; }

    }
}
