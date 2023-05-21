using System;
using CMarkets.Core.Repositories.Command;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Command;
using ICMarkets.Infrastructure.Repositories.Command.Base;

namespace ICMarkets.Infrastructure.Repositories.Command
{
	public class CommandEthRepository : CommandRepository<Eth>, IEthCommandRepository
    {
        public CommandEthRepository(ICMarketsContext context) : base(context)
        {

        }
    }
}


