using CExchange.Services.Coins.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Coins.Core.Entities
{
    public class AggregadeId
    {
        public Guid Value { get; }
        public AggregadeId()
        {
            Value = Guid.NewGuid();
        }

        public AggregadeId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidAggregateIdException(value);
            }
            Value = value;

        }
        public static AggregadeId Create() => new AggregadeId(Guid.NewGuid());
        public static implicit operator Guid(AggregadeId id) => id.Value;
        public static implicit operator AggregadeId(Guid id) => new(id);

        public override string ToString() => Value.ToString();
    }
           
}
