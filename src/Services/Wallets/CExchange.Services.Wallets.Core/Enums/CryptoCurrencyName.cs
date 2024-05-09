using CExchange.Services.Wallets.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.Enums
{
    public enum CryptoCurrencyName 
    {
        [CurrencySymbol("BTC")]
        Bitcoin,
        [CurrencySymbol("ETH")]
        Ethernum,
        [CurrencySymbol("USDT")]
        Tether,
        [CurrencySymbol("SOL")]
        Solana,
        [CurrencySymbol("BNB")]
        BNB,
        [CurrencySymbol("Doge")]
        Dogecoin
    }
}
