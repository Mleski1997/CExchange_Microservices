using CExchange.Services.Availabity.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availabity.Core.Entities
{
    public class AggregateId : IEquatable<AggregateId>
    {
        public Guid Value { get; set; }

        public AggregateId() : this(Guid.NewGuid())
        {
        }

        public AggregateId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidAggregateIdException(value);
            }
            Value = value;
        }

        public bool Equals(AggregateId? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AggregateId?)obj);
        }


    }
}