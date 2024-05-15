using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.Entities
{
    public class CryptoCurrency
    {
        public int CryptoCurrencyId{ get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }

    }
}
