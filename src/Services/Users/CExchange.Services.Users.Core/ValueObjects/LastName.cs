using CExchange.Services.Users.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.ValueObjects
{
    public sealed record LastName
    {
        public string Value { get; }

        public LastName(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length is > 100 or < 3)
            {
                throw new InvalidLastNameExcpetion(value);
            }
            Value = value;
        }

        public static implicit operator LastName(string value) => value is null ? null : new LastName(value);
        public static implicit operator string(LastName value) => value?.Value;
        public override string ToString() => Value;
    }
}
