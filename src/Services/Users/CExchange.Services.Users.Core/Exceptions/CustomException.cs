using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.Exceptions
{
    public abstract class ExceptionCustom : Exception
    {
        protected ExceptionCustom(string message) : base(message) 
        {
            
        }
    }
}
