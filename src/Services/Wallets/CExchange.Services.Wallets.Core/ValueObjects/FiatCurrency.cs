using CExchange.Services.Wallets.Core.Enums;
using CExchange.Services.Wallets.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.ValueObjects
{
    public class FiatCurrency
    {
        public FiatCurrencyName Name { get; set; }
        public string Symbol { get; set; }

        public FiatCurrency(FiatCurrencyName name)
        {
            Name = name;
            Symbol = name.GetSymbol();
            
        }
    }
}
