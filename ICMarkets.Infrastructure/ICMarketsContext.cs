using System;
using ICMarkets.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICMarkets.Infrastructure
{
	public class ICMarketsContext : DbContext
    {
        public ICMarketsContext(DbContextOptions<ICMarketsContext> options) : base(options)
        {

        }

        public DbSet<Eth> EtheriumCoin { get; set; }
        public DbSet<Dash> DashCoin { get; set; }
        public DbSet<Btc> BitCoin { get; set; }

    }
}



