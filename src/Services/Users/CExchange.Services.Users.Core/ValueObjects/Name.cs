using CExchange.Services.Users.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.ValueObjects
{
    public sealed record Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length is > 100 or < 3)
            {
                throw new InvalidNameExcpetion(value);
            }
            Value = value;
        }

        public static implicit operator Name(string value) => value is null ? null : new Name(value);
        public static implicit operator string(Name value) => value?.Value;
        public override string ToString() => Value;       
    }
}
