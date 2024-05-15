using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.Entities
{
    public class FiatCurrency
    {
        public int FiatCurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal  Balance { get; set; }

    }
}
