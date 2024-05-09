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


        public Wallet()
        {
            Adress = GenerateWalletAdress();
            FiatBalances = new List<FiatBalance>();
            CryptoBalances = new List<CryptoBalance>();
        }


        private decimal CalculateTotalBalance()
        {
            decimal totalFiatInDefaultCurrency = FiatBalances.Sum(f => f.Amount);
            decimal totalCryptoInDefaultCurrency = CryptoBalances.Sum(c => c.Amount);

            return totalFiatInDefaultCurrency + totalCryptoInDefaultCurrency;
        }

        private string GenerateWalletAdress() 
        {
            var random = new Random();
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 16)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    } 
}
