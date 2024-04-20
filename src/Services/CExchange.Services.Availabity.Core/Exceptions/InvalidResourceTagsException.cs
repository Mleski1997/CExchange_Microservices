using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availabity.Core.Exceptions
{
    internal class InvalidResourceTagsException : CustomException
    {
        public InvalidResourceTagsException() : base("Resource tags are invalid")
        {
        }
    }
}
