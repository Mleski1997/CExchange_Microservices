using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Coins.Core.Entities
{
    public class Coin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double CurrentValue { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
