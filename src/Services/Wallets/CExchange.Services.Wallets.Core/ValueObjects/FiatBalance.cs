﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.ValueObjects
{
    public class FiatBalance
    {
        public FiatBalance currency { get; set; }
        public decimal Amount { get; set; }

    }
}