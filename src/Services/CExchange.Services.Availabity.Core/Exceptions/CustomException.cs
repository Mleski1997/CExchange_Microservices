using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Core.Exceptions
{
    public abstract class CustomException : Exception
    {
        public virtual string Code { get; }
        protected CustomException(string message) : base(message)
        { }
    }
}
