using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availabity.Core.ValueObjects
{
    public class Reservation
    {
        public DateTime DateTime { get; }
        public int Prioryty { get; }

        private Reservation()
        {
        }


        public Reservation(DateTime dateTime, int prioryty)
        {
            DateTime = dateTime;
            Prioryty = prioryty;
        }
    }
}
