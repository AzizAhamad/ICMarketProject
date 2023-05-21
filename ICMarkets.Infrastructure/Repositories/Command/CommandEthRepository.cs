using System;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Command;
using ICMarkets.Infrastructure.Repositories.Command.Base;

namespace ICMarkets.Infrastructure.Repositories.Command
{
	public class CommandBtcRepository : CommandRepository<Btc>, IBtcCommandRepository
    {
        public CommandBtcRepository(ICMarketsContext context) : base(context)
        {

        }
    }
}


