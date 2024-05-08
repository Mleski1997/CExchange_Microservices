using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class CryptoSymbolAttribute : Attribute
    {
        public string Symbol { get; set; }

        public CryptoSymbolAttribute(string symbol)
        {
            Symbol = symbol;
            
        }
    }
}
