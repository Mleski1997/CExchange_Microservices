using CExchange.Services.Wallets.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Application.DTO
{
    public class WalletDto
    {
        public string Adress { get; set; }
        public string WalletName { get; set; } = "Wallet";
        public List<FiatCurrency> FiatCurrences { get; set; } = new List<FiatCurrency>();
        public List<CryptoCurrency> CryptoCurrences { get; set; } = new List<CryptoCurrency>();
        public decimal TotalBalance;
    }
}
