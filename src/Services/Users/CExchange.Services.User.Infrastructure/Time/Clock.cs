using CExchange.Services.Users.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.Time
{
    public class Clock : IClock
    {
        public DateTime Current() => DateTime.UtcNow;
       
    }
}
