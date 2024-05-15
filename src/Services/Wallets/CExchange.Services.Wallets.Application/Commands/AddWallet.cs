using Convey.CQRS.Commands;


namespace CExchange.Services.Wallets.Application.Commands
{
    public record AddWallet(Guid UserId, string WalletName = "Wallet") : ICommand;
}
