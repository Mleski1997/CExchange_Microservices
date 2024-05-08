using CExchange.Services.Wallets.Core.Enums;
using CExchange.Services.Wallets.Core.Extensions;

namespace CExchange.Services.Wallets.Core.ValueObjects
{
    internal class CryptoCurrency
    {
        public CryptoCurrencyName Name { get; set; }
        public string Symbol { get; set; }

        public CryptoCurrency(CryptoCurrencyName name)
        {
            Name = name;
            Symbol = name.GetSymbol();
            
        }
    }
}
