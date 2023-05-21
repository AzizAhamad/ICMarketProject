using System;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Query.Base;

namespace ICMarkets.Core.Repositories.Query
{
	public interface IBtcQueryRepository : IQueryRepository<Btc>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<Btc>> GetAllAsync();
        Task<Btc> GetByIdAsync(Int64 id);
    }
}

