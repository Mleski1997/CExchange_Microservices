using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.ValueObjects
{
    public class CryptoBalance
    {
        public CryptoCurrency currency { get; set; }
        public decimal Amount { get; set; }


    }
}
