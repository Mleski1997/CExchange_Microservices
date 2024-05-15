using CExchange.Services.Wallets.Application.Commands;
using CExchange.Services.Wallets.Application.Commands.Handlers;
using Convey.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CExchange.Services.Wallets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly ICommandHandler<AddWallet> _addWalletHandler;

        public WalletController(ICommandHandler<AddWallet> addWalletHandler) 
        {
            _addWalletHandler = addWalletHandler;
        }

        [HttpPost("add-wallet")]
        public async Task<ActionResult> Post(AddWallet command)
        { 
            await _addWalletHandler.HandleAsync(command);
            return Ok();
        }
    }
}
