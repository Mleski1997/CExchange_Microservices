using CExchange.Services.Wallets.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.Enums
{
    public enum FiatCurrencyName
    {
        [CurrencySymbol("USD")]
        United_States_Dolar,
        [CurrencySymbol("EUR")]
        Euro,
        [CurrencySymbol("PLN")]
        Polish_Złoty
    }
}
