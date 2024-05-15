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
        public List<FiatCurrency> FiatBalances { get; set; }
        public List<CryptoCurrency> CryptoBalances { get; set; }
        public decimal TotalBalance { get; set; }
        public decimal TotalCryptoBalance {  get; set; }
        public decimal TotalFiatBalance {  get; set; }
    }
}
