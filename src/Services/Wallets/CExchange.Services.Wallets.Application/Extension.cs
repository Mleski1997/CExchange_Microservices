﻿using Convey;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Application
{
    public static class Extension
    {
        public static IConveyBuilder AddApplication (this IConveyBuilder builder)
            => builder
                .AddCommandHandlers();

    }
}
