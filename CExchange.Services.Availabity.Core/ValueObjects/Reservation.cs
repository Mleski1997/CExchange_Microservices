using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availabity.Core.ValueObjects
{
    public struct Reservation : IEquatable<Reservation>
    {
        public DateTime DateTime { get;  }
        public int Prioryty { get; }

        public Reservation(DateTime dateTime, int priority)
        {
            DateTime = dateTime;
            Prioryty = priority;
            
        }

        public bool Equals(Reservation other)
        {
            return DateTime.Equals(other.DateTime) && Prioryty == other.Prioryty;
        }

        public override bool Equals(object obj)
        {
            return obj is Reservation other && Equals(other);  
        }

        public override int GetHashCode() => HashCode.Combine(DateTime, Prioryty);

    }
}
