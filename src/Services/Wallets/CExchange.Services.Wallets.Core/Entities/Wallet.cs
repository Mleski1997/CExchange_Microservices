using CExchange.Services.Wallets.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.Entities
{
    public class Wallet
    {
        public string Adress { get; set; }
        public Guid UserId { get; set; }
        public string WalletName { get; set; } = "Wallet";
        public List<FiatBalance> FiatBalances { get; set; }
        public List<CryptoBalance> CryptoBalances { get; set; }
        public decimal TotalBalance => CalculateTotalBalance();
        public decimal TotalCryptoBalance => CryptoBalances.Sum(x => x.Amount);
        public decimal TotalFiatBalance => FiatBalances.Sum(c => c.Amount);
     
    }
}
