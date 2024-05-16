using CExchange.Services.Wallets.Application.Commands;
using CExchange.Services.Wallets.Application.Commands.Handlers;
using CExchange.Services.Wallets.Application.DTO;
using CExchange.Services.Wallets.Application.Queries;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CExchange.Services.Wallets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly ICommandHandler<AddWallet> _addWalletHandler;
        private readonly IQueryHandler<GetWallet, WalletDto> _getWalletHandler;

        public WalletController(ICommandHandler<AddWallet> addWalletHandler, IQueryHandler<GetWallet, WalletDto> getWalletHandler ) 
        {
            _addWalletHandler = addWalletHandler;
            _getWalletHandler = getWalletHandler;
        }

        [HttpGet()]
        public async Task<ActionResult<WalletDto>> Get([FromQuery]GetWallet walletAdress)
        {
            var wallet = await _getWalletHandler.HandleAsync(walletAdress);
            if (wallet is null)
            {
                return NotFound();
            }
            return Ok(wallet);

        }

        [HttpPost("add-wallet")]
        public async Task<ActionResult> Post(AddWallet command)
        { 
            await _addWalletHandler.HandleAsync(command);
            return Ok();
        }
    }
}
