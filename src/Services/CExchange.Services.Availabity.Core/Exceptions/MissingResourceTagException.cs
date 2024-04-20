using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availabity.Core.Exceptions
{
    public class MissingResourceTagException : CustomException
    {
        public MissingResourceTagException() : base("Resource tags are missing")
        {
        }
    }
}