using CExchange.Services.Wallets.Application.DTO;
using Convey.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Application.Queries
{
    public class GetWallet : IQuery<WalletDto>
    {
        public string Adress { get; set; }
    }
}
