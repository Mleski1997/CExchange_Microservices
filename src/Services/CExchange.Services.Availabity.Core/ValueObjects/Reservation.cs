using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Core.ValueObjects
{
    public class Reservation
    {
        public DateTime DateTime { get; }
        public int Priority { get; }

        private Reservation()
        {
        }


        public Reservation(DateTime dateTime, int prioryty)
        {
            DateTime = dateTime;
            Priority = prioryty;
        }
    }
}
