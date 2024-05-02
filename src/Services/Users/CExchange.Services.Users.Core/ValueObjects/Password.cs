using CExchange.Services.Users.Core.Exceptions;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.ValueObjects
{
    public sealed record Password
    {
        private static readonly Regex Regex = new (@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).+$", RegexOptions.Compiled);
            
        public string Value { get; }

        public Password(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidPasswordExcpetion();
            }

            if (value.Length < 6)
            {
                throw new InvalidPasswordExcpetion();
            }
            if (!Regex.IsMatch(value))
            {
                throw new InvalidPasswordExcpetion();
            }
            Value = value;
        }

        public static implicit operator string(Password password) => password.Value;
        public static implicit operator Password(string password) => new(password);
        public override string ToString() => Value;
       
    }
}
