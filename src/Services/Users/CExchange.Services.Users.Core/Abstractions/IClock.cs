﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.Abstractions
{
    public interface IClock
    {
        DateTime Current();
    }
}
