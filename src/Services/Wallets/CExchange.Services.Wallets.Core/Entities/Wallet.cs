namespace CExchange.Services.Wallets.Core.Entities
{
    public class Wallet
    {
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public string WalletName { get; set; } = "Wallet";
        public List<FiatCurrency> FiatCurrences { get; set; } = new List<FiatCurrency>();
        public List<CryptoCurrency> CryptoCurrences { get; set; } = new List<CryptoCurrency>();
        public decimal TotalBalance => CalculateTotalBalance();
 

    
        private decimal CalculateTotalBalance()
        {
            decimal totalFiatInDefaultCurrency = FiatCurrences.Sum(f => f.Balance);
            decimal totalCryptoInDefaultCurrency = CryptoCurrences.Sum(c => c.Amount);

            return totalFiatInDefaultCurrency + totalCryptoInDefaultCurrency;
        }
    } 
}
